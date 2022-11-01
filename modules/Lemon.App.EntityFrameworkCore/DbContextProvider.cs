using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Lemon.App.EntityFrameworkCore
{
    public class DbContextProvider<TDbContext> : IDbContextProvider<TDbContext> where TDbContext : DbContext
    {
        private readonly IDbContextFactory<TDbContext> _contextFactory;
        public DbContextProvider(IDbContextFactory<TDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        [ThreadStatic]
        private TDbContext? _dbContext;
        [ThreadStatic]
        private IDbContextTransaction? _dbContextTransaction;
        
        public TDbContext GetDbContext()
        {
            return _dbContext ??= _contextFactory.CreateDbContext();
        }

        public void BeginTrans()
        {
            _dbContextTransaction ??= GetDbContext().Database.BeginTransaction();
        }

        public void Dispose()
        {
            try
            {
                if (_dbContextTransaction != null)
                {
                    _dbContextTransaction.Commit();
                }
            }
            catch (Exception ex)
            {
                if (_dbContextTransaction != null)
                {
                    _dbContextTransaction.Rollback();
                }
                throw;
            }
            finally
            {
                _dbContextTransaction?.Dispose();
                _dbContext?.Dispose();
            }
        }
    }
}