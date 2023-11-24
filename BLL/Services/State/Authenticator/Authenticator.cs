using BLL.Services.Interfaces;
using BLL.Services.Repositories;
using BLL.Services.State.Users;
using DAL.Models;
using DAL.State.Authenticator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.State.Authenticator
{
    public class Authenticator : IAuthenticator
    {
        private readonly IUserService _authenticationService;
        private readonly IUserStore _accountStore;

        public Authenticator(IUserService authenticationService, IUserStore accountStore)
        {
            this._authenticationService = authenticationService;
            this._accountStore = accountStore;
        }

        public User CurrentUser
        {
            get
            {
                return this._accountStore.CurrentUser;
            }

            private set
            {
                this._accountStore.CurrentUser = value;
                this.StateChanged?.Invoke();
            }
        }

        public bool IsLoggedIn => this.CurrentUser != null;

        public event Action StateChanged;

        public async Task<bool> Login(string password, string username)
        {
            bool success = true;
            try
            {
                this.CurrentUser = await this._authenticationService.Login(password, username);
            }
            catch (Exception)
            {
                success = false;
            }

            return success;
        }

        public void Logout()
        {
            this.CurrentUser = null;
        }

        public async Task<IUserRepository.RegistrationResult> Register(User user)
        {
            return await this._authenticationService.Register(user);
        }
    }
}
