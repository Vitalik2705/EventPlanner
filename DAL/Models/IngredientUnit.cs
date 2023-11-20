// <copyright file="IngredientUnit.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

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
