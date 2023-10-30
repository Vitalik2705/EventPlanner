using DAL.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private EventPlannerContext _context;
        private DbSet<T> _table;

        public GenericRepository(EventPlannerContext _context)
        {
            this._context = _context;
            _table = _context.Set<T>();
        }
        public void Add(T model)
        {
            _table.Add(model);
        }

        public void Delete(int id)
        {
            T existing = _table.Find(id);
            _table.Remove(existing);
        }

        public IEnumerable<T> GetAll()
        {
            return _table.ToList();
        }

        public T GetById(int id)
        {
            return _table.Find(id);
        }

        public void Update(T model)
        {
            _table.Attach(model);
            _context.Entry(model).State = EntityState.Modified;
        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
