using Lemon.App.Domain.Repositories;
using Lemon.Template.Domain.Account.Users;

namespace Lemon.Template.Domain.Repositories;

public interface IUserRepository : IEfCoreRepository<UserData, long>
{

}
