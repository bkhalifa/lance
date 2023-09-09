using MediatR;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using System.Security.Policy;
using System;

using Wego.Application.Features.Profile.Commands;
using Wego.Application.Features.Profile.Queries;
using Wego.Application.Models.Profile;
using System.Drawing;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Wego.Domain.Profile;

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
    public async Task<ActionResult<long>> GetProfileInfo([FromBody] long profileId, CancellationToken ct)
      => Ok();

    [HttpPost("create-thumbnail")]
    [Authorize]
    public async Task<ActionResult<long>> CreateImageProfile([FromBody] ImageProfileModel model, CancellationToken ct)
      => Ok(await _mediator.Send(new ImageProfileModelCommand(model.ProfileId, model.Base64, model.Width, model.Height, model.ContentType)));
    


    [HttpGet("{fid}/thumbnail")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ImageProfileResponse>> GetImageProfile(long fid, CancellationToken ct)
     => Ok(await _mediator.Send(new GetImageByIdQuery(fid)));
      
    

}
