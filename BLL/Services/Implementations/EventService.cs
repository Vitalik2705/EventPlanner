// <copyright file="EventService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace BLL.Services.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    using BLL.Services.Repositories;
    using BLL.Validation;
    using DAL.Models;

    public class EventService : IEventService
    {
        private IGenericRepository<Event> _eventRepository;

        public EventService(IGenericRepository<Event> repository)
        {
            this._eventRepository = repository;
        }

        public async Task<IEnumerable<Event>> GetAll(Expression<Func<Event, bool>>? filter = null)
        {
            return await this._eventRepository.GetAllAsync(filter);
        }

        public async Task<Event> GetEvent(Expression<Func<Event, bool>>? filter = null)
        {
            return await this._eventRepository.GetAsync(filter);
        }

        public async Task AddEvent(Event _event)
        {
            var validator = new EventValidation();
            var validationResult = validator.Validate(_event);

            if (validationResult.IsValid)
            {
                return;
            }

            await this._eventRepository.AddAsync(_event);
        }

        public async Task UpdateEvent(Event _event)
        {
            await this._eventRepository.UpdateAsync(_event);
        }

        public async Task DeleteEvent(int id)
        {
            await this._eventRepository.DeleteAsync(id);
        }
    }
}