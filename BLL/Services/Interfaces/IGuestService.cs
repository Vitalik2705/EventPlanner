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
        async Task<IEnumerable<Guest>> GetAll();
        async Task<Guest> GetGuestById(int id);
        async Task AddGuest(Guest _guest);
        async Task UpdateGuest(Guest _guest);
        async Task DeleteGuest(int id);
    }
}
