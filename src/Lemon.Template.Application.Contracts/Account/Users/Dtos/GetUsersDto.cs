
using Lemon.App.Core.Pagination;

namespace Lemon.Template.Application.Contracts.Account.Users.Dtos;

public class GetUsersDto : PagedRequestDto
{
    public string Name { get; set; }

    public string Account { get; set; }
}