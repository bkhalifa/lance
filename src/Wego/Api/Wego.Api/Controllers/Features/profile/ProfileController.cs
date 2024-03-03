using MediatR;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Wego.Application.Features.Profile.Commands;
using Wego.Application.Features.Profile.Queries;
using Wego.Application.Models.Profile.request;

namespace Wego.Api.Controllers.Features.profile;

[Route("api/profile")]
[ApiController]
[Authorize]
public class ProfileController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProfileController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// get profile info 
    /// </summary>
    /// <param name="uid"></param>
    /// <param name="cancellationToken"></param>
    /// <returns>Profile Info Response</returns>
    [HttpGet("{uid}/info")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult> GetProfileInfo(string uid, CancellationToken cancellationToken = default)
    {
        var result = await _mediator.Send(new GetProfileInfoQuery(uid, cancellationToken));

        if (result is null)
            return Unauthorized();

        return Ok(result);
    }

    /// <summary>
    /// update profile info 
    /// </summary>
    /// <param name="pid">profileID</param>
    /// <param name="profileInfoRequest"></param>
    /// <param name="cancellationToken"></param>
    /// <returns>ProfileModel</returns>
    [HttpPatch("{pid}/update-info")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult> UpdateProfileInfo(long pid, [FromBody]ProfileInfoRequest profileInfoRequest ,CancellationToken cancellationToken = default)
     => Ok( await _mediator.Send(new UpdateProfileInfoModelCommand(pid, profileInfoRequest, cancellationToken)));


}

