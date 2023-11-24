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
        public enum RegistrationResult
        {
            Success,
            PasswordsDoNotMatch,
            EmailAlreadyExists,
            UsernameAlreadyExists
        }

        Task<User> Login(string password, string email);

        Task<RegistrationResult> Register(User user);
    }
}
