using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using XebecAPI.Shared;

namespace XebecAPI.IRepositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IList<T>> GetAll(Expression<Func<T, bool>> expression = null);

        Task<T> GetT(Expression<Func<T, bool>> expression);

        Task Insert(T entity);

        Task Delete(int id);

        void Update(T Entity);

        Task InsertRange(IEnumerable<T> Entities);
    }
}