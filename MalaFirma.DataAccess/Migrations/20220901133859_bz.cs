using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MalaFirma.DataAccess.Migrations
{
    public partial class bz : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RodzajSzkolenia",
                table: "Szkolenia",
                newName: "RodzajSz");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RodzajSz",
                table: "Szkolenia",
                newName: "RodzajSzkolenia");
        }
    }
}
