using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        void Add(T model);
        void Update(T model);
        T GetById(int id);
        IEnumerable<T> GetAll();
        void Delete(int id);
        void Save();
    }
}
