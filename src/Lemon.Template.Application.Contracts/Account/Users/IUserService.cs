using Lemon.App.Core.Services;
using Lemon.Template.Application.Contracts.Account.Users.Dtos;
using Lemon.Template.Domain.Account.Users;

namespace Lemon.Template.Application.Contracts;

public interface IUserService: IApplicationService<UserDataDto, long, CreateOrUpdateUserDto, GetUsersDto>
{

}