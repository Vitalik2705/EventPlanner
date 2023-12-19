// <copyright file="EventAnnotation.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace DAL.Annotation
{
    using DAL.Models;
    using Microsoft.EntityFrameworkCore;

    public class EventAnnotation : BaseEntityAnnotation<Event>
    {
        public EventAnnotation(ModelBuilder builder)
            : base(builder)
        {
        }

        public override void Annotate()
        {
            this.ModelBuilder.HasKey(u => u.EventId);
            this.ModelBuilder.Property(u => u.EventId).ValueGeneratedOnAdd().UseIdentityColumn().HasColumnName("event_id");
            this.ModelBuilder.Property(u => u.Name).IsRequired().HasMaxLength(40).HasColumnName("name");
            this.ModelBuilder.Property(u => u.CreatedDate).IsRequired().HasColumnName("created_date");
            this.ModelBuilder.Property(u => u.ModifiedDate).HasColumnName("modified_date");
        }
    }
}
