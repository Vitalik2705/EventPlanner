using BLL.Services.Interfaces;
using BLL.Services.Repositories;
using BLL.Validation;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Implementations
{
    public class EventGuestService : IEventGuestService
    {
        private IGenericRepository<EventGuest> _eventGuestRepository;

        public EventGuestService(IGenericRepository<EventGuest> repository)
        {
            this._eventGuestRepository = repository;
        }

        public async Task<IEnumerable<EventGuest>> GetAll(Expression<Func<EventGuest, bool>>? filter = null)
        {
            return await this._eventGuestRepository.GetAllAsync(filter);
        }

        public async Task<EventGuest> GetEventGuest(Expression<Func<EventGuest, bool>>? filter = null)
        {
            return await this._eventGuestRepository.GetAsync(filter);
        }

        public async Task AddEventGuest(EventGuest _event)
        {
            var validator = new EventGuestValidation();
            var validationResult = validator.Validate(_event);

            if (!validationResult.IsValid)
            {
                return;
            }

            await this._eventGuestRepository.AddAsync(_event);
        }

        public async Task UpdateEventGuest(EventGuest _event)
        {
            await this._eventGuestRepository.UpdateAsync(_event);
        }

        public async Task DeleteEventGuest(int id)
        {
            await this._eventGuestRepository.DeleteAsync(id);
        }
    }
}
