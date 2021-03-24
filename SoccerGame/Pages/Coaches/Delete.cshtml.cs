using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SoccerGame.Data;
using SoccerGame.Models;

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

            Coach = await _context.Coaches.FirstOrDefaultAsync(m => m.CoachID == id);

            if (Coach == null)
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

            Coach = await _context.Coaches.FindAsync(id);

            if (Coach != null)
            {
                _context.Coaches.Remove(Coach);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
