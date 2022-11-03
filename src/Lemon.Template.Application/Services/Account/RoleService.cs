
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Lemon.App.Application.Contracts.Pagination;
using Lemon.App.Application.Contracts.Services;
using Lemon.App.Application.Services;
using Lemon.Template.Application.Contracts;
using Lemon.Template.Application.Contracts.Account.Roles.Dtos;
using Lemon.Template.Domain.Account.Roles;

namespace Lemon.Template.Application.Services.Account;

public class RoleService : ApplicationService, IRoleService
{
    public RoleService(IServiceProvider serviceProvider) : base(serviceProvider)
    {
    }

    public Task<RoleData> CreateAsync(CreateOrUpdateRoleDto input)
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

    public Task<RoleData> GetAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<PagedResultDto<RoleData>> GetListAsync(GetRoleListParamsDto input)
    {
        throw new NotImplementedException();
    }

    public Task<PagedResultDto<RoleData>> GetPageListAsync(GetRolePageListParamsDto input)
    {
        throw new NotImplementedException();
    }

    public Task<RoleData> UpdateAsync(long id, CreateOrUpdateRoleDto input)
    {
        throw new NotImplementedException();
    }

    Task<List<RoleData>> IApplicationService<RoleData, long, CreateOrUpdateRoleDto, GetRolePageListParamsDto, GetRoleListParamsDto>.GetListAsync(GetRoleListParamsDto input)
    {
        throw new NotImplementedException();
    }
}