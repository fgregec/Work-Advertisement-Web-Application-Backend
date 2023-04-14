using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class User : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Guid? CityID { get; set; }
        public City City { get; set; }
        public bool IsMestar{ get; set; }
        [NotMapped]
        public IEnumerable<Natjecaj> ListResolvedNatjecaja { get; set; }

    }
}
