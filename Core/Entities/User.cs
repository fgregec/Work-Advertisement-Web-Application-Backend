using System;
using System.Collections.Generic;
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
        public IEnumerable<Natjecaj> ResolvedNatjecaja { get; set; }

    }
}
