using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CardVaultApp.Data;
using CardVaultApp.Models;

namespace CardVaultApp.Pages_PlayingCards
{
    public class CreateModel : PageModel
    {
        private readonly CardVaultApp.Data.ApplicationDbContext _context;

        public CreateModel(CardVaultApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public PlayingCard PlayingCard { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.PlayingCards.Add(PlayingCard);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
