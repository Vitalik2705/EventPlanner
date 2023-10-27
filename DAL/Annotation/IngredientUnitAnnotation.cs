using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Annotation
{
    internal class IngredientUnitAnnotation : BaseEntityAnnotation<IngredientUnit>
    {
        internal IngredientUnitAnnotation(ModelBuilder builder)
            : base(builder)
        {

        }

        public override void Annotate()
        {
            ModelBuilder.HasKey(u => u.IngredientUnitId);
            ModelBuilder.Property(u => u.IngredientUnitId).ValueGeneratedOnAdd().UseIdentityColumn().HasColumnName("ingredient_unit_id");
            ModelBuilder.Property(u => u.Ingredient).HasConversion<string>().HasColumnName("ingredient");
            ModelBuilder.Property(u => u.Unit).HasConversion<string>().HasColumnName("unit");
        }
    }
}
