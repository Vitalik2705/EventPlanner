using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class IngredientUnit
    {
        public int IngredientUnitId { get; set; }
        public Ingredient Ingredient { get; set; }

        public Unit Unit { get; set; }

        public int Amount { get; set; }

        public ICollection<Recipe> Recipes { get; set; }
    }
}
