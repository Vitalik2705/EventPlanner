using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Interfaces
{
    public interface IGuestService
    {
        Task<IEnumerable<Guest>> GetAll(Expression<Func<Guest, bool>>? filter = null);
        Task<Guest> GetGuest(Expression<Func<Guest, bool>>? filter = null);
        Task AddGuest(Guest _guest);
        Task UpdateGuest(Guest _guest);
        Task DeleteGuest(int id);
        Task<List<Guest>> GetGuestsAsync(Expression<Func<Guest, bool>>? filter = null);
        Task<Guest> GetGuestById(int guestId);
    }
}
