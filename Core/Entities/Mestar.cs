using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Mestar : BaseEntity
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public Category CategoryID { get; set; }
    }
}
