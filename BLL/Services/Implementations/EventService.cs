using DAL.Models;
using BLL.Services.Repositories;
using System;
using System.Collections.Generic;
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

        public async Task<IEnumerable<Event>> GetAll()
        {
            return await _eventRepository.GetAll();
        }

        public async Task<Event> GetEventById(int id)
        {
            return await _eventRepository.GetById(id);
        }

        public async Task AddEvent(Event _event)
        {
            _eventRepository.Add(_event);
            await _eventRepository.Save();
        }

        public async Task UpdateEvent(Event _event)
        {
            _eventRepository.Update(_event);
            await _eventRepository.Save();
        }

        public async Task DeleteEvent(int id)
        {
            _eventRepository.Delete(id);
            await _eventRepository.Save();
        }
    }
}