using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KZVL_Core.Models
{
    public class Player
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Number { get; set; }

        public DateTime Birth { get; set; }
        public int Height { get; set; }
        public bool IsCaptain { get; set; }
        public bool IsBestGroupPlayer { get; set; }
        public int RoleId{ get; set; }
        public Role Role { get; set; }
        public int TeamId { get; set; }
        public Team Team { get; set; }
        public int CountOfTheBestPlayer { get; set; }
        public string Category { get; set; }


    }
}
