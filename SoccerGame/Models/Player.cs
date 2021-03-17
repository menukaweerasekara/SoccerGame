using System;
using System.Collections.Generic;

namespace SoccerGame.Models
{
    public class Player
    {
        public int ID { get; set; }
        public string FirstMidName { get; set; }
        public string LastName { get; set; }
        public DateTime EnrollmentDate { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; }
    }
}