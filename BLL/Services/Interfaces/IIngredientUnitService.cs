using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Interfaces
{
    public interface IIngredientUnitService
    {
        Task<IEnumerable<IngredientUnit>> GetAll(Expression<Func<IngredientUnit, bool>>? filter = null);
        Task<IngredientUnit> GetIngredientUnit(Expression<Func<IngredientUnit, bool>>? filter = null);
        Task AddIngredientUnit(IngredientUnit _ingredientUnit);
        Task UpdateIngredientUnit(IngredientUnit _ingredientUnit);
        Task DeleteIngredientUnit(int id);
    }
}
