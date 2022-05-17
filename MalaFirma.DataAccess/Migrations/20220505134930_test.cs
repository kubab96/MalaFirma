﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MalaFirma.DataAccess.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Zamowienia",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataZamowienia = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UwagiZamowienia = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zamowienia", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Procesy",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Nazwa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Wymaganie = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                name: "IX_Procesy_ZamowienieId",
                table: "Procesy",
                column: "ZamowienieId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Procesy");

            migrationBuilder.DropTable(
                name: "Zamowienia");
        }
    }
}
