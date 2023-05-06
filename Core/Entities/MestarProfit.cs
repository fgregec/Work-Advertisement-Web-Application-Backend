using Core.Models;

namespace Core.Entities
{
    public class MestarProfit : BaseEntity
    {
        public Guid MestarID { get; set; }
        public Mestar Mestar { get; set; }
        public DateTime TimeOfProfit { get; set; }
        public decimal Profit { get; set; }
    }
}
