using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoccerGame.Models.GamelViewModels
{
    public class TeamIndexData
    {
        public IEnumerable<Team> Teams { get; set; }
        public IEnumerable<Coach> Coaches { get; set; }
        public IEnumerable<Enrollment> Enrollments { get; set; }
    }
}