using MalaFirma.Models;
using Microsoft.EntityFrameworkCore;

namespace MalaFirma.DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Zamowienie> Zamowienia { get; set; }
        public DbSet<Proces> Procesy { get; set; }
    }
}
