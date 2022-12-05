using Lemon.App.Application.Contracts.Services;
using Lemon.Template.Application.Contracts.Account.Users.Dtos;

namespace Lemon.Template.Application.Contracts;

public interface IUserService 
    : IDefaultApplicationService<UserDataDto, long, CreateOrUpdateUserDto, GetUserPageListParamsDto>
{

}