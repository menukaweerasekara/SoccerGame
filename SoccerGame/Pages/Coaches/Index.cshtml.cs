using SoccerGame.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SoccerGame.Pages.Coaches
{
    public class IndexModel : PageModel
    {
        private readonly SoccerGame.Data.GameContext _context;

        public IndexModel(SoccerGame.Data.GameContext context)
        {
            _context = context;
        }

        public IList<Coach> Coaches { get; set; }

        public async Task OnGetAsync()
        {
            Coaches = await _context.Coaches
                .Include(c => c.DepartmentID)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}