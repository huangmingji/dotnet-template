using Lemon.App.Domain.Repositories;
using Lemon.App.EntityFrameworkCore.Repositories;
using Lemon.Template.Domain.Account.Users;
using Lemon.Template.Domain.Repositories;

namespace Lemon.Template.EntityFrameworkCore.Repositories;

public class UserRepository : EfCoreRepository<EfDbContext, UserData, long>, IUserRepository
{
    public UserRepository(IRepository<EfDbContext, UserData, long> repository) : base(repository)
    {
    }
}
