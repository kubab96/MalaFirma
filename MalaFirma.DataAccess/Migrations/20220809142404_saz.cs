using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MalaFirma.DataAccess.Migrations
{
    public partial class saz : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Operacje_PrzewodnikPracy_PrzewodnikPracyId",
                table: "Operacje");

            migrationBuilder.RenameColumn(
                name: "PrzewodnikPracyId",
                table: "Operacje",
                newName: "ProcesId");

            migrationBuilder.RenameIndex(
                name: "IX_Operacje_PrzewodnikPracyId",
                table: "Operacje",
                newName: "IX_Operacje_ProcesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Operacje_Procesy_ProcesId",
                table: "Operacje",
                column: "ProcesId",
                principalTable: "Procesy",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Operacje_Procesy_ProcesId",
                table: "Operacje");

            migrationBuilder.RenameColumn(
                name: "ProcesId",
                table: "Operacje",
                newName: "PrzewodnikPracyId");

            migrationBuilder.RenameIndex(
                name: "IX_Operacje_ProcesId",
                table: "Operacje",
                newName: "IX_Operacje_PrzewodnikPracyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Operacje_PrzewodnikPracy_PrzewodnikPracyId",
                table: "Operacje",
                column: "PrzewodnikPracyId",
                principalTable: "PrzewodnikPracy",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
