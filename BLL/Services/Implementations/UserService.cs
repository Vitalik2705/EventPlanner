using DAL.Models;
using BLL.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace BLL.Services.Interfaces
{
    public class UserService : IUserService
    {
        private IUserRepository _userRepository;

        public UserService(IUserRepository repository)
        {
            this._userRepository = repository;
        }

        //public async Task<IEnumerable<User>> GetAll(Expression<Func<User, bool>>? filter = null)
        //{
        //    return await _userRepository.GetAllAsync(filter);
        //}

        //public async Task<User> GetUser(Expression<Func<User, bool>>? filter = null)
        //{
        //    return await _userRepository.GetAsync(filter);
        //}

        //public async Task AddUser(User _user)
        //{
        //    await _userRepository.AddAsync(_user);
        //}

        //public async Task UpdateUser(User _user)
        //{
        //    await _userRepository.UpdateAsync(_user);
        //}

        //public async Task DeleteUser(int id)
        //{
        //    await _userRepository.DeleteAsync(id);
        //}


        /// <inheritdoc/>
        public async Task<User> Login(string password, string email)
        {
            var user = await this._userRepository.Login(password, email);

            return user;
        }

        /// <inheritdoc/>
        public async Task<User> Register(User user)
        {
            var regUser = await this._userRepository.Register(user);

            return regUser;
        }

    }
}