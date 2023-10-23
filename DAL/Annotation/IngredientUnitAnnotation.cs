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
            ModelBuilder.Property(u => u.Ingredient).IsRequired();
            ModelBuilder.Property(u => u.Unit).IsRequired();
            ModelBuilder.Property(u => u.Amount).IsRequired();
        }
    }
}
