using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using NSLogistics.Application.Application.Commands.Create;
using NSLogistics.Application.Application.Commands.UploadImages;
using NSLogistics.Core.User.Enums;

namespace NSLogistics.Api.Controllers;

[Route("api/applications")]
[ApiController]
public class ApplicationController : ApiControllerBase
{
    [HttpPost]
    [Authorize(Policy = Roles.AdminPolicy)]
    public async Task<IResult> AddApplication(CreateApplicationCommand command, CancellationToken cancellationToken)
    {
        var applicationId = await Mediator.Send(command, cancellationToken);
        return Results.Ok(applicationId);
    }

    [HttpPost("upload-images")]
    [Authorize(Policy = Roles.AdminPolicy)]
    public async Task<IResult> UploadImages([FromForm] UploadImagesCommand command, CancellationToken cancellationToken)
    {
        var result = await Mediator.Send(command, cancellationToken);
        return result
            ? Results.Ok("Images uploaded successfully.")
            : Results.NotFound("Application not found.");
    }
}
