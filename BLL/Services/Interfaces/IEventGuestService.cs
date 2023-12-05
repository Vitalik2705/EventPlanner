using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Interfaces
{
    public interface IEventGuestService
    {
        Task<IEnumerable<EventGuest>> GetAll(Expression<Func<EventGuest, bool>>? filter = null);

        Task<EventGuest> GetEventGuest(Expression<Func<EventGuest, bool>>? filter = null);

        Task AddEventGuest(EventGuest _eventGuest);

        Task UpdateEventGuest(EventGuest _eventGuest);

        Task DeleteEventGuest(int id);
    }
}
