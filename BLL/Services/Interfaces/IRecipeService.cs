using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Interfaces
{
    public interface IRecipeService
    {
        async Task<IEnumerable<Recipe>> GetAll();
        async Task<Recipe> GetRecipeById(int id);
        async Task AddRecipe(Recipe _recipe);
        async Task UpdateRecipe(Recipe _recipe);
        async Task DeleteRecipe(int id);
    }
}
