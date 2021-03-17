using SoccerGame.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace SoccerGame.Pages.Players
{
    public class DeleteModel : PageModel
    {
        private readonly SoccerGame.Data.GameContext _context;

        public DeleteModel(SoccerGame.Data.GameContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Player Player { get; set; }
        public string ErrorMessage { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return NotFound();
            }

            Player = await _context.Players
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);

            if (Player == null)
            {
                return NotFound();
            }

            if (saveChangesError.GetValueOrDefault())
            {
                ErrorMessage = "Delete failed. Try again";
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Player = await _context.Players.FindAsync(id);

            if (Player == null)
            {
                return NotFound();
            }

            try
            {
                _context.Players.Remove(Player);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            catch (DbUpdateException /* ex */)
            {
                //Log the error (uncomment ex variable name and write a log.)
                return RedirectToAction("./Delete",
                                     new { id, saveChangesError = true });
            }
        }
    }
}