using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CardVaultApp.Data;
using CardVaultApp.Models;

namespace CardVaultApp.Pages_Gradings
{
    public class DeleteModel : PageModel
    {
        private readonly CardVaultApp.Data.ApplicationDbContext _context;

        public DeleteModel(CardVaultApp.Data.ApplicationDbContext context)
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

            var grading = await _context.Gradings.FirstOrDefaultAsync(m => m.ID == id);

            if (grading is not null)
            {
                Grading = grading;

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

            var grading = await _context.Gradings.FindAsync(id);
            if (grading != null)
            {
                Grading = grading;
                _context.Gradings.Remove(Grading);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
