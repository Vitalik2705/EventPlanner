﻿using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Interfaces
{
    public interface IIngredientNewService
    {
        Task AddIngredientNew(IngredientNew _ingredientNew);
    }
}
