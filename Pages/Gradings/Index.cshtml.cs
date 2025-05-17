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
    public class IndexModel : PageModel
    {
        private readonly CardVaultApp.Data.ApplicationDbContext _context;

        public IndexModel(CardVaultApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Grading> Grading { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Grading = await _context.Gradings
                .Include(g => g.PlayingCard).ToListAsync();
        }
    }
}
