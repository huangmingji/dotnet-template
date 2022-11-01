using System.Collections.Generic;

namespace Lemon.App.Application.Contracts.Pagination;

public class PagedResultDto<TEntityDto> where TEntityDto : class, new()
{
    public List<TEntityDto> Data { get; set; } = new List<TEntityDto>();

    public int Total { get; set; }
}