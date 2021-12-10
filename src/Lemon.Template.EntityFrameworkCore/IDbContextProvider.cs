using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Lemon.Template.EntityFrameworkCore
{
    public interface IDbContextProvider<out TDbContext> : IDisposable where TDbContext : DbContext
    {
        TDbContext GetDbContext();

        void BeginTrans();
    }
}