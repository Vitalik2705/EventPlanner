// <copyright file="GuestAnnotation.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace DAL.Annotation
{
    using DAL.Models;
    using Microsoft.EntityFrameworkCore;

    internal class GuestAnnotation : BaseEntityAnnotation<Guest>
    {
        internal GuestAnnotation(ModelBuilder builder)
            : base(builder)
        {
        }

        public override void Annotate()
        {
            this.ModelBuilder.HasKey(u => u.GuestId);
            this.ModelBuilder.Property(u => u.GuestId).ValueGeneratedOnAdd().UseIdentityColumn().HasColumnName("guest_id");
            this.ModelBuilder.Property(u => u.Surname).IsRequired().HasMaxLength(20).HasColumnName("surname");
            this.ModelBuilder.Property(u => u.Name).IsRequired().HasMaxLength(20).HasColumnName("name");
            this.ModelBuilder.Property(u => u.Gender).IsRequired().HasConversion<string>().HasColumnName("gender");
        }
    }
}
