using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vezeeta.Repo.GenericRepository
{
    public interface IBaseRepository<T> where T : class
    {
        IQueryable<T> GetQueryAll();
        IEnumerable<T> GetAll();
        T Get(int Id);
        void Insert(T entity);
        void Update(T entity);
        void Delete(int Id);
        void Remove(T entity);
        void SaveChanges();
    }
}
