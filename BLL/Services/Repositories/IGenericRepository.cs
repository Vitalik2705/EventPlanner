using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task AddAsync(T model);
        Task UpdateAsync(T model);
        Task<T> GetAsync(Expression<Func<T, bool>>? filter = null);
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null);
        Task DeleteAsync(int id);
        Task SaveAsync();
    }
}
