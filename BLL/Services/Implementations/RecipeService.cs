using DAL.Models;
using DAL.RepositoryPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Interfaces
{
    public class RecipeService
    {
        private readonly IGenericRepository<Recipe> _recipeRepo;

        public RecipeService(IGenericRepository<Recipe> recipeRepo)
        {
            _recipeRepo = recipeRepo;
        }

        public IEnumerable<Recipe> GetAll()
        {
            return _recipeRepo.GetAll();
        }
    }
}
