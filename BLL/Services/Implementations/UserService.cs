using BLL.Services.Repositories;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Interfaces
{
    public class UserService
    {
        private IGenericRepository<User> _userRepository;

        public UserService(IGenericRepository<User> repository)
        {
            _userRepository = repository;
        }

        public IEnumerable<User> GetAll()
        {
            return _userRepository.GetAll();
        }
        public User GetUserById(int id)
        {
            return _userRepository.GetById(id);
        }

        public void AddUser(User user)
        {
            _userRepository.Add(user);
            _userRepository.Save();
        }
        public void UpdateUser(User user)
        {
            _userRepository.Update(user);
            _userRepository.Save();
        }
        public void DeleteUser(int id)
        {
            _userRepository.Delete(id);
            _userRepository.Save();
        }
    }
}
