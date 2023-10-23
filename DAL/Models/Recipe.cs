using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Recipe
    {
        public int RecipeId { get; set; }

        public string Name { get; set; }

        public int Calories { get; set; }

        public int CookingTime { get; set; }

        public ICollection<IngredientUnit> IngredientsUnits { get; set;}

        public ICollection<Event> Events { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }
    }
}
