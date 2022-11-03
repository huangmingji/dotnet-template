
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Lemon.App.Application.Contracts.Pagination;
using Lemon.App.Application.Services;
using Lemon.Template.Application.Contracts;
using Lemon.Template.Application.Contracts.Account.Roles.Dtos;

namespace Lemon.Template.Application.Services.Account;

public class RoleService : ApplicationService, IRoleService
{
    public RoleService(IServiceProvider serviceProvider) : base(serviceProvider)
    {
    }

    public Task<RoleDataDto> CreateAsync(CreateOrUpdateRoleDto input)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task DeleteManyAsync(IEnumerable<long> ids)
    {
        throw new NotImplementedException();
    }

    public Task<RoleDataDto> GetAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<List<RoleDataDto>> GetListAsync(GetRoleListParamsDto input)
    {
        throw new NotImplementedException();
    }

    public Task<PagedResultDto<RoleDataDto>> GetPageListAsync(GetRolePageListParamsDto input)
    {
        throw new NotImplementedException();
    }

    public Task<RoleDataDto> UpdateAsync(long id, CreateOrUpdateRoleDto input)
    {
        throw new NotImplementedException();
    }
}