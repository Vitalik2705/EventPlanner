// <copyright file="Recipe.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace DAL.Models
{
    public class Recipe
    {
        public int RecipeId { get; set; }

        public string Name { get; set; }

        public int Calories { get; set; }

        public int CookingTime { get; set; }

        public string Description { get; set; }

        public ICollection<IngredientUnitRecipe> IngredientsUnitsRecipe { get; set;}

        public ICollection<EventRecipe> RecipeEvents { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public string? RecipeImageName { get; set; }
    }
}
