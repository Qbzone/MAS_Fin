using Microsoft.EntityFrameworkCore.Migrations;

namespace Mas_Projekt_Koniec2.Migrations
{
    public partial class Test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Pacjent_OsobaId",
                table: "Pacjent");

            migrationBuilder.CreateIndex(
                name: "IX_Pacjent_OsobaId",
                table: "Pacjent",
                column: "OsobaId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Pacjent_OsobaId",
                table: "Pacjent");

            migrationBuilder.CreateIndex(
                name: "IX_Pacjent_OsobaId",
                table: "Pacjent",
                column: "OsobaId");
        }
    }
}
