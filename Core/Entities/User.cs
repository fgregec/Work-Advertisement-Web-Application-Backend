using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class User : BaseUser
    {
        public IEnumerable<Natjecaj>? ListResolvedNatjecaja { get; set; }
    }
}
