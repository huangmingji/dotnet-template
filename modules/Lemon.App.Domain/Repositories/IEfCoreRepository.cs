using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Lemon.App.Domain.Shared.Entities;

namespace Lemon.App.Domain.Repositories
{
    public interface IAppRepository<TEntity, TKey> 
        where TEntity : class, IEntity<TKey>
        where TKey : notnull
    {
        Task DeleteAsync(TKey id);

        Task DeleteManyAsync(IEnumerable<TKey> ids);

        Task<TEntity?> FindAsync(TKey id, bool includeDetails = true);

        Task<TEntity> GetAsync(TKey id, bool includeDetails = true);

        List<TEntity> FindList(Expression<Func<TEntity, bool>> expression, int pageIndex, int pageSize, bool includeDetails = true, 
                    Func<TEntity, Object> orderBy = null, Func<TEntity, Object> orderByDescending = null);

        Task<List<TEntity>> FindListAsync(Expression<Func<TEntity, bool>> expression, bool includeDetails = true);
        
        Task<int> CountAsync(Expression<Func<TEntity, bool>> expression, bool includeDetails = true);

        Task<TEntity> InsertAsync(TEntity entity);

        Task<TEntity> UpdateAsync(TEntity entity);

        Task<bool> AnyAsync(Expression<Func<TEntity, bool>> expression, bool includeDetails = true);
    }
}