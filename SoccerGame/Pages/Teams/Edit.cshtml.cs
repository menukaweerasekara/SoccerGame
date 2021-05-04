using SoccerGame.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace SoccerGame.Pages.Teams

{
    public class EditModel : TeamCoachesPageModel
    {
        private readonly SoccerGame.Data.GameContext _context;

        public EditModel(SoccerGame.Data.GameContext context)
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

            Team = await _context.Teams
                .Include(i => i.SoccerAssignment)
                .Include(i => i.GameAssignments).ThenInclude(i => i.Coach)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);

            if (Team == null)
            {
                return NotFound();
            }
            PopulateAssignedCoachData(_context, Team);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id, string[] selectedCoach)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teamToUpdate = await _context.Teams
                .Include(i => i.SoccerAssignment)
                .Include(i => i.GameAssignments)
                    .ThenInclude(i => i.Coach)
                .FirstOrDefaultAsync(s => s.ID == id);

            if (teamToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<Team>(
                teamToUpdate,
                "Team",
                i => i.FullName, i => i.LastName,
                i => i.HireDate, i => i.SoccerAssignment))
            {
                if (String.IsNullOrWhiteSpace(
                    teamToUpdate.SoccerAssignment?.Location))
                {
                    teamToUpdate.SoccerAssignment = null;
                }
                UpdateTeamCoaches(_context, selectedCoach, teamToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            UpdateTeamCoaches(_context, selectedCoach, teamToUpdate);
            PopulateAssignedCoachData(_context, teamToUpdate);
            return Page();
        }
    }
}
