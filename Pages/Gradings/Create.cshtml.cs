using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CardVaultApp.Data;
using CardVaultApp.Models;

namespace CardVaultApp.Pages_Gradings
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
        ViewData["PlayingCardID"] = new SelectList(_context.PlayingCards, "ID", "ID");
            return Page();
        }

        [BindProperty]
        public Grading Grading { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Gradings.Add(Grading);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
