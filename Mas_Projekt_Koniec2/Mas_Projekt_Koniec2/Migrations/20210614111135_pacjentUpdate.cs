using Microsoft.EntityFrameworkCore.Migrations;

namespace Mas_Projekt_Koniec2.Migrations
{
    public partial class pacjentUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Pacjent",
                keyColumn: "Id",
                keyValue: 3L,
                column: "UbezpiecznieZdrowotne",
                value: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Pacjent",
                keyColumn: "Id",
                keyValue: 3L,
                column: "UbezpiecznieZdrowotne",
                value: true);
        }
    }
}
