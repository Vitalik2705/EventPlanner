using DAL.Models;
using BLL.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq.Expressions;
using BLL.Validation;

namespace BLL.Services.Interfaces
{
    public class IngredientUnitService : IIngredientUnitService
    {
        private IGenericRepository<IngredientUnit> _ingredientUnitRepository;

        public IngredientUnitService(IGenericRepository<IngredientUnit> repository)
        {
            _ingredientUnitRepository = repository;
        }

        public async Task<IEnumerable<IngredientUnit>> GetAll(Expression<Func<IngredientUnit, bool>>? filter = null)
        {
            return await _ingredientUnitRepository.GetAllAsync(filter);
        }

        public async Task<IngredientUnit> GetIngredientUnit(Expression<Func<IngredientUnit, bool>>? filter = null)
        {
            return await _ingredientUnitRepository.GetAsync(filter);
        }

        public async Task AddIngredientUnit(IngredientUnit _ingredientUnit)
        {
            var validator = new IngredientUnitValidation();
            var validationResult = validator.Validate(_ingredientUnit);

            if (validationResult.IsValid)
            {
                return;
            }

            await this._ingredientUnitRepository.AddAsync(_ingredientUnit);
        }

        public async Task UpdateIngredientUnit(IngredientUnit _ingredientUnit)
        {
            await _ingredientUnitRepository.UpdateAsync(_ingredientUnit);
        }

        public async Task DeleteIngredientUnit(int id)
        {
            await _ingredientUnitRepository.DeleteAsync(id);
        }
    }
}