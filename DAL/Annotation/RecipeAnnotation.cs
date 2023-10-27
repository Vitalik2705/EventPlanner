using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Annotation
{
    internal class RecipeAnnotation : BaseEntityAnnotation<Recipe>
    {
        internal RecipeAnnotation(ModelBuilder builder)
            : base(builder)
        {

        }

        public override void Annotate()
        {
            ModelBuilder.HasKey(u => u.RecipeId);
            ModelBuilder.Property(u => u.RecipeId).ValueGeneratedOnAdd().UseIdentityColumn().HasColumnName("recipe_id");
            ModelBuilder.Property(u => u.Name).IsRequired().HasMaxLength(20).HasColumnName("name");
            ModelBuilder.Property(u => u.Calories).IsRequired().HasColumnName("calories");
            ModelBuilder.HasMany(u => u.Events).WithMany(u => u.Recipes);
            ModelBuilder.Property(u => u.CookingTime).IsRequired().HasColumnName("cooking_time");
            ModelBuilder.Property(u => u.CreatedDate).IsRequired().HasColumnName("created_date");
            ModelBuilder.Property(u => u.ModifiedDate).HasColumnName("modified_date");
            ModelBuilder.HasMany(u => u.IngredientsUnits).WithMany(u => u.Recipes);
            ModelBuilder.Property(u => u.RecipeImage).HasColumnName("recipe_image");
        }
    }
}
