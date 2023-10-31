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
        Task<Recipe> GetByIdAsync(int id);
    }
}
