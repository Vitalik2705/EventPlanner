using DAL.Models;
using BLL.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace BLL.Services.Interfaces
{
    public class RecipeService : IRecipeService
    {
        private IGenericRepository<Recipe> _recipeRepository;

        public RecipeService(IGenericRepository<Recipe> repository)
        {
            _recipeRepository = repository;
        }

        public async Task<IEnumerable<Recipe>> GetAll(Expression<Func<Recipe, bool>>? filter = null)
        {
            return await _recipeRepository.GetAllAsync(filter);
        }

        public async Task<Recipe> GetRecipe(Expression<Func<Recipe, bool>>? filter = null)
        {
            return await _recipeRepository.GetAsync(filter);
        }

        public async Task AddRecipe(Recipe _recipe)
        {
            await _recipeRepository.AddAsync(_recipe);
        }

        public async Task UpdateRecipe(Recipe _recipe)
        {
            await _recipeRepository.UpdateAsync(_recipe);
        }

        public async Task DeleteRecipe(int id)
        {
            await _recipeRepository.DeleteAsync(id);
        }
        public async Task<List<Recipe>> GetRecipesAsync(Expression<Func<Recipe, bool>>? filter = null)
        {
            return (await _recipeRepository.GetAllAsync(filter)).ToList();
        }
    }
}