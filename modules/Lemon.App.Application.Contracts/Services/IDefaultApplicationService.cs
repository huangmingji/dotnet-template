using Lemon.App.Application.Contracts.Pagination;

namespace Lemon.App.Application.Contracts.Services
{
    public interface IDefaultApplicationService<TEntityDto, TKey, TCreateOrUpdateParamsDto, TGetPageListParamsDto, TGetListParamsDto>
        : IApplicationService<TEntityDto, TKey, TCreateOrUpdateParamsDto, TGetPageListParamsDto, TGetListParamsDto>
        where TEntityDto : class, new()
        where TKey : notnull
        where TCreateOrUpdateParamsDto : class, new()
        where TGetPageListParamsDto : class, IPagedRequestDto, new()
        where TGetListParamsDto : class, new()
    {
    }
}

