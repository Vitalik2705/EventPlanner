using DAL.Models;
using BLL.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Services.Interfaces
{
    public class UserService : IUserService
    {
        private IGenericRepository<User> _userRepository;

        public UserService(IGenericRepository<User> repository)
        {
            _userRepository = repository;
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await _userRepository.GetAll();
        }

        public async Task<User> GetUserById(int id)
        {
            return await _userRepository.GetById(id);
        }

        public async Task AddUser(User _user)
        {
            _userRepository.Add(_user);
            await _userRepository.Save();
        }

        public async Task UpdateUser(User _user)
        {
            _userRepository.Update(_User);
            await _UserRepository.Save();
        }

        public async Task DeleteUser(int id)
        {
            _UserRepository.Delete(id);
            await _userRepository.Save();
        }

        //public async Task<Account> GetByEmail(string email)
        //{
        //    return await _userRepository. == email;
        //}

        public async Task<User> GetUserByUsernameAndPasswordAsync(string username, string password)
        {
            
        }

    }
}