using System.Data.Common;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace Lemon.App.EntityFrameworkCore.Repositories
{
    public class Repository : IRepository
    {
        private readonly IDbContextProvider<DbContext> _dbContextProvider;
        public Repository(IDbContextProvider<DbContext> dbContextProvider)
        {
            _dbContextProvider = dbContextProvider;
        }

        public void BeginTrans()
        {
            _dbContextProvider.BeginTrans();
        }
    }

    public sealed class Repository<TEntity> : IRepository<TEntity> where TEntity : class, new()
    {
        private readonly IDbContextProvider<DbContext> _dbContextProvider;
        private readonly DbContext _dbContext;
        public Repository(IDbContextProvider<DbContext> dbContextProvider)
        {
            _dbContextProvider = dbContextProvider;
            _dbContext = dbContextProvider.GetDbContext();
        }

        private async Task<int> SaveChangesAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(TEntity entity)
        {
            _dbContext.Set<TEntity>().Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Deleted;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Expression<Func<TEntity, bool>> predicate)
        {
            var entities = _dbContext.Set<TEntity>().Where(predicate).ToList();
            entities.ForEach(m => _dbContext.Entry(m).State = EntityState.Deleted);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate, bool withDetails = true)
        {
            if (withDetails)
            {
                return await WithDetails().Where(predicate).FirstAsync();
            }
            return await _dbContext.Set<TEntity>().Where(predicate).FirstAsync();
        }

        public async Task<List<TEntity>> FindAllAsync(bool withDetails = true)
        {
            if (withDetails)
            {
                return await WithDetails().ToListAsync();
            }
            return await _dbContext.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity?> FindAsync(Expression<Func<TEntity, bool>> predicate, bool withDetails = true)
        {
            if (withDetails)
            {
                return await WithDetails().Where(predicate).FirstOrDefaultAsync();
            }
            return await _dbContext.Set<TEntity>().Where(predicate).FirstOrDefaultAsync();
        }
        
        public async Task<List<TEntity>> FindListAsync(Expression<Func<TEntity, bool>> predicate, bool withDetails = true)
        {
            if (withDetails)
            {
                return await WithDetails().Where(predicate).ToListAsync();
            }
            return await _dbContext.Set<TEntity>().Where(predicate).ToListAsync();
        }

        public async Task<List<TEntity>> FindListAsync(string sql)
        {
            return await _dbContext.Set<TEntity>().FromSqlRaw(sql).ToListAsync();
        }

        public async Task<List<TEntity>> FindListAsync(string sql, DbParameter[] dbParameter)
        {
            return await _dbContext.Set<TEntity>().FromSqlRaw(sql, dbParameter).ToListAsync();
        }

        public async Task<TEntity> InsertAsync(TEntity entity)
        {
            _dbContext.Entry(entity).State = EntityState.Added;
            var result = await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<List<TEntity>> InsertAsync(List<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                _dbContext.Entry(entity).State = EntityState.Added;
            }
            var result = await _dbContext.SaveChangesAsync();
            return entities;
        }

        public IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> predicate, bool withDetails = true)
        {
            if (withDetails)
            {
                return WithDetails().Where(predicate);
            }

            return _dbContext.Set<TEntity>().Where(predicate);
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            var result = await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<List<TEntity>> UpdateAsync(List<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                _dbContext.Entry(entity).State = EntityState.Modified;
            }
            var result = await _dbContext.SaveChangesAsync();
            return entities;
        }

        public IQueryable<TEntity> WithDetails()
        {
            return _dbContext.Set<TEntity>();
        }
    }
}