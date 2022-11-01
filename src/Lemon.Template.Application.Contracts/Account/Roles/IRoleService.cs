using Lemon.App.Application.Contracts.Services;
using Lemon.Template.Application.Contracts.Account.Roles.Dtos;
using Lemon.Template.Domain.Account.Roles;

namespace Lemon.Template.Application.Contracts;

public interface IRoleService: IApplicationService<RoleData, long, CreateOrUpdateRoleDto, GetRolesDto>
{

}