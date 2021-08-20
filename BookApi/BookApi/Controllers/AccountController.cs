using AutoMapper;
using BookApi.Data;
using BookApi.Models;
using BookApi.Services;
using Marvin.Cache.Headers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly IAuthManager _authManager;
        private readonly ILogger<AccountController> _logger;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        public AccountController(UserManager<User> userManager, ILogger<AccountController> logger, IMapper mapper, IAuthManager authManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _logger = logger;
            _mapper = mapper;
            _authManager = authManager;
            _configuration = configuration;
        }

        [HttpPost]
        [Route("Register")]
        [HttpCacheExpiration(NoStore = true, MaxAge = 0)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Register([FromBody] RegisterUserDTO userDTO)
        {
            _logger.LogInformation($"Register attempt for {userDTO.Email}");
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            try
            {
                var user = _mapper.Map<User>(userDTO);
                user.UserName = user.FirstName + user.LastName;
                var result = await _userManager.CreateAsync(user, userDTO.Password);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "User");
                    return Ok();
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in the action {nameof(Register)}");
                return Problem($"Something went wrong in the action {nameof(Register)}", statusCode: 500);
            }
        }

        [HttpPost]
        [Route("Login")]
        [HttpCacheExpiration(NoStore = true, MaxAge = 0)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Login([FromBody] LoginUserDTO userDTO)
        {
            _logger.LogInformation($"Login attempt for {userDTO.Email}");
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            try
            {
                var user = await _authManager.ValidateUser(userDTO);
                if (user == null)
                {
                    return Unauthorized();
                }
                return Ok(
                    new 
                    { 
                        Token = await _authManager.CreateToken(), 
                        IdUser = user.Id,
                        ExpiresIn = DateTime.Now.AddMinutes(Convert.ToDouble(_configuration.GetSection("Jwt").GetSection("lifetime").Value))
                    });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in the action {nameof(Login)}");
                return Problem($"Something went wrong in the action {nameof(Login)}", statusCode: 500);
            }
        }
    }
}
