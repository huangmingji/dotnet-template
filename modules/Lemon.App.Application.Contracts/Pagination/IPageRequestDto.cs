namespace Lemon.App.Application.Contracts.Pagination;

public interface IPagedRequestDto
{
    int PageSize { get; }

    int PageIndex { get; }

}