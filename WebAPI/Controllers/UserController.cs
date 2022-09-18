using Application.Features.User.Commands.CreateUser;
using Application.Features.User.Commands.LoginUser;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

public class UserController : BaseController
{
    [HttpPost("register")]
    public async Task<IActionResult> Register(CreateUserCommand command)
    {
        var createdUser = Mediator.Send(command);
        return Ok(createdUser);
    }
    [HttpPost("login")]
    public async Task<IActionResult> Register(LoginUserCommand command)
    {
        var loginUser = Mediator.Send(command);
        return Ok(loginUser);
    }
}