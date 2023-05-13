using Core.Entities;
using Core.interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using TrazimMestra.Dtos;
using TrazimMestra.Hubs;

namespace TrazimMestra.Controllers
{
    public class ChatController : BaseApiController
    {
        private readonly IHubContext<ChatHub> _hubContext;
        private readonly IChatRepository _chatRepository;

        public ChatController(IHubContext<ChatHub> hubContext, IChatRepository chatRepository)
        {
            _hubContext = hubContext;
            _chatRepository = chatRepository;
        }

        [HttpGet("meta")]
        public async Task<ActionResult<IEnumerable<ChatMeta>>> GetChatsMetaData(Guid user)
        {
            var results = await _chatRepository.GetChatsMeta(user);
            return Ok(results);
        }

        [HttpGet("room")]
        public async Task<ActionResult<ChatRoom>> GetChatRoom(string roomId)
        {
            return await _chatRepository.GetChatRoomByIdAsync(roomId);
        }
    }
}
