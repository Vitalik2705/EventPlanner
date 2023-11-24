using DAL.Models;
using static BLL.Services.Repositories.IUserRepository;

namespace DAL.State.Authenticator
{
    public interface IAuthenticator
    {
        User CurrentUser { get; }

        bool IsLoggedIn { get; }

        event Action StateChanged;

        Task<RegistrationResult> Register(User user);

        Task<bool> Login(string password, string username);

        void Logout();
    }
}
