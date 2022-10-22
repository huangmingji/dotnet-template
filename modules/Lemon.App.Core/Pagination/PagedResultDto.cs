namespace Lemon.App.Core.Pagination;

public class PagedResultDto<TEntityDto> where TEntityDto : class, new()
{
    public List<TEntityDto> Data { get; set; } = new List<TEntityDto>();

    public int Total { get; set; }
}