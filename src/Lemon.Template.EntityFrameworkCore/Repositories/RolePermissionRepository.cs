using Lemon.App.Domain.Repositories;
using Lemon.App.EntityFrameworkCore.Repositories;
using Lemon.Template.Domain.Account.Roles;
using Lemon.Template.Domain.Repositories;

namespace Lemon.Template.EntityFrameworkCore.Repositories;

public class RolePermissionRepository : EfCoreRepository<EfDbContext, RolePermissionData, long>, IRolePermissionRepository
{
    public RolePermissionRepository(IRepository<EfDbContext, RolePermissionData, long> repository) : base(repository)
    {
    }
}