using BLL.Services.Interfaces;
using BLL.Services.Repositories;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Implementations
{
    public class IngredientUnitRecipeService : IIngredientUnitRecipeService
    {
        private IGenericRepository<IngredientUnitRecipe> _ingredientUnitRecipeRepository;

        public IngredientUnitRecipeService(IGenericRepository<IngredientUnitRecipe> repository)
        {
            this._ingredientUnitRecipeRepository = repository;
        }

        public async Task AddIngredientUnitRecipe(IngredientUnitRecipe _ingredientUnitRecipe)
        {
            //var validator = new EventGuestValidation();
            //var validationResult = validator.Validate(_event);

            //if (!validationResult.IsValid)
            //{
            //    return;
            //}

            await this._ingredientUnitRecipeRepository.AddAsync(_ingredientUnitRecipe);
        }

        public async Task DeleteIngredientUnitRecipe(int id)
        {
            await this._ingredientUnitRecipeRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<IngredientUnitRecipe>> GetAll(Expression<Func<IngredientUnitRecipe, bool>>? filter = null)
        {
            return await this._ingredientUnitRecipeRepository.GetAllAsync(filter);
        }

        public async Task<IEnumerable<IngredientUnitRecipe>> GetIngredientUnitForRecipe(int recipeId)
        {
            return await _ingredientUnitRecipeRepository.GetAllAsync(eg => eg.RecipeId == recipeId);
        }

        public async Task<IngredientUnitRecipe> GetIngredientUnitRecipe(Expression<Func<IngredientUnitRecipe, bool>>? filter = null)
        {
            return await this._ingredientUnitRecipeRepository.GetAsync(filter);
        }

        public async Task<IEnumerable<IngredientUnitRecipe>> GetRecipeForIngredientUnit(int ingredientUnitId)
        {
            return await _ingredientUnitRecipeRepository.GetAllAsync(eg => eg.IngredientUnitId == ingredientUnitId);
        }

        public async Task UpdateIngredientUnitRecipe(IngredientUnitRecipe _eventGuest)
        {
            await this._ingredientUnitRecipeRepository.UpdateAsync(_eventGuest);
        }
    }
}
