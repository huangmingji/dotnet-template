using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Lemon.Common.Extend;
using Lemon.App.Core.Services;
using Lemon.AutoMapper;
using Lemon.Template.Application.Contracts;
using Lemon.Template.Application.Contracts.Account.Users.Dtos;
using Lemon.Template.Domain.Account.Users;
using Lemon.Template.Domain.Repositories;
using Lemon.App.Core.Pagination;

namespace Lemon.Template.Application.Services.Account;

public class UserService : ApplicationService, IUserService
{
    private readonly IUserRepository _userRepository;
    public UserService(IServiceProvider serviceProvider, IUserRepository userRepository) : base(serviceProvider)
    {
        _userRepository = userRepository;
    }

    public async Task<UserDataDto> CreateAsync(CreateOrUpdateUserDto input)
    {
        var data = new UserData(input.Account, input.Password, input.Name);
        var result = await _userRepository.InsertAsync(data);
        return ObjectMapper.Map<UserData, UserDataDto>(result);
    }

    public async Task DeleteAsync(long id)
    {
        await _userRepository.DeleteAsync(id);
    }

    public async Task DeleteManyAsync(IEnumerable<long> ids)
    {
        await _userRepository.DeleteManyAsync(ids);
    }

    public async Task<UserDataDto> GetAsync(long id)
    {
        var userData = await _userRepository.GetAsync(id);
        return ObjectMapper.Map<UserData, UserDataDto>(userData);
    }

    public async Task<PagedResultDto<UserDataDto>> GetListAsync(GetUsersDto input)
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
        var total = await _userRepository.CountAsync(expression);
        var data = await _userRepository.FindListAsync(expression, input.PageIndex, input.PageSize);
        return new PagedResultDto<UserDataDto>()
        {
            Total = total,
            Data = ObjectMapper.Map<List<UserData>, List<UserDataDto>>(data)
        };
    }

    public async Task<UserDataDto> UpdateAsync(long id, CreateOrUpdateUserDto input)
    {
        var userData = await _userRepository.GetAsync(id);
        userData.Set(input.Name, input.Account);
        var result = await _userRepository.UpdateAsync(userData);
        return ObjectMapper.Map<UserData, UserDataDto>(result);
    }
}