using Lemon.App.Core.Pagination;

namespace Lemon.App.Core.Services;

public interface IApplicationService<TEntity, TKey, TCreateOrUpdateParamsDto, TGetListParamsDto>
        where TEntity : class, new()
        where TKey : notnull
        where TCreateOrUpdateParamsDto : class, new()
        where TGetListParamsDto : class, new()
{

    Task<TEntity> GetAsync(TKey id);

    Task<TEntity> CreateAsync(TCreateOrUpdateParamsDto input);

    Task<TEntity> UpdateAsync(TKey id, TCreateOrUpdateParamsDto input);

    Task DeleteAsync(TKey id);

    Task DeleteManyAsync(IEnumerable<TKey> ids);

    Task<PagedResultDto<TEntity>> GetListAsync(TGetListParamsDto input);
}