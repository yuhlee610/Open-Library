using BookApi.Data;
using BookApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookApi.Services
{
    public interface IAuthManager
    {
        Task<User> ValidateUser(LoginUserDTO userDTO);
        Task<string> CreateToken();
    }
}
