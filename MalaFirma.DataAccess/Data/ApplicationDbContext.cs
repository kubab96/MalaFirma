using SimpleQMS.Models;
using SimpleQMS.Utility;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace SimpleQMS.DataAccess
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            const string ADMIN_ID = "a18be9c0-aa65-4af8-bd17-00bd9344e575";
            // any guid, but nothing is against to use the same one
            const string ROLE_ID = ADMIN_ID;
            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = ROLE_ID,
                Name = "Admin",
                NormalizedName = "Admin"
            });

            var hasher = new PasswordHasher<ApplicationUser>();
            modelBuilder.Entity<ApplicationUser>().HasData(new ApplicationUser
            {
                Id = ADMIN_ID,
                UserName = "admin",
                NormalizedUserName = "admin",
                Imie = "Admin",
                Nazwisko = "",
                KodPocztowy = "",
                Miasto = "",
                UlicaNumer = "",
                Kraj = "",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "admin!23"),
                SecurityStamp = string.Empty
            });

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = ROLE_ID,
                UserId = ADMIN_ID
            });









            //string ADMIN_ID = "02174cf0–9412–4cfe-afbf-59f706d72cf6";
            //string ROLE_ID = "341743f0-asd2–42de-afbf-59kmkkmk72cf6";

            ////seed admin role
            //modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            //{
            //    Name = "admin",
            //    NormalizedName = "admin",
            //    Id = ROLE_ID,
            //    ConcurrencyStamp = ROLE_ID,
            //});


            //var appUser = new ApplicationUser
            //{
            //    Id = ADMIN_ID,
            //    Email = "Admin",
            //    EmailConfirmed = true,
            //    UserName = "Admin",
            //    Imie = "Admin",
            //    Nazwisko = "",
            //    KodPocztowy = "",
            //    Miasto = "",
            //    UlicaNumer = "",
            //    Kraj = ""
            //};

            //var hasher = new PasswordHasher<ApplicationUser>();
            //appUser.PasswordHash = hasher.HashPassword(appUser, "admin");

            ////seed user
            //modelBuilder.Entity<ApplicationUser>().HasData(appUser);

            ////set user role to admin
            //modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            //{
            //    RoleId = ROLE_ID,
            //    UserId = ADMIN_ID
            //});


            modelBuilder.Entity<ApplicationUser>(b =>
            {
                //Each User can have many entries in the UserRole join table
                b.HasMany(e => e.Roles)
                    .WithOne()
                    .HasForeignKey(ur => ur.UserId)
                    .IsRequired();
            });

            modelBuilder.Entity<Zamowienie>()
                .HasMany(c => c.Klient)
                .WithOne()
                .OnDelete(DeleteBehavior.SetNull);

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
        public DbSet<RysunekPrzewodnika> RysunekPrzewodnikow { get; set; }

    }
}
