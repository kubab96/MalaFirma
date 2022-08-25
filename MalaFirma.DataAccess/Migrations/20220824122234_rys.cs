using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MalaFirma.DataAccess.Migrations
{
    public partial class rys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Rysunek",
                table: "PrzewodnikPracy",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rysunek",
                table: "PrzewodnikPracy");
        }
    }
}
