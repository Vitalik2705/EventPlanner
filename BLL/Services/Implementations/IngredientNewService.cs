using BLL.Services.Interfaces;
using BLL.Services.Repositories;
using BLL.Validation;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Implementations
{
    public class IngredientNewService : IIngredientNewService
    {
        private IGenericRepository<IngredientNew> _ingredientNewRepository;
        public IngredientNewService(IGenericRepository<IngredientNew> repository)
        {
            _ingredientNewRepository = repository;
        }
        public async Task AddIngredientNew(IngredientNew _ingredientNew)
        {
            await this._ingredientNewRepository.AddAsync(_ingredientNew);
        }

    }
}
