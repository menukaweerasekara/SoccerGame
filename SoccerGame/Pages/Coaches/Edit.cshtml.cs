using SoccerGame.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace SoccerGame.Pages.Coaches
{
    public class EditModel : DepartmentNamePageModel
    {
        private readonly SoccerGame.Data.GameContext _context;

        public EditModel(SoccerGame.Data.GameContext context)
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
                .Include(c => c.DepartmentID).FirstOrDefaultAsync(m => m.CoachID == id);

            if (Coach == null)
            {
                return NotFound();
            }

            // Select current DepartmentID.
            PopulateDepartmentsDropDownList(_context, Coach.DepartmentID);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coachToUpdate = await _context.Coaches.FindAsync(id);

            if (coachToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<Coach>(
                 coachToUpdate,
                 "coach",   // Prefix for form value.
                   c => c.DepartmentID,  c => c.FirstMidName))
            {
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            // Select DepartmentID if TryUpdateModelAsync fails.
            PopulateDepartmentsDropDownList(_context, coachToUpdate.DepartmentID);
            return Page();
        }
    }
}