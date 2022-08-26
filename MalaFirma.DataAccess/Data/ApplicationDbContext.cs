using MalaFirma.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MalaFirma.DataAccess
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Zamowienie> Zamowienia { get; set; }
        public DbSet<Wymaganie> Wymagania { get; set; }
        public DbSet<Pytanie> Pytania { get; set; }
        public DbSet<Odpowiedz> Odpowiedzi { get; set; }
        public DbSet<Narzedzie> Narzedzia { get; set; }
        public DbSet<TypNarzedzia> TypNarzedzia { get; set; }
        public DbSet<Dostawca> Dostawcy { get; set; }
        public DbSet<Przeglad> Przeglady { get; set; }
        public DbSet<Klient> Klient { get; set; }
        public DbSet<KartaProjektu> KartaProjektu { get; set; }
        public DbSet<PrzewodnikPracy> PrzewodnikPracy { get; set; }
        public DbSet<Operacja> Operacje { get; set; }
        public DbSet<SwiadectwoJakosci> SwiadectwoJakosci { get; set; }
        public DbSet<ObslugaMetrologiczna> ObslugaMetrologiczna { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        
        






    }
}
