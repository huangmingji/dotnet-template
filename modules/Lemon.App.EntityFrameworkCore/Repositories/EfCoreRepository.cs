using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Lemon.App.Domain.Entities;
using Lemon.App.Domain.Repositories;
using Lemon.App.Domain.Shared.Entities;
using Microsoft.EntityFrameworkCore;

namespace Lemon.App.EntityFrameworkCore.Repositories
{

    public class EfCoreRepository<TDbContext, TEntity, TKey> : IEfCoreRepository<TEntity, TKey>
        where TDbContext : DbContext
        where TEntity : class, IEntity<TKey>
        where TKey : notnull
    {
        private IRepository<TDbContext, TEntity, TKey> _repository;
        public EfCoreRepository(IRepository<TDbContext, TEntity, TKey> repository)
        {
            _repository = repository;
        }

        public virtual async Task DeleteAsync(TKey id)
        {
            await _repository.DeleteAsync(id);
        }

        public virtual async Task DeleteManyAsync(IEnumerable<TKey> ids)
        {
            await _repository.DeleteManyAsync(ids);
        }

        public virtual async Task<TEntity?> FindAsync(TKey id, bool includeDetails = true)
        {
            return await _repository.FindAsync(x => x.Id.Equals(id), includeDetails);
        }

        public virtual async Task<TEntity> GetAsync(TKey id, bool includeDetails = true)
        {
            return await _repository.GetAsync(x => x.Id.Equals(id), includeDetails);
        }

        public virtual async Task<List<TEntity>> FindListAsync(Expression<Func<TEntity, bool>> expression, int pageIndex, int pageSize, bool includeDetails = true)
        {
            return await _repository.Where(expression, includeDetails).Skip(pageSize * (pageIndex - 1)).Take(pageSize).ToListAsync();
        }

        public virtual async Task<int> CountAsync(Expression<Func<TEntity, bool>> expression, bool includeDetails = true)
        {
            return await _repository.Where(expression, includeDetails).CountAsync();
        }

        public virtual async Task<TEntity> InsertAsync(TEntity entity)
        {
            return await _repository.InsertAsync(entity);
        }

        public virtual async Task<TEntity> UpdateAsync(TEntity entity)
        {
            return await _repository.UpdateAsync(entity);
        }

        public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> expression, bool includeDetails = true)
        {
            return await _repository.AnyAsync(expression, includeDetails);
        }
    }
}