using MediatR;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Wego.Application.Features.Profile.Queries;


namespace Wego.Api.Controllers.Features.profile;

[Route("api/profile")]
[ApiController]
public class ProfileController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProfileController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("info/{uid}")]
    [Authorize]
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

}

