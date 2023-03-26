using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Natjecaj : BaseEntity
    {
        public BaseUser User{ get; set; }
        public Guid UserID { get; set; }
        public City City { get; set; }
        public Guid CityID { get; set; }
        public Mestar Mestar { get; set; }
        public Guid MestarID { get; set; }
        public Category Category{ get; set; }
        public Guid CategoryID { get; set; }
        public decimal Price { get; set; }
        public bool IsEmergency { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Finished { get; set; }
    }
}
