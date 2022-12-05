using Lemon.App.Application.Contracts.Pagination;

namespace Lemon.App.Application.Contracts.Services
{
    public interface IDefaultApplicationService<TEntityDto, TKey, TCreateOrUpdateParamsDto, TGetPageListParamsDto>
        : IApplicationService<TEntityDto, TKey, TCreateOrUpdateParamsDto, TGetPageListParamsDto>
        where TEntityDto : class, new()
        where TKey : notnull
        where TCreateOrUpdateParamsDto : class, new()
        where TGetPageListParamsDto : class, IPagedRequestDto, new()
    {
    }
}

