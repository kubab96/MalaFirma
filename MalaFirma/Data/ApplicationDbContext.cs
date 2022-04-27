using MalaFirma.Models;
using Microsoft.EntityFrameworkCore;

namespace MalaFirma.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Zamowienie> Zamowienia { get; set; }
    }
}
