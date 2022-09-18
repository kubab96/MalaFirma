﻿// <auto-generated />
using System;
using MalaFirma.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MalaFirma.DataAccess.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("MalaFirma.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("Imie")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KodPocztowy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Kraj")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Miasto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nazwisko")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UlicaNumer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "1508e8c0-33d9-41c4-9376-d72ee701cb02",
                            EmailConfirmed = true,
                            Imie = "Admin",
                            KodPocztowy = "",
                            Kraj = "",
                            LockoutEnabled = false,
                            Miasto = "",
                            Nazwisko = "",
                            NormalizedUserName = "admin",
                            PasswordHash = "AQAAAAEAACcQAAAAEBNPQOZvPbQ+4nL4qGyEcDT9wFJerlECirNkRGTL2mODiNjLyLMVZyIgA2s2qUhHUw==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "",
                            TwoFactorEnabled = false,
                            UlicaNumer = "",
                            UserName = "admin"
                        });
                });

            modelBuilder.Entity("MalaFirma.Models.Audyt", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("DataRozpoczecia")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataZakonczenia")
                        .HasColumnType("datetime2");

                    b.Property<string>("Opis")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RodzajAudytu")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Temat")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("TerminUsuniecia")
                        .HasColumnType("datetime2");

                    b.Property<string>("Uwagi")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Audyty");
                });

            modelBuilder.Entity("MalaFirma.Models.Dostawca", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("AdresDostwacy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DataWygasniecia")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataZatwierdzenia")
                        .HasColumnType("datetime2");

                    b.Property<string>("NazwaDostawcy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Uwagi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ZakresDzialalnosci")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Dostawcy");
                });

            modelBuilder.Entity("MalaFirma.Models.KartaProjektu", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("DodatkoweInformacje")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DodatkoweUwagi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PrzegladId")
                        .HasColumnType("int");

                    b.Property<int>("ZamowienieId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PrzegladId");

                    b.HasIndex("ZamowienieId");

                    b.ToTable("KartaProjektu");
                });

            modelBuilder.Entity("MalaFirma.Models.Klient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("KodPocztowy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Kraj")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Miasto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NazwaKlienta")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UlicaNumer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ZamowienieId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ZamowienieId");

                    b.ToTable("Klient");
                });

            modelBuilder.Entity("MalaFirma.Models.Narzedzie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Nazwa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumerFabryczny")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("ObslugaMetrologiczna")
                        .HasColumnType("bit");

                    b.Property<int>("TypNarzedziaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TypNarzedziaId");

                    b.ToTable("Narzedzia");
                });

            modelBuilder.Entity("MalaFirma.Models.ObslugaMetrologiczna", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("DataObslugi")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataWaznosci")
                        .HasColumnType("datetime2");

                    b.Property<int>("NarzedzieId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("NarzedzieId");

                    b.ToTable("ObslugaMetrologiczna");
                });

            modelBuilder.Entity("MalaFirma.Models.Odpowiedz", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("DataPrzegladu")
                        .HasColumnType("datetime2");

                    b.Property<int>("PrzegladId")
                        .HasColumnType("int");

                    b.Property<int>("PytanieId")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Wartosc")
                        .HasColumnType("bit");

                    b.Property<string>("WymaganeDzialania")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PrzegladId");

                    b.HasIndex("PytanieId");

                    b.ToTable("Odpowiedzi");
                });

            modelBuilder.Entity("MalaFirma.Models.Operacja", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("DataWykonania")
                        .HasColumnType("datetime2");

                    b.Property<int>("PrzewodnikPracyId")
                        .HasColumnType("int");

                    b.Property<string>("TrescOperacji")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PrzewodnikPracyId");

                    b.ToTable("Operacje");
                });

            modelBuilder.Entity("MalaFirma.Models.Przeglad", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("DataPrzegladu")
                        .HasColumnType("datetime2");

                    b.Property<string>("PlanowaneDzialania")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WynikPrzegladu")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ZidentyfikowaneProblemy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("zamowienieId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("zamowienieId");

                    b.ToTable("Przeglady");
                });

            modelBuilder.Entity("MalaFirma.Models.PrzewodnikPracy", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("DataZakonczeniaPrzewodnika")
                        .HasColumnType("datetime2");

                    b.Property<string>("NumerPrzewodnika")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumerRysunku")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PlanowaneDzialania")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Rysunek")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("WymaganieId")
                        .HasColumnType("int");

                    b.Property<string>("WynikPrzewodnika")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ZidentyfikowaneProblemy")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("WymaganieId");

                    b.ToTable("PrzewodnikPracy");
                });

            modelBuilder.Entity("MalaFirma.Models.Przywieszka", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("NumerPrzywieszki")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Rysunek")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SwiadectwoJakosciId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SwiadectwoJakosciId");

                    b.ToTable("Przywieszki");
                });

            modelBuilder.Entity("MalaFirma.Models.Pytanie", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Nazwa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Pytania");
                });

            modelBuilder.Entity("MalaFirma.Models.RysunekPrzewodnika", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("NumerRysunku")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Rysunek")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("WymaganieId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("WymaganieId");

                    b.ToTable("RysunekPrzewodnikow");
                });

            modelBuilder.Entity("MalaFirma.Models.SwiadectwoJakosci", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("DataZakonczeniaSwiadectwa")
                        .HasColumnType("datetime2");

                    b.Property<string>("NumerSwiadectwa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PlanowaneDzialania")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("WymaganieId")
                        .HasColumnType("int");

                    b.Property<string>("WynikSwiadectwa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ZidentyfikowaneProblemy")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("WymaganieId");

                    b.ToTable("SwiadectwoJakosci");
                });

            modelBuilder.Entity("MalaFirma.Models.Szkolenie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("DataRozpoczecia")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataZakonczenia")
                        .HasColumnType("datetime2");

                    b.Property<int>("RodzajSz")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Temat")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Uwagi")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Szkolenia");
                });

            modelBuilder.Entity("MalaFirma.Models.TypNarzedzia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("NazwaTypu")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TypNarzedzia");
                });

            modelBuilder.Entity("MalaFirma.Models.Wymaganie", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<int?>("Ilosc")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<string>("Material")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nazwa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Opis")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ZamowienieId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ZamowienieId");

                    b.ToTable("Wymagania");
                });

            modelBuilder.Entity("MalaFirma.Models.ZadowolenieKlienta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CzasRealizacji")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataZakonczeniaZadowolenia")
                        .HasColumnType("datetime2");

                    b.Property<int>("Jakosc")
                        .HasColumnType("int");

                    b.Property<int>("KlientId")
                        .HasColumnType("int");

                    b.Property<string>("Uwagi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ZamowienieId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("KlientId");

                    b.HasIndex("ZamowienieId");

                    b.ToTable("ZadowolenieKlientow");
                });

            modelBuilder.Entity("MalaFirma.Models.Zamowienie", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataZamowienia")
                        .HasColumnType("datetime2");

                    b.Property<int?>("KlientId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<string>("Nazwa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StatusZamowienia")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UwagiZamowienia")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Zamowienia");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                            ConcurrencyStamp = "84c4ea54-19ca-41a9-a898-dc7792ef03e4",
                            Name = "Admin",
                            NormalizedName = "Admin"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                            RoleId = "a18be9c0-aa65-4af8-bd17-00bd9344e575"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("MalaFirma.Models.KartaProjektu", b =>
                {
                    b.HasOne("MalaFirma.Models.Przeglad", "Przeglad")
                        .WithMany()
                        .HasForeignKey("PrzegladId");

                    b.HasOne("MalaFirma.Models.Zamowienie", "Zamowienie")
                        .WithMany()
                        .HasForeignKey("ZamowienieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Przeglad");

                    b.Navigation("Zamowienie");
                });

            modelBuilder.Entity("MalaFirma.Models.Klient", b =>
                {
                    b.HasOne("MalaFirma.Models.Zamowienie", null)
                        .WithMany("Klient")
                        .HasForeignKey("ZamowienieId")
                        .OnDelete(DeleteBehavior.SetNull);
                });

            modelBuilder.Entity("MalaFirma.Models.Narzedzie", b =>
                {
                    b.HasOne("MalaFirma.Models.TypNarzedzia", "TypNarzedzia")
                        .WithMany()
                        .HasForeignKey("TypNarzedziaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TypNarzedzia");
                });

            modelBuilder.Entity("MalaFirma.Models.ObslugaMetrologiczna", b =>
                {
                    b.HasOne("MalaFirma.Models.Narzedzie", "Narzedzie")
                        .WithMany()
                        .HasForeignKey("NarzedzieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Narzedzie");
                });

            modelBuilder.Entity("MalaFirma.Models.Odpowiedz", b =>
                {
                    b.HasOne("MalaFirma.Models.Przeglad", "Przeglad")
                        .WithMany()
                        .HasForeignKey("PrzegladId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MalaFirma.Models.Pytanie", "Pytanie")
                        .WithMany()
                        .HasForeignKey("PytanieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Przeglad");

                    b.Navigation("Pytanie");
                });

            modelBuilder.Entity("MalaFirma.Models.Operacja", b =>
                {
                    b.HasOne("MalaFirma.Models.PrzewodnikPracy", "PrzewodnikPracy")
                        .WithMany()
                        .HasForeignKey("PrzewodnikPracyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PrzewodnikPracy");
                });

            modelBuilder.Entity("MalaFirma.Models.Przeglad", b =>
                {
                    b.HasOne("MalaFirma.Models.Zamowienie", "Zamowienie")
                        .WithMany()
                        .HasForeignKey("zamowienieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Zamowienie");
                });

            modelBuilder.Entity("MalaFirma.Models.PrzewodnikPracy", b =>
                {
                    b.HasOne("MalaFirma.Models.Wymaganie", "Wymaganie")
                        .WithMany()
                        .HasForeignKey("WymaganieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Wymaganie");
                });

            modelBuilder.Entity("MalaFirma.Models.Przywieszka", b =>
                {
                    b.HasOne("MalaFirma.Models.SwiadectwoJakosci", "SwiadectwoJakosci")
                        .WithMany()
                        .HasForeignKey("SwiadectwoJakosciId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SwiadectwoJakosci");
                });

            modelBuilder.Entity("MalaFirma.Models.RysunekPrzewodnika", b =>
                {
                    b.HasOne("MalaFirma.Models.Wymaganie", "Wymaganie")
                        .WithMany()
                        .HasForeignKey("WymaganieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Wymaganie");
                });

            modelBuilder.Entity("MalaFirma.Models.SwiadectwoJakosci", b =>
                {
                    b.HasOne("MalaFirma.Models.Wymaganie", "Wymaganie")
                        .WithMany()
                        .HasForeignKey("WymaganieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Wymaganie");
                });

            modelBuilder.Entity("MalaFirma.Models.Wymaganie", b =>
                {
                    b.HasOne("MalaFirma.Models.Zamowienie", "Zamowienie")
                        .WithMany()
                        .HasForeignKey("ZamowienieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Zamowienie");
                });

            modelBuilder.Entity("MalaFirma.Models.ZadowolenieKlienta", b =>
                {
                    b.HasOne("MalaFirma.Models.Klient", "Klient")
                        .WithMany()
                        .HasForeignKey("KlientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MalaFirma.Models.Zamowienie", "Zamowienie")
                        .WithMany()
                        .HasForeignKey("ZamowienieId");

                    b.Navigation("Klient");

                    b.Navigation("Zamowienie");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("MalaFirma.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("MalaFirma.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MalaFirma.Models.ApplicationUser", null)
                        .WithMany("Roles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("MalaFirma.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MalaFirma.Models.ApplicationUser", b =>
                {
                    b.Navigation("Roles");
                });

            modelBuilder.Entity("MalaFirma.Models.Zamowienie", b =>
                {
                    b.Navigation("Klient");
                });
#pragma warning restore 612, 618
        }
    }
}
