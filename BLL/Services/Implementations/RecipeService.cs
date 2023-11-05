using DAL.Models;
using BLL.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public IEnumerable<Recipe> GetAll()
        {
            return _recipeRepository.GetAll();
        }
        public Recipe GetRecipeById(int id)
        {
            return _recipeRepository.GetById(id);
        }
        public void AddRecipe(Recipe recipe)
        {
            _recipeRepository.Add(recipe);
            _recipeRepository.Save();
        }
        public void UpdateRecipe(Recipe recipe)
        {
            _recipeRepository.Update(recipe);
            _recipeRepository.Save();
        }
        public void DeleteRecipe(int id)
        {
            _recipeRepository.Delete(id);
            _recipeRepository.Save();
        }
    }
}
