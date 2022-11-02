using System.Linq.Expressions;

namespace ParkMap.DataAccess.Repositories
{
    public interface IRepo<T>
    {
        Task<IQueryable<T>> FindAllAsync(bool trackChanges);
        Task<IQueryable<T>> FindByConditionAsync(
            Expression<Func<T, bool>> expression,
            bool trackChanges
            );
        Task CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
