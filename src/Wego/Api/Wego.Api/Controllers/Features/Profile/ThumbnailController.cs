using MediatR;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Wego.Application.Features.BackGround.Queries;
using Wego.Application.Features.Profile.Commands;
using Wego.Application.Features.Profile.Queries;
using Wego.Application.Models.Profile;

namespace Wego.Api.Controllers.Features.Profile
{
    [Route("api/profile/{pid}")]
    [ApiController]
    public class ThumbnailController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ThumbnailController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("thumbnail")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> GetImageProfile(long pid, CancellationToken cancellationToken = default)
        => Ok(await _mediator.Send(new GetImageByIdQuery(pid, cancellationToken)));


        [HttpGet("background-profile")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> GetBackGroundByProfileId(long pid, CancellationToken cancellationToken = default)
        => Ok(await _mediator.Send(new GetBackGroundImageByProfileIdQuery(pid, cancellationToken)));

        [HttpPost("save-thumbnail")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<long>> SaveImageProfile(long pid, [FromBody] ImageProfileModel model, CancellationToken cancellationToken = default)
        => Ok(await _mediator.Send(new ImageProfileModelCommand(pid, model, cancellationToken)));


        [HttpPost("save-background")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<long>> SaveBachGroundProfile(long pid, [FromBody] BackGroundProfileModel model, CancellationToken cancellationToken = default)
        => Ok(await _mediator.Send(new BackGroundProfileCommand(pid, model, cancellationToken)));
    }
}
