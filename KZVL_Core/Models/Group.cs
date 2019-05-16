using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KZVL_Core.Models
{
    public class Group
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int DivizionID { get; set; }
        public Divizion Divizion { get; set; }
    }
}
