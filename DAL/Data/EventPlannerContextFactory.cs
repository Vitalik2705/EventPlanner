
namespace DAL.Data
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Design;

#pragma warning disable SA1600 // Elements should be documented
    public class EventPlannerContextFactory : IDesignTimeDbContextFactory<EventPlannerContext>
#pragma warning restore SA1600 // Elements should be documented
    {
        /// <inheritdoc/>
        public EventPlannerContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<EventPlannerContext>();

            

            optionsBuilder.UseNpgsql(
                "Host=localhost;Port=5432;Username=postgres;Password=123456;Database=EventPlanner");

            return new EventPlannerContext(optionsBuilder.Options);
        }

        //public EventPlannerContext CreateDbContext()
        //{
        //    var optionsBuilder = new DbContextOptionsBuilder<EventPlannerContext>();

        //    optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Username=postgres;Password=Yuiwerghjsdf21;Database=EventPlanner",
        //            options => options.EnableRetryOnFailure());

        //    return new EventPlannerContext(optionsBuilder.Options);
        //}

        //public EventPlannerContext CreateDbContext()
        //{
        //    var optionsBuilder = new DbContextOptionsBuilder<EventPlannerContext>();

        //    optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Username=postgres;Password=Yuiwerghjsdf21;Database=EventPlanner",
        //            options => options.EnableRetryOnFailure());

        //    return new EventPlannerContext(optionsBuilder.Options);
        //}
    }
}
