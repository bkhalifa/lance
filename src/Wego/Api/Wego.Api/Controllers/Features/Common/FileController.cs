﻿using MediatR;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Wego.Application.Features.BackGround.Commands;
using Wego.Application.Features.Profile.Queries;
using Wego.Application.Models.Common;
using Wego.Domain.Common;

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

        [HttpPost("save-backgroud")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<long>> SaveBgProfile([FromBody] BackGroundModel model, CancellationToken cancellationToken = default)
            => Ok(await _mediator.Send(new BackGroundModelCommand(model, cancellationToken)));

    }
}
