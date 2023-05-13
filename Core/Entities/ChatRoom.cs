namespace Core.Entities
{
    public class ChatRoom
    {
        public string RoomName { get; set; }
        public Guid User1{ get; set; }
        public Guid User2 { get; set; }
        public List<Message> Messages{ get; set; }
    }
}
