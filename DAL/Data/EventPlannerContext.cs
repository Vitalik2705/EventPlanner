// <copyright file="EventPlannerContext.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace DAL.Data
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
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
                //var connectionString = this._configuration?.GetConnectionString("Host=localhost;Port=5432;Username=postgres;Password=Yuiwerghjsdf21;Database=EventPlanner");
                //if (connectionString != null)
                //{
                    optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Username=postgres;Password=Yuiwerghjsdf21;Database=EventPlanner");
                //}
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

            //modelBuilder.Entity<User>().HasData(
            //    new User
            //    {
            //        Surname = "Сальнікова",
            //        Name = "Божена",
            //        PhoneNumber = "8432652",
            //        Email = "1111",
            //        Password = "1111",
            //        Events = new List<Event>(),
            //        Gender = Gender.Female,
            //        CreatedDate = DateTime.UtcNow,
            //        ModifiedDate = DateTime.UtcNow,
            //        UserImage = new byte[6],
            //    });
        }

        public DbSet<User> User { get; set; }

        public DbSet<Recipe> Recipe { get; set; }

        public DbSet<Guest> Guest { get; set; }

        public DbSet<IngredientUnit> IngredientUnit { get; set; }

        public DbSet<Event> Event { get; set; }
    }
}
