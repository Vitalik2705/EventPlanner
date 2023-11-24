using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.State.Users
{
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
