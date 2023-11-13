﻿// <copyright file="EventPlannerContextFactory.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace DAL.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Design;

    public class EventPlannerContextFactory : IDesignTimeDbContextFactory<EventPlannerContext>
    {
        public EventPlannerContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<EventPlannerContext>();

            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Username=postgres;Password=Yuiwerghjsdf21;Database=EventPlanner",
                    options => options.EnableRetryOnFailure());

            return new EventPlannerContext(optionsBuilder.Options);
        }
    }
}
