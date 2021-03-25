using SoccerGame.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace SoccerGame.Pages.Coaches
{
    public class CreateModel : DepartmentNamePageModel
    {
        private readonly SoccerGame.Data.GameContext _context;

        public CreateModel(SoccerGame.Data.GameContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            PopulateDepartmentsDropDownList(_context);
            return Page();
        }

        [BindProperty]
        public Coach Coach { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            var emptyCoach = new Coach();

            if (await TryUpdateModelAsync<Coach>(
                 emptyCoach,
                 "coach",   // Prefix for form value.
                 s => s.CoachID, s => s.DepartmentID, s => s.FirstMidName))
            {
                _context.Coaches.Add(emptyCoach);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            // Select DepartmentID if TryUpdateModelAsync fails.
            PopulateDepartmentsDropDownList(_context, emptyCoach.DepartmentID);
            return Page();
        }
    }
}