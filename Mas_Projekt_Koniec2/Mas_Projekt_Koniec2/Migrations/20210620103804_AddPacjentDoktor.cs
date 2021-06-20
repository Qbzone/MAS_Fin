using Microsoft.EntityFrameworkCore.Migrations;

namespace Mas_Projekt_Koniec2.Migrations
{
    public partial class AddPacjentDoktor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Pracownik",
                columns: new[] { "Id", "Discriminator", "OsobaId", "Pensja", "SpecjalizacjaDoktor", "ZespolOperacyjnyId" },
                values: new object[] { 3L, "Doktor", 3L, 3300, "Laryngolog", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Pracownik",
                keyColumn: "Id",
                keyValue: 3L);
        }
    }
}
