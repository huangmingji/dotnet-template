using Lemon.App.Domain.Repositories;
using Lemon.App.EntityFrameworkCore.Repositories;
using Lemon.Template.Domain.Account.Roles;
using Lemon.Template.Domain.Repositories;

namespace Lemon.Template.EntityFrameworkCore.Repositories;

public class RoleRepository : EfCoreRepository<EfDbContext, RoleData, long>, IRoleRepository
{
    public RoleRepository(IRepository<EfDbContext, RoleData, long> repository) : base(repository)
    {
    }
}