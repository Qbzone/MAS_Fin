using Microsoft.EntityFrameworkCore.Migrations;

namespace Mas_Projekt_Koniec2.Migrations
{
    public partial class addUsg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Procedura",
                columns: new[] { "Id", "CzyPotrzebnyZespolOperacyjny", "CzyProceduraInwazyjna", "KosztProcedura", "NazwaProcedura", "WymaganaSpecjalizacja" },
                values: new object[] { 4L, false, false, 140, "Usg Serca", "Kardiolog" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Procedura",
                keyColumn: "Id",
                keyValue: 4L);
        }
    }
}
