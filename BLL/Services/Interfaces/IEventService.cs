using DAL.Models;
using System.Linq.Expressions;

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
