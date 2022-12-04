using System;
using System.Linq.Expressions;
using Lemon.Template.Application.Contracts;
using Lemon.Template.Application.Contracts.Account.Users.Dtos;
using Lemon.Template.Domain.Account.Users;
using Lemon.Template.Domain.Repositories;
using Lemon.App.Application.Services;
using Lemon.App.Core.Extend;

namespace Lemon.Template.Application.Services.Account;

public class UserService 
    : DefaultApplicationService<UserData, UserDataDto, long, CreateOrUpdateUserDto, GetUserPageListParamsDto>, IUserService
{
    private readonly IUserRepository _userRepository;
    public UserService(IServiceProvider serviceProvider, IUserRepository userRepository) : base(serviceProvider, userRepository)
    {
        _userRepository = userRepository;
    }

    protected override UserData FillCreateEntity(CreateOrUpdateUserDto input)
    {
        return new UserData(SnowflakeIdGenerator.NextId(), input.Account, input.Password, input.Name);
    }

    protected override void FillUpdateEntity(CreateOrUpdateUserDto input, ref UserData entity)
    {
        entity.Set(input.Name, input.Account);
    }

    protected override Expression<Func<UserData, bool>> GetPageListExpression(GetUserPageListParamsDto input)
    {
        Expression<Func<UserData, bool>> expression = Expressionable.Create<UserData>()
        .AndIf(!input.Account.IsNullOrWhiteSpace(), x=> x.Account == input.Account)
        .AndIf(!input.Name.IsNullOrWhiteSpace(), x=> x.NickName == input.Name);
        return expression;
    }

    protected override Func<UserData, object> GetPageListOrderByDescending()
    {
        return new Func<UserData, object>(x=> x.CreationTime);
    }
}