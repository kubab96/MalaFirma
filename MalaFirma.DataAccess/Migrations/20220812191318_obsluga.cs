using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MalaFirma.DataAccess.Migrations
{
    public partial class obsluga : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateIndex(
                name: "IX_ObslugaMetrologiczna_NarzedzieId",
                table: "ObslugaMetrologiczna",
                column: "NarzedzieId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ObslugaMetrologiczna");
        }
    }
}
