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
        Task<IngredientUnit> GetByIdAsync(int id);
        IngredientUnit GetIngredientUnitById(int id);
        void AddIngredientUnit(IngredientUnit ingredientUnit);
        void UpdateIngredientUnit(IngredientUnit ingredientUnit);
        void DeleteIngredientUnit(int id);
    }
}
