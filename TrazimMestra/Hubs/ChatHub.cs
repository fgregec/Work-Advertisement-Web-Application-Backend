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
            string chatRoomId = ChatUtility.CreateUniqueRoomId(user1, user2);
            ChatRoom chatRoom = await _repo.GetOrCreateChatRoomAsync(user1, user2);
            await Groups.AddToGroupAsync(Context.ConnectionId, chatRoomId);
        }

        public async Task LeavePrivateChatRoom(Guid user1, Guid user2)
        {
            string roomId = ChatUtility.CreateUniqueRoomId(user1, user2);
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, roomId);
        }

        public async Task SendMessageToPrivateChatRoom(Guid sender, Guid receiver, string content)
        {
            string chatRoomId = ChatUtility.CreateUniqueRoomId(sender, receiver);
            ChatRoom chatRoom = await _repo.GetChatRoomByIdAsync(chatRoomId);
            if (chatRoom != null)
            {
                var message = new Message
                {
                    SenderId = sender,
                    ReceiverId = receiver,
                    Content = content,
                    Time = DateTime.UtcNow
                };
                await _repo.AddMessageToRoomAsync(chatRoom, message);

                await Clients.Group(chatRoomId).SendAsync("ReceiveMessage", message );
            }
        }

    }
}
