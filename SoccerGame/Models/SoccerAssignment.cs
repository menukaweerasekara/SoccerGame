using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoccerGame.Models
{
    public class SoccerAssignment
    {
        [Key]
        public int TeamID { get; set; }
        [StringLength(50)]
        [Display(Name = "Teams Practicing Loaction")]
        public string Location { get; set; }

        public Team Team { get; set; }
        public int CoachID { get; set; }
    }
}