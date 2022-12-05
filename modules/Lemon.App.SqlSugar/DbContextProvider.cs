using System;
using System.Data;
using Lemon.App.EntityFrameworkCore;
using SqlSugar;

namespace Lemon.App.SqlSugar
{
    public class DbContextProvider<TDbContext> : IDbContextProvider<TDbContext> where TDbContext : DbContext
    {
        private readonly TDbContext _dbContext;
        public DbContextProvider(TDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public TDbContext GetDbContext()
        {
            return _dbContext;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}

