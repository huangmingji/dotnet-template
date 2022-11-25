using System;
using Lemon.App.SqlSugar;

namespace Lemon.App.EntityFrameworkCore
{
    public interface IDbContextProvider<out TDbContext> : IDisposable where TDbContext : DbContext
    {
        TDbContext GetDbContext();
    }
}