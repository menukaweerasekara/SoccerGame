using SoccerGame.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace SoccerGame.Pages.Teams
{
    public class DeleteModel : PageModel
    {
        private readonly SoccerGame.Data.GameContext _context;

        public DeleteModel(SoccerGame.Data.GameContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Team Team { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Team = await _context.Teams.FirstOrDefaultAsync(m => m.ID == id);

            if (Team == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Team team = await _context.Teams
                .Include(i => i.GameAssignments)
                .SingleAsync(i => i.ID == id);

            if (team == null)
            {
                return RedirectToPage("./Index");
            }

            var departments = await _context.Departments
                .Where(d => d.TeamID == id)
                .ToListAsync();
            departments.ForEach(d => d.TeamID = null);

            _context.Teams.Remove(team);

            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
    }
}