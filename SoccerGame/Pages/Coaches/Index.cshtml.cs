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
    public class IndexModel : PageModel
    {
        private readonly SoccerGame.Data.CoachContext _context;

        public IndexModel(SoccerGame.Data.CoachContext context)
        {
            _context = context;
        }

        public IList<Coach> Coach { get;set; }

        public async Task OnGetAsync()
        {
            Coach = await _context.Coaches.ToListAsync();
        }
    }
}
