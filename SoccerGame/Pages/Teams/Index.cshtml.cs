using SoccerGame.Models;
using SoccerGame.Models.GamelViewModels;  // Add VM
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace SoccerGame.Pages.Teams
{
    public class IndexModel : PageModel
    {
        private readonly SoccerGame.Data.GameContext _context;

        public IndexModel(SoccerGame.Data.GameContext context)
        {
            _context = context;
        }

        public TeamIndexData TeamData { get; set; }
        public int TeamID { get; set; }
        public int CoachID { get; set; }

        public async Task OnGetAsync(int? id, int? coachID)
        {
            TeamData = new TeamIndexData();
            TeamData.Teams = await _context.Teams
                .Include(i => i.SoccerAssignment)
                .Include(i => i.GameAssignments)
                    .ThenInclude(i => i.Coach)
                    .ThenInclude(i => i.DepartmentID)
                //.Include(i => i.CourseAssignments)
                //    .ThenInclude(i => i.Course)
                //        .ThenInclude(i => i.Enrollments)
                //            .ThenInclude(i => i.Student)
                //.AsNoTracking()
                .OrderBy(i => i.LastName)
                .ToListAsync();

            if (id != null)
            {
                TeamID = id.Value;
                Team team = TeamData.Teams
                    .Where(i => i.ID == id.Value).Single();
                TeamData.Coaches = team.GameAssignment.Select(s => s.Coach);
            }

            if (coachID != null)
            {
                CoachID = coachID.Value;
                var selectedCoach = TeamData.Coaches
                    .Where(x => x.CoachID == CoachID).Single();
                await _context.Entry(selectedCoach).Collection(x => x.Enrollments).LoadAsync();
                foreach (Enrollment enrollment in selectedCoach.Enrollments)
                {
                    await _context.Entry(enrollment).Reference(x => x.Player).LoadAsync();
                }
                TeamData.Enrollments = selectedCoach.Enrollments;
            }
        }
    }
}