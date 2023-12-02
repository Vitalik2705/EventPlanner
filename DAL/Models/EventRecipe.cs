using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class EventRecipe
    {
        public int EventRecipeId { get; set; }

        public Event Event { get; set; }

        public int EventId { get; set; }

        public Recipe Recipe { get; set; }

        public int RecipeId { get; set; }
    }
}
