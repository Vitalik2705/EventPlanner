using DAL.Models;
using BLL.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Interfaces
{
    public class EventService : IEventService
    {
        private IGenericRepository<Event> _eventRepository;

        public EventService(IGenericRepository<Event> repository)
        {
            _eventRepository = repository;
        }

        public IEnumerable<Event> GetAll()
        {
            return _eventRepository.GetAll();
        }
        public Event GetEventById(int id)
        {
            return _eventRepository.GetById(id);
        }
        public void AddEvent(Event _event)
        {
            _eventRepository.Add(_event);
            _eventRepository.Save();
        }
        public void UpdateEvent(Event _event)
        {
            _eventRepository.Update(_event);
            _eventRepository.Save();
        }
        public void DeleteEvent(int id)
        {
            _eventRepository.Delete(id);
            _eventRepository.Save();
        }
    }
}
