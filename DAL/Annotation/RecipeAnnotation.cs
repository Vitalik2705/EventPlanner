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
            ModelBuilder.Property(u => u.Name).IsRequired().HasMaxLength(20);
            ModelBuilder.Property(u => u.Calories).IsRequired();
            ModelBuilder.HasMany(u => u.Events).WithMany(u => u.Recipes);
            ModelBuilder.Property(u => u.CookingTime).IsRequired();
            ModelBuilder.Property(u => u.CreatedDate).IsRequired();
            ModelBuilder.Property(u => u.ModifiedDate);
            ModelBuilder.HasMany(u => u.IngredientsUnits).WithMany(u => u.Recipes);
        }
    }
}
