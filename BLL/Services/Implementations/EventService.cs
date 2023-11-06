using DAL.Models;
using BLL.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace BLL.Services.Interfaces
{
    public class EventService : IEventService
    {
        private IGenericRepository<Event> _eventRepository;

        public EventService(IGenericRepository<Event> repository)
        {
            _eventRepository = repository;
        }

        public async Task<IEnumerable<Event>> GetAll(Expression<Func<Event, bool>>? filter = null)
        {
            return await _eventRepository.GetAllAsync(filter);
        }

        public async Task<Event> GetEvent(Expression<Func<Event, bool>>? filter = null)
        {
            return await _eventRepository.GetAsync(filter);
        }

        public async Task AddEvent(Event _event)
        {
            await _eventRepository.AddAsync(_event);
        }

        public async Task UpdateEvent(Event _event)
        {
            await _eventRepository.UpdateAsync(_event);
        }

        public async Task DeleteEvent(int id)
        {
            await _eventRepository.DeleteAsync(id);
        }
    }
}