namespace Core.Entities
{
    public class Message : BaseEntity
    {
        public Guid SenderId{ get; set; }     
        public Guid ReceiverId { get; set; }     
        public string Content { get; set; }     
        public DateTime Time { get; set; }

    }
}
