using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Lemon.App.Domain.Entities;
using Lemon.App.Domain.Shared.Entities;

namespace Lemon.App.Domain.Repositories
{
    public interface IRepository<TDbContext, TEntity, TKey> 
        where TDbContext : class
        where TEntity : class, IEntity<TKey>, new()
        where TKey : notnull
    {
        TDbContext GetDbContext();

        Task<TEntity> InsertAsync(TEntity entity);

        Task<List<TEntity>> InsertAsync(List<TEntity> entities);

        Task<TEntity> UpdateAsync(TEntity entity);

        Task DeleteAsync(TKey id);

        Task DeleteManyAsync(IEnumerable<TKey> ids);

        Task<int> CountAsync(Expression<Func<TEntity, bool>> expression, bool withDetails = true);

        Task<bool> AnyAsync(Expression<Func<TEntity, bool>> expression, bool withDetails = true);

        Task<TEntity> GetAsync(TKey id, bool withDetails = true);

        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate, bool withDetails = true);

        Task<TEntity?> FindAsync(TKey id, bool withDetails = true);

        Task<TEntity?> FindAsync(Expression<Func<TEntity, bool>> predicate, bool withDetails = true);

        Task<List<TEntity>> FindAllAsync(bool withDetails = true);

        Task<List<TEntity>> FindListAsync(Expression<Func<TEntity, bool>> predicate, bool withDetails = true);

        List<TEntity> FindList(Expression<Func<TEntity, bool>> expression, int pageIndex, int pageSize, bool includeDetails = true,
                    Func<TEntity, Object> orderBy = null, Func<TEntity, Object> orderByDescending = null);

        Task<List<TEntity>> FindListAsync(string sql);

        Task<List<TEntity>> FindListAsync(string sql, DbParameter[] dbParameter);
    }
}