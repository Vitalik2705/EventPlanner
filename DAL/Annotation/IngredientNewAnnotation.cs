// <copyright file="IngredientNewAnnotation.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace DAL.Annotation
{
    using DAL.Models;
    using Microsoft.EntityFrameworkCore;

    internal class IngredientNewAnnotation : BaseEntityAnnotation<IngredientNew>
    {
        internal IngredientNewAnnotation(ModelBuilder builder)
            : base(builder)
        {
        }

        public override void Annotate()
        {
            this.ModelBuilder.HasKey(u => u.IngredientNewId);
            this.ModelBuilder.Property(u => u.IngredientNewId).ValueGeneratedOnAdd().UseIdentityColumn().HasColumnName("ingredient_new_id");
            this.ModelBuilder.Property(u => u.Name).IsRequired().HasMaxLength(20).HasColumnName("name");
        }
    }
}
