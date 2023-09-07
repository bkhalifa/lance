using MediatR;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Wego.Application.Features.Profile.Commands;
using Wego.Application.Features.Profile.Queries;
using Wego.Application.Models.Profile;

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

    [HttpGet("info")]
    [Authorize]
    public async Task<ActionResult<long>> GetProfileInfo([FromBody] ImageProfileModel model, CancellationToken ct)
      => Ok();

    [HttpPost("create-thumbnail")]
    [Authorize]
    public async Task<ActionResult<long>> CreateImageProfile([FromBody] ImageProfileModel model, CancellationToken ct)
        => Ok(await _mediator.Send(new ImageProfileModelCommand(model.ProfileId, model.Base64, model.Width, model.Height, model.ContentType)));

    [HttpGet("{pid}/thumbnail")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> GetImageProfile(long pid, CancellationToken ct)
    {
        var result = await _mediator.Send(new GetImageByIdQuery(pid));
        if(result is null)
            return NoContent();

        return File(result.ImageData, result.ContentType);
    }




}
