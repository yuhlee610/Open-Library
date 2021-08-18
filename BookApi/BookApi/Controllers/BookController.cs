using AutoMapper;
using BookApi.Data;
using BookApi.IRepository;
using BookApi.Models;
using Microsoft.AspNetCore.Http;
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
        public BookController(IUnitOfWork unitOfWork, ILogger<BookController> logger, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
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
    }
}
