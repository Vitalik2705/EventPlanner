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

        /// <inheritdoc/>
        public async Task AddAsync(T model)
        {
            await this._table.AddAsync(model);
            await SaveAsync();
        }

        /// <inheritdoc/>
        async public Task DeleteAsync(int id)
        {
            T existing = await this._table.FindAsync(id);
            _table.Remove(existing);
            await SaveAsync();
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>>? fillter = null)
        {
            IQueryable<T> query = this._table;
            if (fillter != null)
            {
                query = query.Where(fillter);
            }

            return await query.ToListAsync();
        }

        /// <inheritdoc/>
        public async Task<T> GetAsync(Expression<Func<T, bool>>? fillter = null)
        {
            IQueryable<T> query = this._table;

            if (fillter != null)
            {
                query = query.Where(fillter);
            }

            var instance = await query.FirstOrDefaultAsync();
            this._context.Attach(instance);

            return instance;
        }

        /// <inheritdoc/>
        public async Task UpdateAsync(T model)
        {
            this._table.Attach(model);
            this._context.Entry(model).State = EntityState.Modified;
            await this.SaveAsync();
        }

        /// <inheritdoc/>
        public async Task SaveAsync()
        {
            await this._context.SaveChangesAsync();
        }
    }
}
