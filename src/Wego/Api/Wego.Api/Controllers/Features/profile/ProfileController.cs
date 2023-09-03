using MediatR;

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


    [HttpPost("create-thumbnail")]
    public async Task<ActionResult<long>> CreateImageProfile([FromBody] ImageProfileModel model, CancellationToken ct)
        => Ok(await _mediator.Send(new ImageProfileModelCommand(model.ProfileId, model.Base64, model.Width, model.Height, model.ContentType)));

    [HttpGet("{pid}/thumbnail")]
    public async Task<ActionResult> GetImageProfile(long pid, CancellationToken ct)
    {
      var result  = await _mediator.Send(new GetImageByIdQuery(pid));
        return File(result.ImageData, result.ContentType);
    }
  

   

}
