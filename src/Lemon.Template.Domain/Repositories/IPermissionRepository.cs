using Lemon.App.Domain.Repositories;
using Lemon.Template.Domain.Account.Roles;

namespace Lemon.Template.Domain.Repositories;

public interface IPermissionRepository : IAppRepository<PermissionData, long>
{

}