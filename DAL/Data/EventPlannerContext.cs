using DAL.Annotation;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Data
{
    public class EventPlannerContext : DbContext
    {

        private readonly IConfiguration _configuration;

        public EventPlannerContext(DbContextOptions<EventPlannerContext> options)
            : base(options)
        {
            Database.Migrate();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql(_configuration.GetConnectionString("EventPlannerDbConnectionString"));
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
