namespace Core.Models
{
    public class MestarProfitModel
    {
        public DateTime From { get; set; }
        public DateTime Until { get; set; }
        public Guid MestarID { get; set; }
        public decimal Profit { get; set; }
    }
}
