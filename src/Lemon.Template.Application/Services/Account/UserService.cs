using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Lemon.Common.Extend;
using Lemon.Template.Application.Contracts;
using Lemon.Template.Application.Contracts.Account.Users.Dtos;
using Lemon.Template.Domain.Account.Users;
using Lemon.Template.Domain.Repositories;
using Lemon.App.Core.AutoMapper;
using Lemon.App.Application.Services;
using Lemon.App.Application.Contracts.Pagination;

namespace Lemon.Template.Application.Services.Account;

public class UserService : DefaultApplicationService<UserData, UserDataDto, long, CreateOrUpdateUserDto, GetUsersDto>, IUserService
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

    protected override Expression<Func<UserData, bool>> GetExpression(GetUsersDto input)
    {
        Expression<Func<UserData, bool>> expression = ExtLinq.True<UserData>();
        if (!input.Account.IsNullOrWhiteSpace())
        {
            expression = expression.And(x => x.Account == input.Account);
        }
        if (!input.Name.IsNullOrWhiteSpace())
        {
            expression = expression.And(x => x.NickName == input.Name);
        }
        if (!input.Account.IsNullOrWhiteSpace())
        {
            expression = expression.And(x => x.Account == input.Account);
        }
        if (!input.Name.IsNullOrWhiteSpace())
        {
            expression = expression.And(x => x.NickName == input.Name);
        }
        return expression;
    }
}