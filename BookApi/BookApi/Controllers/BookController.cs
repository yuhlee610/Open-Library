using AutoMapper;
using BookApi.Data;
using BookApi.IRepository;
using BookApi.Models;
using Marvin.Cache.Headers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BookApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<BookController> _logger;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        public BookController(IUnitOfWork unitOfWork, ILogger<BookController> logger, IMapper mapper, UserManager<User> userManager)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
            _userManager = userManager;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetBooks(int currentPage, int categoryId)
        {
            try
            {
                Expression<Func<Book, bool>> expression = null;
                if (categoryId != 0)
                {
                    expression = b => b.CategoryId == categoryId;
                }

                var result = await _unitOfWork.Books.GetAll(
                    expression: expression,
                    orderBy: q => q.OrderBy(d => d.Name),
                    pagination: new Pagination { CurrentPage = currentPage });

                var listBookDTO = _mapper.Map<List<BookDTO>>(result.Item1);

                return Ok(new ListBookDTO
                {
                    Books = listBookDTO,
                    CurrentPage = result.Item2.CurrentPage,
                    TotalPage = result.Item2.TotalPage
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in the {nameof(GetBooks)}!!");
                return StatusCode(500, "Internal server error. Please  try again error!!");
            }
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetBook(int id)
        {
            try
            {
                var book = await _unitOfWork.Books.Get(expression: b => b.Id == id);
                var result = _mapper.Map<BookDTO>(book);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in the {nameof(GetBook)}!!");
                return StatusCode(500, "Internal server error. Please  try again error!!");
            }
        }

        [Authorize]
        [HttpPut]
        [Route("BorrowBook")]
        [HttpCacheExpiration(NoStore = true, MaxAge = 0)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> BorrowBook([FromBody] BorrowInfo borrowInfo)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError($"Invalid UPDATE attempt in {nameof(BorrowBook)}");
                return BadRequest(ModelState);
            }
            try
            {
                var book = await _unitOfWork.Books.Get(expression: b => b.Id == borrowInfo.IdBook, includes: new List<string> { "Users" });
                var user = await _userManager.FindByIdAsync(borrowInfo.IdUser);

                if(book.Users.FirstOrDefault(u => u.Id == user.Id) != null)
                {
                    return BadRequest("User exists");
                }

                book.Users.Add(user);
                _unitOfWork.Books.Update(book);
                await _unitOfWork.Save();

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in the {nameof(BorrowBook)}!!");
                return StatusCode(500, "Internal server error. Please  try again error!!");
            }
        }
    }
}
