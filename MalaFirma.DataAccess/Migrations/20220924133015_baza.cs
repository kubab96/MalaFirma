using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimpleQMS.DataAccess.Migrations
{
    public partial class baza : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Imie = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nazwisko = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Kraj = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Miasto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UlicaNumer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KodPocztowy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Audyty",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Temat = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataRozpoczecia = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataZakonczenia = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Opis = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Uwagi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TerminUsuniecia = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RodzajAudytu = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Audyty", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Dostawcy",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NazwaDostawcy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdresDostwacy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ZakresDzialalnosci = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataZatwierdzenia = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataWygasniecia = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Uwagi = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dostawcy", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pytania",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Nazwa = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pytania", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Szkolenia",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Temat = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataRozpoczecia = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataZakonczenia = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Uwagi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RodzajSz = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Szkolenia", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypNarzedzia",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NazwaTypu = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypNarzedzia", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Zamowienia",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Nazwa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataZamowienia = table.Column<DateTime>(type: "datetime2", nullable: false),
                    KlientId = table.Column<int>(type: "int", nullable: false),
                    UwagiZamowienia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StatusZamowienia = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zamowienia", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Narzedzia",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumerFabryczny = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ObslugaMetrologiczna = table.Column<bool>(type: "bit", nullable: false),
                    TypNarzedziaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Narzedzia", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Narzedzia_TypNarzedzia_TypNarzedziaId",
                        column: x => x.TypNarzedziaId,
                        principalTable: "TypNarzedzia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Klient",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NazwaKlienta = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Kraj = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Miasto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UlicaNumer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KodPocztowy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ZamowienieId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Klient", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Klient_Zamowienia_ZamowienieId",
                        column: x => x.ZamowienieId,
                        principalTable: "Zamowienia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Przeglady",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WynikPrzegladu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ZidentyfikowaneProblemy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlanowaneDzialania = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataPrzegladu = table.Column<DateTime>(type: "datetime2", nullable: false),
                    zamowienieId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Przeglady", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Przeglady_Zamowienia_zamowienieId",
                        column: x => x.zamowienieId,
                        principalTable: "Zamowienia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Wymagania",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Nazwa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Opis = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ilosc = table.Column<int>(type: "int", nullable: false),
                    Material = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ZamowienieId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wymagania", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Wymagania_Zamowienia_ZamowienieId",
                        column: x => x.ZamowienieId,
                        principalTable: "Zamowienia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ObslugaMetrologiczna",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataObslugi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataWaznosci = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NarzedzieId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ObslugaMetrologiczna", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ObslugaMetrologiczna_Narzedzia_NarzedzieId",
                        column: x => x.NarzedzieId,
                        principalTable: "Narzedzia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ZadowolenieKlientow",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CzasRealizacji = table.Column<int>(type: "int", nullable: false),
                    Jakosc = table.Column<int>(type: "int", nullable: false),
                    Uwagi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataZakonczeniaZadowolenia = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ZamowienieId = table.Column<int>(type: "int", nullable: true),
                    KlientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZadowolenieKlientow", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ZadowolenieKlientow_Klient_KlientId",
                        column: x => x.KlientId,
                        principalTable: "Klient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ZadowolenieKlientow_Zamowienia_ZamowienieId",
                        column: x => x.ZamowienieId,
                        principalTable: "Zamowienia",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "KartaProjektu",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    PrzegladId = table.Column<int>(type: "int", nullable: true),
                    ZamowienieId = table.Column<int>(type: "int", nullable: false),
                    DodatkoweInformacje = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumerKarty = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DodatkoweUwagi = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KartaProjektu", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KartaProjektu_Przeglady_PrzegladId",
                        column: x => x.PrzegladId,
                        principalTable: "Przeglady",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_KartaProjektu_Zamowienia_ZamowienieId",
                        column: x => x.ZamowienieId,
                        principalTable: "Zamowienia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Odpowiedzi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Wartosc = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataPrzegladu = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WymaganeDzialania = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PytanieId = table.Column<int>(type: "int", nullable: false),
                    PrzegladId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Odpowiedzi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Odpowiedzi_Przeglady_PrzegladId",
                        column: x => x.PrzegladId,
                        principalTable: "Przeglady",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Odpowiedzi_Pytania_PytanieId",
                        column: x => x.PytanieId,
                        principalTable: "Pytania",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PrzewodnikPracy",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumerPrzewodnika = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WynikPrzewodnika = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataZakonczeniaPrzewodnika = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ZidentyfikowaneProblemy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlanowaneDzialania = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rysunek = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumerRysunku = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WymaganieId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrzewodnikPracy", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PrzewodnikPracy_Wymagania_WymaganieId",
                        column: x => x.WymaganieId,
                        principalTable: "Wymagania",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RysunekPrzewodnikow",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rysunek = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumerRysunku = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WymaganieId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RysunekPrzewodnikow", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RysunekPrzewodnikow_Wymagania_WymaganieId",
                        column: x => x.WymaganieId,
                        principalTable: "Wymagania",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SwiadectwoJakosci",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumerSwiadectwa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WynikSwiadectwa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ZidentyfikowaneProblemy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlanowaneDzialania = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataZakonczeniaSwiadectwa = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WymaganieId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SwiadectwoJakosci", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SwiadectwoJakosci_Wymagania_WymaganieId",
                        column: x => x.WymaganieId,
                        principalTable: "Wymagania",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Operacje",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrescOperacji = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataWykonania = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PrzewodnikPracyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operacje", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Operacje_PrzewodnikPracy_PrzewodnikPracyId",
                        column: x => x.PrzewodnikPracyId,
                        principalTable: "PrzewodnikPracy",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Przywieszki",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rysunek = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumerPrzywieszki = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SwiadectwoJakosciId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Przywieszki", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Przywieszki_SwiadectwoJakosci_SwiadectwoJakosciId",
                        column: x => x.SwiadectwoJakosciId,
                        principalTable: "SwiadectwoJakosci",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a18be9c0-aa65-4af8-bd17-00bd9344e575", "c5dccf36-4fbd-432c-8004-2a961848dbe2", "Admin", "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "Imie", "KodPocztowy", "Kraj", "LockoutEnabled", "LockoutEnd", "Miasto", "Nazwisko", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UlicaNumer", "UserName" },
                values: new object[] { "a18be9c0-aa65-4af8-bd17-00bd9344e575", 0, "d56f6467-8929-450d-b100-5a0ca2a8fb90", null, true, "Admin", "", "", false, null, "", "", null, "admin", "AQAAAAEAACcQAAAAEEWxx3K5Mwbe0EUDhZqyCAkv0cl47t88bz5bVSI/DoQoRIUJMVoAIkQghq7+oLVjpQ==", null, false, "", false, "", "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "a18be9c0-aa65-4af8-bd17-00bd9344e575", "a18be9c0-aa65-4af8-bd17-00bd9344e575" });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_KartaProjektu_PrzegladId",
                table: "KartaProjektu",
                column: "PrzegladId");

            migrationBuilder.CreateIndex(
                name: "IX_KartaProjektu_ZamowienieId",
                table: "KartaProjektu",
                column: "ZamowienieId");

            migrationBuilder.CreateIndex(
                name: "IX_Klient_ZamowienieId",
                table: "Klient",
                column: "ZamowienieId");

            migrationBuilder.CreateIndex(
                name: "IX_Narzedzia_TypNarzedziaId",
                table: "Narzedzia",
                column: "TypNarzedziaId");

            migrationBuilder.CreateIndex(
                name: "IX_ObslugaMetrologiczna_NarzedzieId",
                table: "ObslugaMetrologiczna",
                column: "NarzedzieId");

            migrationBuilder.CreateIndex(
                name: "IX_Odpowiedzi_PrzegladId",
                table: "Odpowiedzi",
                column: "PrzegladId");

            migrationBuilder.CreateIndex(
                name: "IX_Odpowiedzi_PytanieId",
                table: "Odpowiedzi",
                column: "PytanieId");

            migrationBuilder.CreateIndex(
                name: "IX_Operacje_PrzewodnikPracyId",
                table: "Operacje",
                column: "PrzewodnikPracyId");

            migrationBuilder.CreateIndex(
                name: "IX_Przeglady_zamowienieId",
                table: "Przeglady",
                column: "zamowienieId");

            migrationBuilder.CreateIndex(
                name: "IX_PrzewodnikPracy_WymaganieId",
                table: "PrzewodnikPracy",
                column: "WymaganieId");

            migrationBuilder.CreateIndex(
                name: "IX_Przywieszki_SwiadectwoJakosciId",
                table: "Przywieszki",
                column: "SwiadectwoJakosciId");

            migrationBuilder.CreateIndex(
                name: "IX_RysunekPrzewodnikow_WymaganieId",
                table: "RysunekPrzewodnikow",
                column: "WymaganieId");

            migrationBuilder.CreateIndex(
                name: "IX_SwiadectwoJakosci_WymaganieId",
                table: "SwiadectwoJakosci",
                column: "WymaganieId");

            migrationBuilder.CreateIndex(
                name: "IX_Wymagania_ZamowienieId",
                table: "Wymagania",
                column: "ZamowienieId");

            migrationBuilder.CreateIndex(
                name: "IX_ZadowolenieKlientow_KlientId",
                table: "ZadowolenieKlientow",
                column: "KlientId");

            migrationBuilder.CreateIndex(
                name: "IX_ZadowolenieKlientow_ZamowienieId",
                table: "ZadowolenieKlientow",
                column: "ZamowienieId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Audyty");

            migrationBuilder.DropTable(
                name: "Dostawcy");

            migrationBuilder.DropTable(
                name: "KartaProjektu");

            migrationBuilder.DropTable(
                name: "ObslugaMetrologiczna");

            migrationBuilder.DropTable(
                name: "Odpowiedzi");

            migrationBuilder.DropTable(
                name: "Operacje");

            migrationBuilder.DropTable(
                name: "Przywieszki");

            migrationBuilder.DropTable(
                name: "RysunekPrzewodnikow");

            migrationBuilder.DropTable(
                name: "Szkolenia");

            migrationBuilder.DropTable(
                name: "ZadowolenieKlientow");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Narzedzia");

            migrationBuilder.DropTable(
                name: "Przeglady");

            migrationBuilder.DropTable(
                name: "Pytania");

            migrationBuilder.DropTable(
                name: "PrzewodnikPracy");

            migrationBuilder.DropTable(
                name: "SwiadectwoJakosci");

            migrationBuilder.DropTable(
                name: "Klient");

            migrationBuilder.DropTable(
                name: "TypNarzedzia");

            migrationBuilder.DropTable(
                name: "Wymagania");

            migrationBuilder.DropTable(
                name: "Zamowienia");
        }
    }
}
