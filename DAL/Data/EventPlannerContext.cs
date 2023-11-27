// <copyright file="EventPlannerContext.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace DAL.Data
{
    using System.Collections.Generic;
    using DAL.Annotation;
    using DAL.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;

    public class EventPlannerContext : DbContext
    {
        private readonly IConfiguration? _configuration;

        public EventPlannerContext(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        public EventPlannerContext(DbContextOptions<EventPlannerContext> options)
            : base(options)
        {
           // this.Database.Migrate();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Username=postgres;Password=Yuiwerghjsdf21;Database=EventPlanner");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var annotationCollection = new List<IEntityAnnotation>
            {
                new UserAnnotation(modelBuilder),
                new RecipeAnnotation(modelBuilder),
                new GuestAnnotation(modelBuilder),
                new IngredientUnitAnnotation(modelBuilder),
                new EventAnnotation(modelBuilder),
            };
            foreach (var annotation in annotationCollection)
            {
                annotation.Annotate();
            }
        }

        public DbSet<User> User { get; set; }

        public DbSet<Recipe> Recipe { get; set; }

        public DbSet<Guest> Guest { get; set; }

        public DbSet<IngredientUnit> IngredientUnit { get; set; }

        public DbSet<Event> Event { get; set; }
    }
}
