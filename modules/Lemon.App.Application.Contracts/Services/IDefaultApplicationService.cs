using System;
using Lemon.App.Application.Contracts.Pagination;
using Lemon.App.Domain.Shared.Entities;

namespace Lemon.App.Application.Contracts.Services
{
    public interface IDefaultApplicationService<TEntity, TEntityDto, TKey, TCreateOrUpdateParamsDto, TGetListParamsDto>
        : IApplicationService<TEntityDto, TKey, TCreateOrUpdateParamsDto, TGetListParamsDto>
        where TEntity : class, IEntity<TKey>, new()
        where TEntityDto : class, new()
        where TKey : notnull
        where TCreateOrUpdateParamsDto : class, new()
        where TGetListParamsDto : class, IPagedRequestDto, new()
    {
    }
}

