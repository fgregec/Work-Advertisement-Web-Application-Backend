using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Natjecaj : BaseEntity
    {
        public Guid UserID { get; set; }
        public Guid CityID { get; set; }
        public Guid MestarID { get; set; }
        public Guid CategoryID { get; set; }
        public int Price { get; set; }
        public bool IsEmergency { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }
        public DateTime Finished { get; set; }
    }
}
