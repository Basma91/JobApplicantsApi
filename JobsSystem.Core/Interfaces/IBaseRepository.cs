using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace JobsSystem.Core.Interfaces
{
   public interface IBaseRepository<T> where T:class
    {
       Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> criteria);
        public  Task<T> FindAsync(Expression<Func<T, bool>> criteria, string[] includes = null);
        Task<T> GetByIdAsync(int Id);

        Task<T> AddAsync(T entity);
        void   Delete(T entity);
        T Update(T entity);

        Task<int> CountAsync();
        Task<int> CountAsync(Expression<Func<T, bool>> criteria);


    }
}
