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
        Task<Event> GetByIdAsync(int id);
        Event GetEventById(int id);
        void AddEvent(Event _event);
        void UpdateEvent(Event _event);
        void DeleteEvent(int id);
    }
}
