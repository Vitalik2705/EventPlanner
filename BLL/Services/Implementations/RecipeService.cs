using DAL.Models;
using BLL.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Services.Interfaces
{
    public class RecipeService : IRecipeService
    {
        private IGenericRepository<Recipe> _recipeRepository;

        public RecipeService(IGenericRepository<Recipe> repository)
        {
            _recipeRepository = repository;
        }

        public async Task<IEnumerable<Recipe>> GetAll()
        {
            return await _recipeRepository.GetAll();
        }

        public async Task<Recipe> GetRecipeById(int id)
        {
            return await _recipeRepository.GetById(id);
        }

        public async Task AddRecipe(Recipe _recipe)
        {
            _recipeRepository.Add(_recipe);
            await _recipeRepository.Save();
        }

        public async Task UpdateRecipe(Recipe _recipe)
        {
            _recipeRepository.Update(_recipe);
            await _recipeRepository.Save();
        }

        public async Task DeleteRecipe(int id)
        {
            _recipeRepository.Delete(id);
            await _recipeRepository.Save();
        }
    }
}