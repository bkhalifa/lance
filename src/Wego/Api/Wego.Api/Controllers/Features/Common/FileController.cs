using MediatR;

using Microsoft.AspNetCore.Mvc;

using Wego.Application.Features.Profile.Queries;

namespace Wego.Api.Controllers.Features.Common
{
    [Route("api/file")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private readonly IMediator _mediator;
        public FileController(IMediator mediator)
        {
            _mediator = mediator;
        }



        [HttpGet("{pid}/thumbnail")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> GetThumbnail(long pid, CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(new GetImageByIdQuery(pid, cancellationToken));
            return File(result.ImageData, result.ContentType);
        }

    }
}
