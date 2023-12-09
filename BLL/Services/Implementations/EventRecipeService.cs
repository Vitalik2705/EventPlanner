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
    public class EventRecipeService : IEventRecipeService
    {
        private IGenericRepository<EventRecipe> _eventRecipeRepository;

        public EventRecipeService(IGenericRepository<EventRecipe> repository)
        {
            this._eventRecipeRepository = repository;
        }

        public async Task<IEnumerable<EventRecipe>> GetAll(Expression<Func<EventRecipe, bool>>? filter = null)
        {
            return await this._eventRecipeRepository.GetAllAsync(filter);
        }

        public async Task<EventRecipe> GetEventRecipe(Expression<Func<EventRecipe, bool>>? filter = null)
        {
            return await this._eventRecipeRepository.GetAsync(filter);
        }

        public async Task AddEventRecipe(EventRecipe _eventRecipe)
        {
            var validator = new EventRecipeValidation();
            var validationResult = validator.Validate(_eventRecipe);

            if (!validationResult.IsValid)
            {
                return;
            }

            await this._eventRecipeRepository.AddAsync(_eventRecipe);
        }

        public async Task UpdateEventRecipe(EventRecipe _eventRecipe)
        {
            await this._eventRecipeRepository.UpdateAsync(_eventRecipe);
        }

        public async Task DeleteEventRecipe(int id)
        {
            await this._eventRecipeRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<EventRecipe>> GetRecipesForEvent(int eventId)
        {
            return await _eventRecipeRepository.GetAllAsync(er => er.EventId == eventId);
        }
    }
}
