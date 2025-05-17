using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CardVaultApp.Data;
using CardVaultApp.Models;

namespace CardVaultApp.Pages_PlayingCards
{
    public class DetailsModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DetailsModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public PlayingCard PlayingCard { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            PlayingCard = await _context.PlayingCards
                .Include(p => p.Gradings)
                .FirstOrDefaultAsync(m => m.ID == id);

            if (PlayingCard == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}
