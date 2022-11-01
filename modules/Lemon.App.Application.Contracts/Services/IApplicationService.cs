using System.Collections.Generic;
using System.Threading.Tasks;
using Lemon.App.Application.Contracts.Pagination;

namespace Lemon.App.Application.Contracts.Services;

public interface IApplicationService<TEntityDto, TKey, TCreateOrUpdateParamsDto, TGetListParamsDto>
        where TEntityDto : class, new()
        where TKey : notnull
        where TCreateOrUpdateParamsDto : class, new()
        where TGetListParamsDto : class, new()
{

    Task<TEntityDto> GetAsync(TKey id);

    Task<TEntityDto> CreateAsync(TCreateOrUpdateParamsDto input);

    Task<TEntityDto> UpdateAsync(TKey id, TCreateOrUpdateParamsDto input);

    Task DeleteAsync(TKey id);

    Task DeleteManyAsync(IEnumerable<TKey> ids);

    Task<PagedResultDto<TEntityDto>> GetListAsync(TGetListParamsDto input);
}