using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Class_API.Repositories
{
    public interface IBaseRepository<T>
    {
        Task<List<T>> GetAll(params Expression<Func<T, object>>[] includes);
        Task<T> Get(int id, params Expression<Func<T, object>>[] includes);

        Task<T> Add(T entity);
        Task<T> Update(T entity);   
        Task<T> Delete(int id);      


    }
}
