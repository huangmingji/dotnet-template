using Lemon.App.Application.Contracts.Pagination;

namespace Lemon.Template.Application.Contracts.Account.Users.Dtos;

public class GetUserListParamsDto
{
    public string Name { get; set; }

    public string Account { get; set; }
}