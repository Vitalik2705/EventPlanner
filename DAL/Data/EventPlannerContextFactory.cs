// <copyright file="EventPlannerContextFactory.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace DAL.Data
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Design;

    public class EventPlannerContextFactory : IDesignTimeDbContextFactory<EventPlannerContext>
#pragma warning restore SA1600 // Elements should be documented
    {
        /// <inheritdoc/>
        public EventPlannerContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<EventPlannerContext>();

            optionsBuilder.UseNpgsql(
                "Host=localhost;Port=5432;Username=postgres;Password=123456;Database=EventPlanner1");

            return new EventPlannerContext(optionsBuilder.Options);
        }
    }
}
