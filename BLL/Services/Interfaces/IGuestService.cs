using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Interfaces
{
    public interface IGuestService
    {
        Task<Guest> GetByIdAsync(int id);
        Guest GetGuestById(int id);
        void AddGuest(Guest guest);
        void UpdateGuest(Guest guest);
        void DeleteGuest(int id);
    }
}
