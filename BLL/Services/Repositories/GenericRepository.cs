using DAL.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
        async public Task AddAsync(T model)
        {
            await _table.AddAsync(model);
            await SaveAsync();
        }

        async public Task DeleteAsync(int id)
        {
            T existing = await _table.FindAsync(id);
            _table.Remove(existing);
            await SaveAsync();
        }

        async public Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>>? fillter = null)
        {
            IQueryable<T> query = this._table;
            if (fillter != null)
            {
                query.Where(fillter);
            }

            return await query.ToListAsync();
        }

        async public Task<T> GetAsync(Expression<Func<T, bool>>? fillter = null)
        {
            IQueryable<T> query = _table;
            if(fillter != null)
            {
                query.Where(fillter);
            }

            return await query.FirstOrDefaultAsync();
        }

        async public Task UpdateAsync(T model)
        {
            _table.Attach(model);
            _context.Entry(model).State = EntityState.Modified;
            await SaveAsync();
        }
        async public Task SaveAsync()
        {
            await _context.SaveChangesAsync();
            
        }
    }
}
