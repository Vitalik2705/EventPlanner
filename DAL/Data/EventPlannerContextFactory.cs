using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Data
{
    public class EventPlannerContextFactory : IDesignTimeDbContextFactory<EventPlannerContext>
    {
        public EventPlannerContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<EventPlannerContext>();

            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Username=postgres;Password=vitalik;Database=EventPlanner",
                    options => options.EnableRetryOnFailure());

            return new EventPlannerContext(optionsBuilder.Options);
        }
    }
}
