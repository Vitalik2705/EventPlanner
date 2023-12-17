using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class IngredientUnitRecipe
    {
        public int IngredientUnitRecipeId { get; set; }

        public IngredientUnit IngredientUnit { get; set; }

        public int IngredientUnitId { get; set; }

        public Recipe Recipe { get; set; }

        public int RecipeId { get; set; }
    }
}
