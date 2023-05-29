using Core.Entities;
using TrazimMestra.Dtos;

namespace Core.interfaces
{
    public interface IChatRepository
    {
        Task AddMessageToRoomAsync(ChatRoom chatRoom, Message message);
        Task<ChatRoom> GetChatRoomByIdAsync(string roomId);
        Task<ChatRoom> GetOrCreateChatRoomAsync(Guid user1, Guid user2);
        Task<IEnumerable<ChatMeta>> GetChatsMetaData(Guid user);
    }
}
