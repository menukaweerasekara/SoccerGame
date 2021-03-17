using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SoccerGame.Data;
using SoccerGame.Models;

namespace SoccerGame.Pages.Players
{
    public class IndexModel : PageModel
    {
        private readonly SoccerGame.Data.GameContext _context;

        public IndexModel(SoccerGame.Data.GameContext context)
        {
            _context = context;
        }



        public string NameSort { get; set; }
        public string DateSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }

        public IList<Player> Player { get; set; }

        public async Task OnGetAsync(string sortOrder)
        {
            // using System;
            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            DateSort = sortOrder == "Date" ? "date_desc" : "Date";

            IQueryable<Player> playersIQ = from s in _context.Players
                                           select s;

            switch (sortOrder)
            {
                case "name_desc":
                    playersIQ = playersIQ.OrderByDescending(s => s.LastName);
                    break;
                case "Date":
                    playersIQ = playersIQ.OrderBy(s => s.EnrollmentDate);
                    break;
                case "date_desc":
                    playersIQ = playersIQ.OrderByDescending(s => s.EnrollmentDate);
                    break;
                default:
                    playersIQ = playersIQ.OrderBy(s => s.LastName);
                    break;
            }

            Player = await playersIQ.AsNoTracking().ToListAsync();
        }
    }
}
