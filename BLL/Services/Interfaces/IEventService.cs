using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Interfaces
{
    public interface IEventService
    {
        async Task<IEnumerable<Event>> GetAll();
        async Task<Event> GetEventById(int id);
        async Task AddEvent(Event _event);
        async Task UpdateEvent(Event _event);
        async Task DeleteEvent(int id);
    }
}
