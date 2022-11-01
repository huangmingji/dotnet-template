using System;
namespace Lemon.App.Application.Contracts.Pagination
{
    public class PagedRequestDto : IPagedRequestDto
    {
        public int PageSize { get; set; }

        public int PageIndex { get; set; }
    }
}

