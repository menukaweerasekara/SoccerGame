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
    public class DetailsModel : PageModel
    {
        private readonly SoccerGame.Data.GameContext _context;

        public DetailsModel(SoccerGame.Data.GameContext context)
        {
            _context = context;
        }

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
    }
}
