using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static BLL.Services.Repositories.IUserRepository;

namespace BLL.Services.Interfaces
{
    public interface IUserService
    {
        //Task<IEnumerable<User>> GetAll(Expression<Func<User, bool>>? filter = null);
        //Task<User> GetUser(Expression<Func<User, bool>>? filter = null);
        //Task AddUser(User _User);
        Task UpdateUser(User _User);
        //Task DeleteUser(int id);
        Task<User> Login(string password, string email);

        Task<RegistrationResult> Register(User user);
    }
}
