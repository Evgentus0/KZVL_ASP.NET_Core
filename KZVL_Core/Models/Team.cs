using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KZVL_Core.Models
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int Rating { get; set; }

        public int GroupId { get; set; }
        public Group Group { get; set; }
        ICollection<Player> Players { get; set; }

    }
}
