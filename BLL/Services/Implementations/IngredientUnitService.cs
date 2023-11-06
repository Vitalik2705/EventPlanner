using DAL.Models;
using BLL.Services.Repositories;
using System;
using System.Collections.Generic;
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

        public async Task<IEnumerable<IngredientUnit>> GetAll()
        {
            return await _ingredientUnitRepository.GetAll();
        }

        public async Task<IngredientUnit> GetIngredientUnitById(int id)
        {
            return await _ingredientUnitRepository.GetById(id);
        }

        public async Task AddIngredientUnit(IngredientUnit _ingredientUnit)
        {
            _ingredientUnitRepository.Add(_ingredientUnit);
            await _ingredientUnitRepository.Save();
        }

        public async Task UpdateIngredientUnit(IngredientUnit _ingredientUnit)
        {
            _ingredientUnitRepository.Update(_ingredientUnit);
            await _ingredientUnitRepository.Save();
        }

        public async Task DeleteIngredientUnit(int id)
        {
            _ingredientUnitRepository.Delete(id);
            await _ingredientUnitRepository.Save();
        }
    }
}