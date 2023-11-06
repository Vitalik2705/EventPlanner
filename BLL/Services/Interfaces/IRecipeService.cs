using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Interfaces
{
    public interface IRecipeService
    {
        Task<IEnumerable<Recipe>> GetAll(Expression<Func<Recipe, bool>>? filter = null);
        Task<Recipe> GetRecipe(Expression<Func<Recipe, bool>>? filter = null);
        Task AddRecipe(Recipe _recipe);
        Task UpdateRecipe(Recipe _recipe);
        Task DeleteRecipe(int id);
    }
}
