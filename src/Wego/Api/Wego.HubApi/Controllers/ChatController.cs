using Microsoft.AspNetCore.Mvc;

using Wego.Application.Contracts.Common;
using Wego.Application.Models.Chat;

namespace Wego.Api.Controllers.Pages
{
    [Route("api/[controller]")]
    [ApiController]

    public class ChatController : ControllerBase
    {
        public readonly IChatService _chatService;
        public ChatController(IChatService chatService)
        {
            _chatService = chatService;
        }



        [HttpGet(nameof(GetOnlineUsers))]
        public async Task<ActionResult<List<CandidateModel>>> GetOnlineUsers()
        {
            var result = await _chatService.GetOnlineUsers();
            return Ok(result);
        }


        [HttpGet(nameof(GetChatMessages))]
        public async Task<ActionResult<List<MessageModel>>> GetChatMessages(int profileFromId, int profileToId)
        {
            var result = await _chatService.GetMessageByProfileId(profileFromId, profileToId);
            return Ok(result);
        }
    }
}
