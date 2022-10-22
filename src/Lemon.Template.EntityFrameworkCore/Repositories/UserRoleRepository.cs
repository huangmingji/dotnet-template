using Lemon.App.Domain.Repositories;
using Lemon.App.EntityFrameworkCore.Repositories;
using Lemon.Template.Domain.Account.Users;
using Lemon.Template.Domain.Repositories;

namespace Lemon.Template.EntityFrameworkCore.Repositories;

public class UserRoleRepository : EfCoreRepository<EfDbContext, UserRole, long>, IUserRoleRepository
{
    public UserRoleRepository(IRepository<EfDbContext, UserRole, long> repository) : base(repository)
    {
    }
}
