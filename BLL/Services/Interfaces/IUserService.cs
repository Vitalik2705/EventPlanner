using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Interfaces
{
    public interface IUserService
    {
        async Task<IEnumerable<User>> GetAll();
        async Task<User> GetUserById(int id);
        async Task AddUser(User _User);
        async Task UpdateUser(User _User);
        async Task DeleteUser(int id);
        //Task<User> GetByEmail(string email);
        async Task<User> GetUserByUsernameAndPasswordAsync(string username, string password);
    }
}
