using System.Threading.Tasks;
using Lemon.App.Application.Contracts.Pagination;
using Lemon.Template.Application.Contracts;
using Lemon.Template.Application.Contracts.Account.Users.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Lemon.Template.HttpApi.Controllers;

[ApiController]
[Route("account/users")]
public class UsersController : Controller
{
    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet()]
    public async Task<PagedResultDto<UserDataDto>> GetAsync()
    {
        return await _userService.GetPageListAsync(new GetUserPageListParamsDto() {
            PageIndex = 1,
            PageSize = 10
        });
    }
}