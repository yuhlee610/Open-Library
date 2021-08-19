using BookApi.Data;
using BookApi.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BookApi.Services
{
    public class AuthManager : IAuthManager
    {
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _configuration;
        private User _user;
        public AuthManager(UserManager<User> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }

        public async Task<string> CreateToken()
        {
            // set up khóa
            var signingCredentials = GetSigningCredentials();

            var claims = await GetClaims();

            // set up token
            var token = GenerateTokenOptions(signingCredentials, claims);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private SigningCredentials GetSigningCredentials()
        {
            var key = Environment.GetEnvironmentVariable("OPEN_LIBRARY_KEY");
            // Biểu diễn lớp cơ sở trừu tượng cho tất cả các khóa được tạo bằng thuật toán đối xứng.
            var secret = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));

            // Đại diện cho mật mã, thuật toán
            return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
        }

        private JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials, List<Claim> claims)
        {
            var jwtSettings = _configuration.GetSection("Jwt");
            // create expire time
            var expiration = DateTime.Now.AddMinutes(Convert.ToDouble(
                jwtSettings.GetSection("lifetime").Value));

            var token = new JwtSecurityToken(
                issuer: jwtSettings.GetSection("Issuer").Value,
                claims: claims,
                expires: expiration,
                signingCredentials: signingCredentials
                );

            return token;
        }

        /*
            Add claims into token
            In ASP core API, Authorize by claims which were added into token
            Example: if claims have Role, Authorize can authorize by Role
         */
        private async Task<List<Claim>> GetClaims()
        {
            var claims = new List<Claim>
             {
                 new Claim(ClaimTypes.Name, _user.UserName)
             };

            var roles = await _userManager.GetRolesAsync(_user);

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            claims.Add(new Claim(ClaimTypes.NameIdentifier, _user.Id));

            return claims;
        }

        public async Task<bool> ValidateUser(LoginUserDTO userDTO)
        {
            _user = await _userManager.FindByEmailAsync(userDTO.Email);
            var validPassword = await _userManager.CheckPasswordAsync(_user, userDTO.Password);
            return (_user != null && validPassword);
        }
    }
}
