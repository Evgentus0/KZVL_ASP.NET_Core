using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KZVL_Core.Models
{
    public class Divizion
    {
        public int ID { get; set; }
        public int Number { get; set; }
        
        ICollection<Group> Groups { get; set; }
    }
}
