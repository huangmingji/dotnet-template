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

    public class EfCoreRepository<TDbContext, TEntity, TKey> : IAppRepository<TEntity, TKey>
        where TDbContext : DbContext
        where TEntity : class, IEntity<TKey>, new()
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
            return await _repository.FindAsync(id, includeDetails);
        }

        public virtual async Task<TEntity> GetAsync(TKey id, bool includeDetails = true)
        {
            return await _repository.GetAsync(id, includeDetails);
        }

        public virtual List<TEntity> FindList(Expression<Func<TEntity, bool>> expression, int pageIndex, int pageSize, bool includeDetails = true,
                    Func<TEntity, Object> orderBy = null, Func<TEntity, Object> orderByDescending = null)
        {
            return _repository.FindList(expression, pageIndex, pageSize, includeDetails, orderBy, orderByDescending);
        }

        public virtual async Task<int> CountAsync(Expression<Func<TEntity, bool>> expression, bool includeDetails = true)
        {
            return await _repository.CountAsync(expression, includeDetails);
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

        public async Task<List<TEntity>> FindListAsync(Expression<Func<TEntity, bool>> expression, bool includeDetails = true)
        {
            return await _repository.FindListAsync(expression, includeDetails);
        }
    }
}