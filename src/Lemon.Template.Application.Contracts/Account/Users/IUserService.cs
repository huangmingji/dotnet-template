using Lemon.App.Application.Contracts.Services;
using Lemon.Template.Application.Contracts.Account.Users.Dtos;
using Lemon.Template.Domain.Account.Users;

namespace Lemon.Template.Application.Contracts;

public interface IUserService: IDefaultApplicationService<UserData, UserDataDto, long, CreateOrUpdateUserDto, GetUsersDto>
{

}