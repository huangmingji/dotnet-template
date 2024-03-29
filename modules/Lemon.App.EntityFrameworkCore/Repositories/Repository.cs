using System.Data.Common;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Lemon.App.Domain.Entities;
using Lemon.App.Domain.Repositories;
using Lemon.App.Core.Cache;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;
using System.Linq;
using Lemon.App.Domain.Shared.Entities;
using Lemon.App.Core.ExceptionExtensions;

namespace Lemon.App.EntityFrameworkCore.Repositories
{
    public sealed class Repository<TDbContext, TEntity, TKey> : IRepository<TDbContext, TEntity, TKey>
        where TDbContext : DbContext
        where TEntity : class, IEntity<TKey>, new()
        where TKey : notnull
    {
        private readonly IDbContextProvider<TDbContext> _dbContextProvider;
        private readonly DbContext _dbContext;
        public Repository(IDbContextProvider<TDbContext> dbContextProvider)
        {
            _dbContextProvider = dbContextProvider;
            _dbContext = dbContextProvider.GetDbContext();
        }


        public TDbContext GetDbContext()
        {
            return _dbContextProvider.GetDbContext();
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
            }
        }

        public async Task DeleteManyAsync(IEnumerable<TKey> ids)
        {
            List<TEntity> entities = await this.FindListAsync(x => ids.Contains(x.Id));
            foreach (var entity in entities)
            {
                _dbContext.Set<TEntity>().Attach(entity);
                _dbContext.Entry(entity).State = EntityState.Deleted;
            }
            await _dbContext.SaveChangesAsync();
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate, bool withDetails = true)
        {
            IQueryable<TEntity> queryable = withDetails ? WithDetails() : _dbContext.Set<TEntity>();
            var data = await _dbContext.Set<TEntity>().Where(predicate).FirstOrDefaultAsync();
            if (data == null)
            {
                throw new EntityNotFoundException();
            }
            return data;
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

        public List<TEntity> FindList(Expression<Func<TEntity, bool>> expression, int pageIndex, int pageSize, bool includeDetails = true,
                    Func<TEntity, Object> orderBy = null, Func<TEntity, Object> orderByDescending = null)
        {
            IEnumerable<TEntity> queryable = this.Where(expression, includeDetails);
            if (orderBy != null)
            {
                queryable = queryable.OrderBy(orderBy);
            }
            if (orderByDescending != null)
            {
                queryable = queryable.OrderByDescending(orderByDescending);
            }
            return queryable.Skip(pageSize * (pageIndex - 1)).Take(pageSize).ToList();
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

        public IQueryable<TEntity> WithDetails()
        {
            return _dbContext.Set<TEntity>();
        }

        public async Task<TEntity> GetAsync(TKey id, bool withDetails = true)
        {
            IQueryable<TEntity> queryable = withDetails ? WithDetails() : _dbContext.Set<TEntity>();
            var data = await _dbContext.Set<TEntity>().Where(x => x.Id.Equals(id)).FirstOrDefaultAsync();
            if (data == null)
            {
                throw new EntityNotFoundException();
            }
            return data;
        }

        public async Task<TEntity?> FindAsync(TKey id, bool withDetails = true)
        {
            IQueryable<TEntity> entities;
            if (withDetails)
            {
                entities = WithDetails();
            }
            else
            {
                entities = _dbContext.Set<TEntity>();
            }
            return await entities.Where(x => x.Id.Equals(id)).FirstOrDefaultAsync();
        }

        public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> expression, bool withDetails = true)
        {
            return await Where(expression, withDetails).AnyAsync(expression);
        }

        public async Task<int> CountAsync(Expression<Func<TEntity, bool>> expression, bool withDetails = true)
        {
            return await Where(expression, withDetails).CountAsync();
        }
    }
}