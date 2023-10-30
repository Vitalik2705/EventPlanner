using DAL.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.RepositoryPattern
{
    //The following GenericRepository class Implement the IGenericRepository Interface
    //And Here T is going to be a class
    //While Creating an Instance of the GenericRepository type, we need to specify the Class Name
    //That is we need to specify the actual class name of the type T
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private EventPlannerContext _context;
        private DbSet<T> table;
        private readonly IDesignTimeDbContextFactory<EventPlannerContext> _contextFactory;

        public GenericRepository(IDesignTimeDbContextFactory<EventPlannerContext> contextFactory)
        {
            _contextFactory = contextFactory;
            _context = _contextFactory.CreateDbContext(new string[0]);
            table = _context.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return table;
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
