using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class NatjecajStatus : BaseEntity
    {
        public Guid NatjecajId { get; set; }
        public Natjecaj Natjecaj { get; set; }
        public Guid MestarId { get; set; }
        public Mestar Mestar { get; set; }
        public string MestarDescription { get; set; }
        public decimal Price { get; set; }
        public NatjecajEnum Status { get; set; }
        
    }
    public enum NatjecajEnum { Making,Waiting_for_confirmation,Operational,Finished}
}
