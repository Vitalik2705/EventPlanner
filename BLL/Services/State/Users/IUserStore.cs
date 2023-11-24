using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.State.Users
{
    public interface IUserStore
    {
        User CurrentUser { get; set; }

        event Action StateChanged;
    }
}
