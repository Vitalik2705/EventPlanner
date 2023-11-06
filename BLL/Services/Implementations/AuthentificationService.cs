using DAL.Models;
using BLL.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Services.Interfaces
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUserService _authenticationService;

        public AuthenticationService(IUserService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        //public async Task<User> Login(string username, string password)
        //{
        //    User user = await _userService.GetUserByUsernameAndPasswordAsync(username, password);

        //    return user;
        //}

        //public async Task<User> GetUserByUsernameAndPasswordAsync(string username, string password)
        //{
        //    var user = _authenticationService.
        //}

    }
}