 using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoccerGame.Models
{
    public class Coach
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CoachID { get; set; }
        public string FirstMidName { get; set; }
        public string LastName { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; }
    }
}