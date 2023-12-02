using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Interfaces
{
    public interface IEventService
    {
        Task<IEnumerable<Event>> GetAll(Expression<Func<Event, bool>>? filter = null);

        Task<Event> GetEvent(Expression<Func<Event, bool>>? filter = null);

        Task AddEvent(Event _event);

        Task UpdateEvent(Event _event);

        Task DeleteEvent(int id);

    }
}
