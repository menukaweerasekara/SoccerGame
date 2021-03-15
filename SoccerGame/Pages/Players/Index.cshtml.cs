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

        public IList<Player> Player { get;set; }

        public async Task OnGetAsync()
        {
            Player = await _context.Player.ToListAsync();
        }
    }
}
