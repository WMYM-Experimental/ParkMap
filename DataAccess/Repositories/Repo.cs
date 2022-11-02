using Microsoft.EntityFrameworkCore;
using ParkMap.Areas.Identity.Data;
using System.Linq.Expressions;

namespace ParkMap.DataAccess.Repositories
{
    public abstract class Repo<T> : IRepo<T> where T : class
    {
        protected ParkMapContext _context;
        public Repo (ParkMapContext context)
        {
            _context = context;
        }

        public async Task<IQueryable<T>> FindAllAsync(bool trackChanges)
            => !trackChanges ? await Task.Run(
                () => _context.Set<T>().AsNoTracking()) : await Task.Run(() => _context.Set<T>()
                );

        public async Task<IQueryable<T>> FindByConditionAsync(Expression<Func<T, bool>> expression, bool trackChanges)
            => !trackChanges ? await Task.Run(
                () => _context.Set<T>().Where(expression).AsNoTracking()) : await Task.Run(() => _context.Set<T>().Where(expression)
                );

        public async Task CreateAsync(T entity)
            => await Task.Run(
                () => _context.Set<T>().Add(entity)
                );

        public async Task UpdateAsync(T entity)
            => await Task.Run(
                () => _context.Set<T>().Update(entity)
                );

        public async Task DeleteAsync(T entity)
            => await Task.Run(
                () => _context.Set<T>().Remove(entity)
                );
    }
}
