using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MalaFirma.DataAccess.Migrations
{
    public partial class sa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PrzewodnikPracyId",
                table: "Operacje",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Operacje_PrzewodnikPracyId",
                table: "Operacje",
                column: "PrzewodnikPracyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Operacje_PrzewodnikPracy_PrzewodnikPracyId",
                table: "Operacje",
                column: "PrzewodnikPracyId",
                principalTable: "PrzewodnikPracy",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Operacje_PrzewodnikPracy_PrzewodnikPracyId",
                table: "Operacje");

            migrationBuilder.DropIndex(
                name: "IX_Operacje_PrzewodnikPracyId",
                table: "Operacje");

            migrationBuilder.DropColumn(
                name: "PrzewodnikPracyId",
                table: "Operacje");
        }
    }
}
