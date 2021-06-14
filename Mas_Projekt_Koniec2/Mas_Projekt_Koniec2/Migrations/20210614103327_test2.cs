using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Mas_Projekt_Koniec2.Migrations
{
    public partial class test2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataPrzypisania",
                table: "PakietMedycznyProcedura",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "PakietMedycznyProcedura",
                keyColumns: new[] { "PakietMedycznyId", "ProceduraId" },
                keyValues: new object[] { 1L, 1L },
                column: "DataPrzypisania",
                value: new DateTime(2020, 8, 8, 3, 3, 3, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "PakietMedycznyProcedura",
                keyColumns: new[] { "PakietMedycznyId", "ProceduraId" },
                keyValues: new object[] { 1L, 2L },
                column: "DataPrzypisania",
                value: new DateTime(2019, 8, 8, 3, 3, 3, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataPrzypisania",
                table: "PakietMedycznyProcedura");
        }
    }
}
