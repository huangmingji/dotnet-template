using System.Threading.Tasks;
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

    [HttpGet("{id}")]
    public async Task<UserDataDto> GetAsync(long id)
    {
        return await _userService.GetAsync(id);
    }
}