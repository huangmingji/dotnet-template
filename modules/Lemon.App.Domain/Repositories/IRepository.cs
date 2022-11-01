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
        where TEntity : class, IEntity<TKey>
        where TKey : notnull
    {
        Task<TEntity> InsertAsync(TEntity entity);

        Task<IEnumerable<TEntity>> InsertAsync(IEnumerable<TEntity> entities);

        Task<TEntity> UpdateAsync(TEntity entity);

        Task DeleteAsync(TKey id);

        Task DeleteManyAsync(IEnumerable<TKey> ids);

        Task<bool> AnyAsync(Expression<Func<TEntity, bool>> expression, bool withDetails = true);

        Task<TEntity> GetAsync(TKey id, bool withDetails = true);

        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate, bool withDetails = true);

        Task<TEntity?> FindAsync(TKey id, bool withDetails = true);

        Task<TEntity?> FindAsync(Expression<Func<TEntity, bool>> predicate, bool withDetails = true);

        IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> predicate, bool withDetails = true);

        Task<List<TEntity>> FindAllAsync(bool withDetails = true);

        Task<List<TEntity>> FindListAsync(Expression<Func<TEntity, bool>> predicate, bool withDetails = true);

        Task<List<TEntity>> FindListAsync(string sql);

        Task<List<TEntity>> FindListAsync(string sql, DbParameter[] dbParameter);
    }
}