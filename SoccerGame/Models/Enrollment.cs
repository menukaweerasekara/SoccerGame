using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoccerGame.Models
{
   

    public class Enrollment
    {
        public int EnrollmentID { get; set; }
        public int CoachID { get; set; }
        public int PlayerID { get; set; }
        [DisplayFormat(NullDisplayText = "No grade")]
        public int TeamID { get; set;  }


        public Coach Coach { get; set; }
        public Player Player { get; set; }
        public Team Team { get; set; }
    }
}