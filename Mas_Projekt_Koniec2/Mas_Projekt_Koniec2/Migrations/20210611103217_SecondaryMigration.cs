using Microsoft.EntityFrameworkCore.Migrations;

namespace Mas_Projekt_Koniec2.Migrations
{
    public partial class SecondaryMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "WymaganaSpecjalizacja",
                table: "Procedura",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Procedura",
                keyColumn: "Id",
                keyValue: 1L,
                column: "WymaganaSpecjalizacja",
                value: "Dowolna");

            migrationBuilder.UpdateData(
                table: "Procedura",
                keyColumn: "Id",
                keyValue: 2L,
                column: "WymaganaSpecjalizacja",
                value: "Kardiolog");

            migrationBuilder.UpdateData(
                table: "Procedura",
                keyColumn: "Id",
                keyValue: 3L,
                column: "WymaganaSpecjalizacja",
                value: "Dowolna");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WymaganaSpecjalizacja",
                table: "Procedura");
        }
    }
}
