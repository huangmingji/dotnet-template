using System.Data.Common;
using System.Linq.Expressions;

namespace Lemon.App.EntityFrameworkCore.Repositories
{
    public interface IRepository
    {
        void BeginTrans();
    }

    public interface IRepository<TEntity> where TEntity : class, new()
    {
        Task<TEntity> InsertAsync(TEntity entity);

        Task<List<TEntity>> InsertAsync(List<TEntity> entities);

        Task<TEntity> UpdateAsync(TEntity entity);

        Task<List<TEntity>> UpdateAsync(List<TEntity> entities);

        Task DeleteAsync(TEntity entity);

        Task DeleteAsync(Expression<Func<TEntity, bool>> predicate);

        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate, bool withDetails = true);

        Task<TEntity?> FindAsync(Expression<Func<TEntity, bool>> predicate, bool withDetails = true);

        IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> predicate, bool withDetails = true);

        Task<List<TEntity>> FindAllAsync(bool withDetails = true);

        Task<List<TEntity>> FindListAsync(Expression<Func<TEntity, bool>> predicate, bool withDetails = true);

        Task<List<TEntity>> FindListAsync(string sql);

        Task<List<TEntity>> FindListAsync(string sql, DbParameter[] dbParameter);

        IQueryable<TEntity> WithDetails();
    }
}