using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using NSLogistics.Application.User.Commands.Login;
using NSLogistics.Application.User.Commands.Register;
using NSLogistics.Core.User.Enums;

namespace NSLogistics.Api.Controllers;

[Route("api/users")]
public class UserController : ApiControllerBase
{
    [HttpPost("login")]
    [AllowAnonymous]
    public async Task<IResult> Login(LoginUserCommand command, CancellationToken cancellationToken)
    {
        var accessToken = await Mediator.Send(command, cancellationToken);
        return Results.Ok(accessToken);
    }

    [HttpPost]
    [Authorize(Policy = Roles.AdminPolicy)]
    public async Task<IResult> CreateUser(RegisterUserCommand command, CancellationToken cancellationToken)
    {
        var accessToken = await Mediator.Send(command, cancellationToken);
        return Results.Ok(accessToken);
    }
}
