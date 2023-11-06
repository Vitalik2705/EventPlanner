using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Interfaces
{
    public interface IIngredientUnitService
    {
        async Task<IEnumerable<IngredientUnit>> GetAll();
        async Task<IngredientUnit> GetIngredientUnitById(int id);
        async Task AddIngredientUnit(IngredientUnit _ingredientUnit);
        async Task UpdateIngredientUnit(IngredientUnit _ingredientUnit);
        async Task DeleteIngredientUnit(int id);
    }
}
