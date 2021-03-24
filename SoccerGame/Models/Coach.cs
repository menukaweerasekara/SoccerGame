 using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoccerGame.Models
{
    public class Coach
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "Number")]
        public int CoachID { get; set; }

        [StringLength(50, MinimumLength = 3)]
        public string FirstMidName { get; set; }
        [StringLength(50, MinimumLength = 3)]
        public string LastName { get; set; }

        public int DepartmentID { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; }
        public ICollection<GameAssignment> GameAssignments { get; set; }

    }
}