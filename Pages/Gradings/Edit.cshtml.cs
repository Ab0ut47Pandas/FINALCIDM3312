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

namespace CardVaultApp.Pages_Gradings
{
    public class EditModel : PageModel
    {
        private readonly CardVaultApp.Data.ApplicationDbContext _context;

        public EditModel(CardVaultApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Grading Grading { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var grading =  await _context.Gradings.FirstOrDefaultAsync(m => m.ID == id);
            if (grading == null)
            {
                return NotFound();
            }
            Grading = grading;
           ViewData["PlayingCardID"] = new SelectList(_context.PlayingCards, "ID", "ID");
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

            _context.Attach(Grading).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GradingExists(Grading.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }


            return RedirectToPage("/PlayingCards/Details", new { id = Grading.PlayingCardID });
        }

        private bool GradingExists(int id)
        {
            return _context.Gradings.Any(e => e.ID == id);
        }
    }
}
