using Core.Entities;
using Core.interfaces;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Text.Json;
using TrazimMestra.Attributes;
using TrazimMestra.Dtos;
using TrazimMestra.Hubs;

namespace TrazimMestra.Controllers
{
    public class ChatController : BaseApiController
    {
        private readonly IHubContext<ChatHub> _hubContext;
        private readonly IChatRepository _chatRepository;
        private readonly ITokenService _tokenService;

        public ChatController(IHubContext<ChatHub> hubContext, IChatRepository chatRepository, ITokenService tokenService)
        {
            _hubContext = hubContext;
            _chatRepository = chatRepository;
            _tokenService = tokenService;
        }

        [HttpGet("meta")]
        [MyAuthorize]
        public async Task<ActionResult<IEnumerable<ChatMeta>>> GetChatsMetaData()
        {
            var user = (User)HttpContext.Items["User"];
            if (user == null)
                return BadRequest("Something went bad.");

            var results = await _chatRepository.GetChatsMetaData(user.Id);
            return Ok(results);
        }

        [HttpGet("room")]
        [MyAuthorize]
        public async Task<ActionResult<ChatRoom>> GetChatRoom(string roomId)
        {
            return await _chatRepository.GetChatRoomByIdAsync(roomId);
        }
    }
}
