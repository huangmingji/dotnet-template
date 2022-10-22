using Lemon.App.Domain.Repositories;
using Lemon.App.EntityFrameworkCore.Repositories;
using Lemon.Template.Domain.Account.Roles;
using Lemon.Template.Domain.Repositories;

namespace Lemon.Template.EntityFrameworkCore.Repositories;

public class PermissionRepository : EfCoreRepository<EfDbContext, PermissionData, long>, IPermissionRepository
{
    public PermissionRepository(IRepository<EfDbContext, PermissionData, long> repository) : base(repository)
    {
    }
}