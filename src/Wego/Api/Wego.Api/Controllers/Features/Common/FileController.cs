using MediatR;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Wego.Application.Features.BackGround.Commands;
using Wego.Application.Features.BackGround.Queries;
using Wego.Application.Features.Profile.Commands;
using Wego.Application.Features.Profile.Queries;
using Wego.Application.Models.Common;

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


        [HttpGet("all-backgrounds")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> GetAllBackGrounds(CancellationToken cancellationToken = default)
            => Ok(await _mediator.Send(new GetAllBackGroundQuery(cancellationToken)));
        

        [HttpGet("{pid}/thumbnail")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ResponseCache(VaryByHeader = "User-Agent", Duration = 86400)]
        public async Task<ActionResult> GetThumbnail(long pid, CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(new GetImageByIdQuery(pid, cancellationToken));
            if (result is null) return null;
            return File(result.ImageData, result.ContentType);
        }

        [HttpGet("{fileId}/file")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> GetFile(long fileId, CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(new GetFileByIdQuery(fileId, cancellationToken));
            if (result is null) return Ok();
            return File(result.FileData, result.ContentType, result.FileName);
        }


        [HttpGet("{fid}/background")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> GetBackGround(long fid ,CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(new GetBgImageByIdQuery(fid, cancellationToken));
            return File(result?.BigData, result.ContentType);
        }

 
        [HttpPost("save-backgroud")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<long>> SaveBgProfile([FromBody] BackGroundModel model, CancellationToken cancellationToken = default)
            => Ok(await _mediator.Send(new BackGroundModelCommand(model, cancellationToken)));


        [HttpDelete("{fid}/delete-thumbnail")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteImageProfile(long fid, CancellationToken cancellationToken = default)
          => Ok(await _mediator.Send(new DeleteImageProfileModelCommand(fid, cancellationToken)));

    }
}
