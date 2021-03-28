using SoccerGame.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace SoccerGame.Pages.Coaches
{
    public class DeleteModel : PageModel
    {
        private readonly SoccerGame.Data.GameContext _context;

        public DeleteModel(SoccerGame.Data.GameContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Coach Coach { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Coach = await _context.Coaches
                .AsNoTracking()
                .Include(c => c.DepartmentID)
                .FirstOrDefaultAsync(m => m.CoachID == id);

            if (Coach == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
