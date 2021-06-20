using Microsoft.EntityFrameworkCore.Migrations;

namespace Mas_Projekt_Koniec2.Migrations
{
    public partial class AddGoodPacjentDoktor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Pracownik",
                keyColumn: "Id",
                keyValue: 3L,
                column: "OsobaId",
                value: 2L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Pracownik",
                keyColumn: "Id",
                keyValue: 3L,
                column: "OsobaId",
                value: 3L);
        }
    }
}
