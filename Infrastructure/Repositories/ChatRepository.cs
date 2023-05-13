using Core.Entities;
using Core.interfaces;
using Infrastructure.Data;
using Infrastructure.Utilities;
using Microsoft.EntityFrameworkCore;
using TrazimMestra.Dtos;

namespace Infrastructure.Repositories
{
    public class ChatRepository : IChatRepository
    {
        private readonly ApplicationContext _context;

        public ChatRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task AddMessageToRoomAsync(ChatRoom chatRoom, Message message)
        {
            if (chatRoom != null)
            {
                chatRoom.Messages.Add(message);
                _context.Entry(chatRoom).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
        }

        public async Task<ChatRoom> GetChatRoomByIdAsync(string roomId)
        {
            return await _context.ChatRooms
                .Include(room => room.Messages)
                .FirstOrDefaultAsync(room => room.RoomName == roomId);
        }

        public async Task<IEnumerable<ChatMeta>> GetChatsMeta(Guid user)
        {
            List<ChatMeta> results = new List<ChatMeta>();

            var rooms = await _context.ChatRooms
                .Include(room => room.Messages)
                .Where(room => room.User1 == user || room.User2 == user).ToListAsync();

            foreach (var room in rooms)
            {
                var otherUser = await _context.Users.FirstAsync(u => u.Id == ((room.User1 == user) ? room.User2 : room.User1));
                
                if (otherUser == null)
                    continue;

                var lastMessage = room.Messages.Last();
                results.Add(new ChatMeta
                {
                    RoomId = room.RoomName,
                    FirstName = otherUser.FirstName,
                    LastName = otherUser.LastName,
                    LastMessageTime = lastMessage.Time,
                    LastMessage = lastMessage.Content
                });
            }
            return results;
        }

        public async Task<ChatRoom> GetOrCreateChatRoomAsync(Guid user1, Guid user2)
        {
            string roomId = ChatUtility.CreateUniqueRoomName(user1, user2);
            var chatRoom = await GetChatRoomByIdAsync(roomId);

            if (chatRoom == null)
            {
                chatRoom = new ChatRoom
                {
                    RoomName = roomId,
                    User1 = user1,
                    User2 = user2,
                    Messages = new List<Message>()
                };
                _context.ChatRooms.Add(chatRoom);
                await _context.SaveChangesAsync();
            }

            return chatRoom;
        }

    }
}
