using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CardVaultApp.Data;
using CardVaultApp.Models;

namespace CardVaultApp.Pages_PlayingCards
{
    public class DeleteModel : PageModel
    {
        private readonly CardVaultApp.Data.ApplicationDbContext _context;

        public DeleteModel(CardVaultApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public PlayingCard PlayingCard { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var playingcard = await _context.PlayingCards.FirstOrDefaultAsync(m => m.ID == id);

            if (playingcard is not null)
            {
                PlayingCard = playingcard;

                return Page();
            }

            return NotFound();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var playingcard = await _context.PlayingCards.FindAsync(id);
            if (playingcard != null)
            {
                PlayingCard = playingcard;
                _context.PlayingCards.Remove(PlayingCard);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
