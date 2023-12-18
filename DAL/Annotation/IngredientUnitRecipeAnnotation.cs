using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Annotation
{
    internal class IngredientUnitRecipeAnnotation : BaseEntityAnnotation<IngredientUnitRecipe>
    {
        internal IngredientUnitRecipeAnnotation(ModelBuilder builder)
            : base(builder)
        {
        }

        public override void Annotate()
        {
            this.ModelBuilder.HasKey(u => u.IngredientUnitRecipeId);
            this.ModelBuilder.Property(u => u.IngredientUnitRecipeId).ValueGeneratedOnAdd().UseIdentityColumn().HasColumnName("ingredient_unit_recipe_id");
            this.ModelBuilder.HasOne(u => u.IngredientUnit).WithMany(u => u.IngredientUnitRecipes).HasForeignKey(u => u.IngredientUnitId);
            this.ModelBuilder.HasOne(u => u.Recipe).WithMany(u => u.IngredientsUnitsRecipe).HasForeignKey(u => u.RecipeId);
        }
    }
}