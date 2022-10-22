using System.Linq.Expressions;
using Lemon.App.Domain.Entities;

namespace Lemon.App.Domain.Repositories
{
    public interface IEfCoreRepository<TEntity, TKey> 
        where TEntity : class, IEntity<TKey>, new()
        where TKey : notnull
    {
        Task DeleteAsync(TKey id);

        Task DeleteManyAsync(IEnumerable<TKey> ids);

        Task<TEntity?> FindAsync(TKey id, bool includeDetails = true);

        Task<TEntity> GetAsync(TKey id, bool includeDetails = true);

        Task<List<TEntity>> FindListAsync(Expression<Func<TEntity, bool>> expression, int pageIndex, int pageSize, bool includeDetails = true);
        
        Task<int> CountAsync(Expression<Func<TEntity, bool>> expression, bool includeDetails = true);

        Task<TEntity> InsertAsync(TEntity entity);

        Task<TEntity> UpdateAsync(TEntity entity);

        Task<bool> AnyAsync(Expression<Func<TEntity, bool>> expression, bool includeDetails = true);
    }
}