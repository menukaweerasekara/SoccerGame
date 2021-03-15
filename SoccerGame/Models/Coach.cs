using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoccerGame.Models
{
    public class Coach
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CoachID { get; set; }
        public string Title { get; set; }
        public int Credits { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; }
    }
}