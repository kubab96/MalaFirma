using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MalaFirma.DataAccess.Migrations
{
    public partial class rys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateIndex(
                name: "IX_RysunekPrzewodnikow_WymaganieId",
                table: "RysunekPrzewodnikow",
                column: "WymaganieId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RysunekPrzewodnikow");
        }
    }
}
