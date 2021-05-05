using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoccerGame.Models
{
    public class Team
    {
        public int TeamID { get; set; }

        public string TeamName { get; set; }


        public int DivisionID { get; set; }

        public Division Divisions { get; set; }
       
        public ICollection<Player> Players { get; set; }



       
        
    }
}