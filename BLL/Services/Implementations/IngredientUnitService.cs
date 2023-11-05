using DAL.Models;
using BLL.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Interfaces
{
    public class IngredientUnitService : IIngredientUnitService
    {
        private IGenericRepository<IngredientUnit> _ingredientUnitRepository;

        public IngredientUnitService(IGenericRepository<IngredientUnit> repository)
        {
            _ingredientUnitRepository = repository;
        }

        public IEnumerable<IngredientUnit> GetAll()
        {
            return _ingredientUnitRepository.GetAll();
        }
        public IngredientUnit GetIngredientUnitById(int id)
        {
            return _ingredientUnitRepository.GetById(id);
        }
        public void AddIngredientUnit(IngredientUnit ingredientUnit)
        {
            _ingredientUnitRepository.Add(ingredientUnit);
            _ingredientUnitRepository.Save();
        }
        public void UpdateIngredientUnit(IngredientUnit ingredientUnit)
        {
            _ingredientUnitRepository.Update(ingredientUnit);
            _ingredientUnitRepository.Save();
        }
        public void DeleteIngredientUnit(int id)
        {
            _ingredientUnitRepository.Delete(id);
            _ingredientUnitRepository.Save();
        }
    }
}
