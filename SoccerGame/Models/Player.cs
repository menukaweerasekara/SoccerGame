using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoccerGame.Models
{
    public class Player
    {
        public int PlayerID { get; set; }
     
        public string PlayerName { get; set; }
             
            
         
        public int Age { get; set; }
        
        public string Position { get; set; }

        public int TeamID { get; set; }

        public Team Teams { get; set; }
       

       
    }
}