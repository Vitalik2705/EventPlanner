using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class IngredientUnit
    {
        public Ingredient Ingredient { get; set; }

        public Unit Unit { get; set; }

        public int Amount { get; set; }
    }
}
