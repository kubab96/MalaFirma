using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MalaFirma.DataAccess.Migrations
{
    public partial class narzedzia : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateIndex(
                name: "IX_Narzedzia_TypNarzedziaId",
                table: "Narzedzia",
                column: "TypNarzedziaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Narzedzia");

            migrationBuilder.DropTable(
                name: "TypNarzedzia");
        }
    }
}
