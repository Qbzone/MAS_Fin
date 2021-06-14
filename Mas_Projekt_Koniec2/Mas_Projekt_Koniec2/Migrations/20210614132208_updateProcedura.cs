using Microsoft.EntityFrameworkCore.Migrations;

namespace Mas_Projekt_Koniec2.Migrations
{
    public partial class updateProcedura : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Procedura",
                keyColumn: "Id",
                keyValue: 3L,
                column: "WymaganaSpecjalizacja",
                value: "Diagnosta");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Procedura",
                keyColumn: "Id",
                keyValue: 3L,
                column: "WymaganaSpecjalizacja",
                value: "Dowolna");
        }
    }
}
