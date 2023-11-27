namespace BLL.Services.State.Users
{
    using DAL.Models;

    public class UserStore : IUserStore
    {
        private User _currentUser;

        public User CurrentUser
        {
            get
            {
                return this._currentUser;
            }

            set
            {
                this._currentUser = value;
                this.StateChanged?.Invoke();
            }
        }

        public event Action StateChanged;
    }
}
