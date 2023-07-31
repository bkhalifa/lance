using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Wego.Application.Features.Chat.Queries;

namespace Wego.Api.Controllers.Features
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ChatController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Authorize]
        [HttpGet(nameof(GetChatUsers))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<GetChatUserModel>>> GetChatUsers()
        {
            var dtos = await _mediator.Send(new GetChatUserListQuery());
            return Ok(dtos);
        }

        [Authorize]
        [HttpGet(nameof(GetChatMessages))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<GetChatMessageModel>>> GetChatMessages([Required] long profileFromId, [Required] long profileToId)
        {
            var dtos = await _mediator.Send(new GetChatMessageListQuery(profileFromId, profileToId));
            return Ok(dtos);
        }

    }
}
