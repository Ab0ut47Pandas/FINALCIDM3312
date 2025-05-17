using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CardVaultApp.Data;
using CardVaultApp.Models;

namespace CardVaultApp.Pages_PlayingCards
{
    public class EditModel : PageModel
    {
        private readonly CardVaultApp.Data.ApplicationDbContext _context;

        public EditModel(CardVaultApp.Data.ApplicationDbContext context)
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

            var playingcard =  await _context.PlayingCards.FirstOrDefaultAsync(m => m.ID == id);
            if (playingcard == null)
            {
                return NotFound();
            }
            PlayingCard = playingcard;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(PlayingCard).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlayingCardExists(PlayingCard.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool PlayingCardExists(int id)
        {
            return _context.PlayingCards.Any(e => e.ID == id);
        }
    }
}
