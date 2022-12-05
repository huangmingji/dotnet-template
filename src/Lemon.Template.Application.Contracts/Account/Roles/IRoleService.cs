using Lemon.App.Application.Contracts.Services;
using Lemon.Template.Application.Contracts.Account.Roles.Dtos;

namespace Lemon.Template.Application.Contracts;

public interface IRoleService: IApplicationService<RoleDataDto, long, CreateOrUpdateRoleDto, GetRolePageListParamsDto>
{

}