using AutoMapper;
using BookApi.IRepository;
using BookApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<CategoryController> _logger;
        private readonly IMapper _mapper;
        public CategoryController(IUnitOfWork unitOfWork, ILogger<CategoryController> logger, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetCategories()
        {
            try
            {
                var categories = await _unitOfWork.Categories.GetAll();
                var results = _mapper.Map<List<CategoryDTO>>(categories.Item1);
                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in the {nameof(GetCategories)}!!");
                return StatusCode(500, "Internal server error. Please  try again error!!");
            }
        }
    }
}
