using System;
using Microsoft.EntityFrameworkCore;

namespace Lemon.App.EntityFrameworkCore
{
    public interface IDbContextProvider<out TDbContext> : IDisposable where TDbContext : DbContext
    {
        TDbContext GetDbContext();

        void BeginTrans();
    }
}