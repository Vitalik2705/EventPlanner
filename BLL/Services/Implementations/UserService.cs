

namespace BLL.Services.Interfaces
{
    using DAL.Models;
    using BLL.Services.Repositories;
    using static BLL.Services.Repositories.IUserRepository;

    public class UserService : IUserService
    {
        private IUserRepository _userRepository;

        public UserService(IUserRepository repository)
        {
            this._userRepository = repository;
        }

        /// <inheritdoc/>
        public async Task<User> Login(string password, string email)
        {
            var user = await this._userRepository.Login(password, email);

            return user;
        }

        /// <inheritdoc/>
        public async Task<RegistrationResult> Register(User user)
        {
            var regUser = await this._userRepository.Register(user);

            return regUser;
        }
    }
}