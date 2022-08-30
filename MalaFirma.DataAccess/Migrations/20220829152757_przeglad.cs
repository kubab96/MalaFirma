using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MalaFirma.DataAccess.Migrations
{
    public partial class przeglad : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PlanowaneDzialania",
                table: "Przeglady",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ZidentyfikowaneProblemy",
                table: "Przeglady",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PlanowaneDzialania",
                table: "Przeglady");

            migrationBuilder.DropColumn(
                name: "ZidentyfikowaneProblemy",
                table: "Przeglady");
        }
    }
}
