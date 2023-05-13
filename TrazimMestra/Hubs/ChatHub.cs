using Core.Entities;
using Core.interfaces;
using Infrastructure.Utilities;
using Microsoft.AspNetCore.SignalR;

namespace TrazimMestra.Hubs
{
    public class ChatHub : Hub
    {
        private IChatRepository _repo;

        public ChatHub(IChatRepository repo)
        {
            _repo = repo;
        }

        public async Task JoinPrivateChatRoom(Guid user1, Guid user2)
        {
            string roomId = ChatUtility.CreateUniqueRoomName(user1, user2);
            ChatRoom chatRoom = await _repo.GetOrCreateChatRoomAsync(user1, user2);
            await Groups.AddToGroupAsync(Context.ConnectionId, roomId);
        }

        public async Task LeavePrivateChatRoom(Guid user1, Guid user2)
        {
            string roomId = ChatUtility.CreateUniqueRoomName(user1, user2);
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, roomId);
        }

        public async Task SendMessageToPrivateChatRoom(Guid user1, Guid user2, string content)
        {
            string roomId = ChatUtility.CreateUniqueRoomName(user1, user2);
            ChatRoom chatRoom = await _repo.GetChatRoomByIdAsync(roomId);
            if (chatRoom != null)
            {
                var message = new Message
                {
                    SenderId = user1,
                    ReceiverId = user2,
                    Content = content,
                    Time = DateTime.UtcNow
                };
                await _repo.AddMessageToRoomAsync(chatRoom, message);
                await Clients.Group(roomId).SendAsync("ReceiveMessage", user1, content, message.Time);
            }
        }

    }
}
