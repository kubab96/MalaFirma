    using MalaFirma.Models;
using MalaFirma.Utility;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MalaFirma.DataAccess
{
    public class ApplicationDbContext : IdentityDbContext/*<ApplicationUser>*/
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ApplicationUser>(b =>
            {
                //Each User can have many entries in the UserRole join table
                b.HasMany(e => e.Roles)
                    .WithOne()
                    .HasForeignKey(ur => ur.UserId)
                    .IsRequired();
            });
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
        public DbSet<Audyt> Audyty { get; set; }
        public DbSet<Szkolenie> Szkolenia { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Przywieszka> Przywieszki { get; set; }
        public DbSet<ZadowolenieKlienta> ZadowolenieKlientow { get; set; }
    }
}
