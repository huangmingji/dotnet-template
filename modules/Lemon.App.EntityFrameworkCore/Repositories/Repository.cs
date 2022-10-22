using System.Data.Common;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Lemon.Cache;
using Lemon.App.Domain.Entities;
using Lemon.App.Domain.Repositories;
using IdentityModel;

namespace Lemon.App.EntityFrameworkCore.Repositories
{
    public sealed class Repository<TDbContext, TEntity, TKey> : IRepository<TDbContext, TEntity, TKey>
        where TDbContext : DbContext
        where TEntity : class, IEntity<TKey>, new()
        where TKey : notnull
    {
        private readonly IDistributedCache _cache;
        private readonly IDbContextProvider<TDbContext> _dbContextProvider;
        private readonly DbContext _dbContext;
        public Repository(IDbContextProvider<TDbContext> dbContextProvider, IDistributedCache cache)
        {
            _cache = cache;
            _dbContextProvider = dbContextProvider;
            _dbContext = dbContextProvider.GetDbContext();
        }

        private async Task<int> SaveChangesAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(TKey id)
        {
            TEntity? entity = await this.FindAsync(id);
            if (entity != null)
            {
                _dbContext.Set<TEntity>().Attach(entity);
                _dbContext.Entry(entity).State = EntityState.Deleted;
                await _dbContext.SaveChangesAsync();
                await _cache.RemoveValueAsync(entity.Id.ToString());
            }
        }

        public async Task DeleteManyAsync(IEnumerable<TKey> ids)
        {
            List<TEntity> entities = await this.FindListAsync(x => ids.Contains(x.Id));
            foreach (var entity in entities)
            {
                _dbContext.Set<TEntity>().Attach(entity);
                _dbContext.Entry(entity).State = EntityState.Deleted;
                await _cache.RemoveValueAsync(entity.Id.ToString());
            }
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

        public async Task<IEnumerable<TEntity>> InsertAsync(IEnumerable<TEntity> entities)
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
            await this.RemoveCacheAsync(entity.Id);
            return entity;
        }

        public IQueryable<TEntity> WithDetails()
        {
            return _dbContext.Set<TEntity>();
        }

        public async Task<TEntity> GetAsync(TKey id, bool withDetails = true)
        {
            string key = $"{nameof(TEntity)}_{id}_{withDetails.ToString()}";
            TEntity result = await _cache.GetValueAsync<TEntity>(key);
            if(result != null) return result;

            if (withDetails)
            {
                result = await WithDetails().Where(x=> x.Id.Equals(id)).FirstAsync();
            } 
            else 
            {
                result = await _dbContext.Set<TEntity>().Where(x=> x.Id.Equals(id)).FirstAsync();
            }
            await _cache.SetValueAsync<TEntity>(key, result, TimeSpan.FromMinutes(10));
            return result;
        }

        public async Task<TEntity?> FindAsync(TKey id, bool withDetails = true)
        {
            string key = $"{nameof(TEntity)}_{id}_{withDetails.ToString()}";
            TEntity? result = (await _cache.GetValueAsync<TEntity>(key));
            if(result != null) return result;

            if (withDetails)
            {
                result = await WithDetails().Where(x=> x.Id.Equals(id)).FirstOrDefaultAsync();
            }
            else
            {
                result = await _dbContext.Set<TEntity>().Where(x=> x.Id.Equals(id)).FirstOrDefaultAsync();
            }
            if(result != null) await _cache.SetValueAsync<TEntity>(key, result, TimeSpan.FromMinutes(10));
            return result;
        }

        private async Task RemoveCacheAsync(TKey id)
        {
            string key1 = $"{nameof(TEntity)}_{id}_true";
            string key2 = $"{nameof(TEntity)}_{id}_false";
            await _cache.RemoveValueAsync(key1);
            await _cache.RemoveValueAsync(key2);
        }

        public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> expression, bool withDetails = true)
        {
            return await Where(expression, withDetails).AnyAsync(expression);
        }
    }
}