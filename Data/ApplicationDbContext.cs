using Microsoft.EntityFrameworkCore;
using CardVaultApp.Models;

namespace CardVaultApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<PlayingCard> PlayingCards { get; set; }
        public DbSet<Grading> Gradings { get; set; }
    }
}
