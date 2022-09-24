using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MalaFirma.DataAccess.Migrations
{
    public partial class f : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                column: "ConcurrencyStamp",
                value: "42ea5331-b50a-4d9e-a196-332380c41444");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "550207c1-0f96-4e8f-8c0c-18a1686dea79", "AQAAAAEAACcQAAAAEGeI4sbbOiJaJaf2zQoufbxHZpZw7GzSth35Odfd1cqzkSo5B05nlY0BhREx4FAddQ==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                column: "ConcurrencyStamp",
                value: "eb101234-a922-4e0d-86ea-d6b27a735cdb");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "b8358e8c-3877-4b60-a2da-7b4b9ac5da7e", "AQAAAAEAACcQAAAAEJTSHn2i25bXbPcwI25XXOZwwZ4GSwA4rkXhyNH/h0roXr9TFxLyE+kyN7k0zYOOZg==" });
        }
    }
}
