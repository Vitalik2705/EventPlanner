using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Repositories
{
    public interface IUserRepository
    {
        Task<User> Login(string password, string email);
        Task<User> Register(User user);
        //Task AddAsync(User model);
        //Task UpdateAsync(User model);
        //Task<User> GetAsync(Expression<Func<User, bool>>? filter = null);
        //Task<IEnumerable<User>> GetAllAsync(Expression<Func<User, bool>>? filter = null);
        //Task DeleteAsync(int id);
        //Task SaveAsync();
    }
}
