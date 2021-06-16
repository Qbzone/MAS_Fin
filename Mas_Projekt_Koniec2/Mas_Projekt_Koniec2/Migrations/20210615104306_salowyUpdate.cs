using Microsoft.EntityFrameworkCore.Migrations;

namespace Mas_Projekt_Koniec2.Migrations
{
    public partial class salowyUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "CzyPelniFunkcjePomocnicza",
                table: "Pracownik",
                type: "bit",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CzyPelniFunkcjePomocnicza",
                table: "Pracownik");
        }
    }
}
