using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class NatjecajFilter
    {
        public string? Category { get; set; }
        public string? County { get; set; }
        public string? City { get; set; }
        public bool Emergency { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
    }
}
