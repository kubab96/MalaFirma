using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MalaFirma.DataAccess.Migrations
{
    public partial class dostawcy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dostawcy",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NazwaDostawcy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdresDostwacy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ZakresDzialalnosci = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Uwagi = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataZamowienia = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UwagiZamowienia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StatusZamowienia = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zamowienia", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Narzedzia",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumerFabryczny = table.Column<int>(type: "int", nullable: false),
                    ObslugaMetrologiczna = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    ZamowienieId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Odpowiedzi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Odpowiedzi_Pytania_PytanieId",
                        column: x => x.PytanieId,
                        principalTable: "Pytania",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Odpowiedzi_Zamowienia_ZamowienieId",
                        column: x => x.ZamowienieId,
                        principalTable: "Zamowienia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Procesy",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Nazwa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Opis = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ZamowienieId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Procesy", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Procesy_Zamowienia_ZamowienieId",
                        column: x => x.ZamowienieId,
                        principalTable: "Zamowienia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Narzedzia_TypNarzedziaId",
                table: "Narzedzia",
                column: "TypNarzedziaId");

            migrationBuilder.CreateIndex(
                name: "IX_Odpowiedzi_PytanieId",
                table: "Odpowiedzi",
                column: "PytanieId");

            migrationBuilder.CreateIndex(
                name: "IX_Odpowiedzi_ZamowienieId",
                table: "Odpowiedzi",
                column: "ZamowienieId");

            migrationBuilder.CreateIndex(
                name: "IX_Procesy_ZamowienieId",
                table: "Procesy",
                column: "ZamowienieId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dostawcy");

            migrationBuilder.DropTable(
                name: "Narzedzia");

            migrationBuilder.DropTable(
                name: "Odpowiedzi");

            migrationBuilder.DropTable(
                name: "Procesy");

            migrationBuilder.DropTable(
                name: "TypNarzedzia");

            migrationBuilder.DropTable(
                name: "Pytania");

            migrationBuilder.DropTable(
                name: "Zamowienia");
        }
    }
}
