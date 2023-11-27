// <copyright file="IngredientUnitAnnotation.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace DAL.Annotation
{
    using DAL.Models;
    using Microsoft.EntityFrameworkCore;

    internal class IngredientUnitAnnotation : BaseEntityAnnotation<IngredientUnit>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IngredientUnitAnnotation"/> class.
        /// </summary>
        /// <param name="builder"></param>
        internal IngredientUnitAnnotation(ModelBuilder builder)
            : base(builder)
        {
        }

        public override void Annotate()
        {
            this.ModelBuilder.HasKey(u => u.IngredientUnitId);
            this.ModelBuilder.Property(u => u.IngredientUnitId).ValueGeneratedOnAdd().UseIdentityColumn().HasColumnName("ingredient_unit_id");
            this.ModelBuilder.Property(u => u.Ingredient).HasConversion<string>().HasColumnName("ingredient");
            this.ModelBuilder.Property(u => u.Unit).HasConversion<string>().HasColumnName("unit");
        }
    }
}
