using SoccerGame.Models.GamelViewModels;
using SoccerGame.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SoccerGame.Models;

namespace SoccerGame.Pages
{
    public class AboutModel : PageModel
    {
        private readonly GameContext _context;

        public AboutModel(GameContext context)
        {
            _context = context;
        }

        public IList<EnrollmentDateGroup> Players { get; set; }

        public async Task OnGetAsync()
        {
            IQueryable<EnrollmentDateGroup> data =
                from player in _context.Players
                group player by player.EnrollmentDate into dateGroup
                select new EnrollmentDateGroup()
                {
                    EnrollmentDate = dateGroup.Key,
                    PlayerCount = dateGroup.Count()
                };

            Players = await data.AsNoTracking().ToListAsync();
        }
    }
}