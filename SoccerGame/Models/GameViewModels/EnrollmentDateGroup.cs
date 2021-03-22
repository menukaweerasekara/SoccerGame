using System;
using System.ComponentModel.DataAnnotations;

namespace SoccerGame.Models.GamelViewModels
{
    public class EnrollmentDateGroup
    {
        [DataType(DataType.Date)]
        public DateTime? EnrollmentDate { get; set; }

        public int PlayerCount { get; set; }
    }
}