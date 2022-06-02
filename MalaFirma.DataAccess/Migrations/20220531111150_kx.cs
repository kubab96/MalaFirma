using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MalaFirma.DataAccess.Migrations
{
    public partial class kx : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "KlientId",
                table: "Zamowienia",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Zamowienia_KlientId",
                table: "Zamowienia",
                column: "KlientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Zamowienia_Klient_KlientId",
                table: "Zamowienia",
                column: "KlientId",
                principalTable: "Klient",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Zamowienia_Klient_KlientId",
                table: "Zamowienia");

            migrationBuilder.DropIndex(
                name: "IX_Zamowienia_KlientId",
                table: "Zamowienia");

            migrationBuilder.DropColumn(
                name: "KlientId",
                table: "Zamowienia");
        }
    }
}
