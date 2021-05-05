using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoccerGame.Models
{
    public class Division
    {
        public int DivisionID { get; set; }

        public string Division_Name { get; set; }

        public string Location { get; set; }

        public ICollection<Team> Teams { get; set; }

    }
}
