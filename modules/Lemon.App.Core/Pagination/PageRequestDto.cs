namespace Lemon.App.Core.Pagination;

public class PagedRequestDto
{

    public int PageSize { get; set; } = 10;

    public int PageIndex { get; set; } = 1;

}