using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Interfaces
{
    public interface IIngredientUnitRecipeService
    {
        Task<IEnumerable<IngredientUnitRecipe>> GetAll(Expression<Func<IngredientUnitRecipe, bool>>? filter = null);

        Task<IngredientUnitRecipe> GetIngredientUnitRecipe(Expression<Func<IngredientUnitRecipe, bool>>? filter = null);

        Task AddIngredientUnitRecipe(IngredientUnitRecipe _eventGuest);

        Task UpdateIngredientUnitRecipe(IngredientUnitRecipe _eventGuest);

        Task DeleteIngredientUnitRecipe(int id);

        Task<IEnumerable<IngredientUnitRecipe>> GetIngredientUnitForRecipe(int guestId);

        Task<IEnumerable<IngredientUnitRecipe>> GetRecipeForIngredientUnit(int eventId);
    }
}
