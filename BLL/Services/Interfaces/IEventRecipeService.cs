using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Interfaces
{
    public interface IEventRecipeService
    {
        Task<IEnumerable<EventRecipe>> GetAll(Expression<Func<EventRecipe, bool>>? filter = null);

        Task<EventRecipe> GetEventRecipe(Expression<Func<EventRecipe, bool>>? filter = null);

        Task AddEventRecipe(EventRecipe _eventRecipe);

        Task UpdateEventRecipe(EventRecipe _eventRecipe);

        Task DeleteEventRecipe(int id);

        Task<IEnumerable<EventRecipe>> GetRecipesForEvent(int eventId);
    }
}
