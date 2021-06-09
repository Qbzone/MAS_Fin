using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Mas_Projekt_Koniec2.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Osoba",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Imie = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Nazwisko = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DataUrodzenia = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Pesel = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    AdresZamieszkania = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: false),
                    NumerTelefonu = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: false),
                    AdresEmail = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Osoba", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PakietMedyczny",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PakietMedyczny", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Procedura",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Koszt = table.Column<int>(type: "int", nullable: false),
                    CzyPotrzebnyZespolOperacyjny = table.Column<bool>(type: "bit", nullable: false),
                    CzyProceduraInwazyjna = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Procedura", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ZespolOperacyjny",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZespolOperacyjny", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pacjent",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UbezpiecznieZdrowotne = table.Column<bool>(type: "bit", nullable: false),
                    OsobaId = table.Column<long>(type: "bigint", nullable: false),
                    PakietMedycznyId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pacjent", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pacjent_Osoba_OsobaId",
                        column: x => x.OsobaId,
                        principalTable: "Osoba",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pacjent_PakietMedyczny_PakietMedycznyId",
                        column: x => x.PakietMedycznyId,
                        principalTable: "PakietMedyczny",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PakietMedycznyProcedura",
                columns: table => new
                {
                    PakietMedycznyId = table.Column<long>(type: "bigint", nullable: false),
                    ProceduraId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PakietMedycznyProcedura_pk", x => new { x.PakietMedycznyId, x.ProceduraId });
                    table.ForeignKey(
                        name: "FK_PakietMedycznyProcedura_PakietMedyczny_PakietMedycznyId",
                        column: x => x.PakietMedycznyId,
                        principalTable: "PakietMedyczny",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PakietMedycznyProcedura_Procedura_ProceduraId",
                        column: x => x.ProceduraId,
                        principalTable: "Procedura",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pracownik",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Pensja = table.Column<int>(type: "int", nullable: false),
                    OsobaId = table.Column<long>(type: "bigint", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Doktor_Specjalizacja = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    Doktor_ZespolOperacyjnyId = table.Column<long>(type: "bigint", nullable: true),
                    Specjalizacja = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    ZespolOperacyjnyId = table.Column<long>(type: "bigint", nullable: true),
                    Salowy_ZespolOperacyjnyId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pracownik", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pracownik_Osoba_OsobaId",
                        column: x => x.OsobaId,
                        principalTable: "Osoba",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pracownik_ZespolOperacyjny_Doktor_ZespolOperacyjnyId",
                        column: x => x.Doktor_ZespolOperacyjnyId,
                        principalTable: "ZespolOperacyjny",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pracownik_ZespolOperacyjny_Salowy_ZespolOperacyjnyId",
                        column: x => x.Salowy_ZespolOperacyjnyId,
                        principalTable: "ZespolOperacyjny",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pracownik_ZespolOperacyjny_ZespolOperacyjnyId",
                        column: x => x.ZespolOperacyjnyId,
                        principalTable: "ZespolOperacyjny",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Hospitalizacja",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PoczatekHospitalizacji = table.Column<DateTime>(type: "datetime2", nullable: false),
                    KoniecHospitalizacji = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    PacjentId = table.Column<long>(type: "bigint", nullable: false),
                    ZespolOperacyjnyId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hospitalizacja", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Hospitalizacja_Pacjent_PacjentId",
                        column: x => x.PacjentId,
                        principalTable: "Pacjent",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Hospitalizacja_ZespolOperacyjny_ZespolOperacyjnyId",
                        column: x => x.ZespolOperacyjnyId,
                        principalTable: "ZespolOperacyjny",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Wizyta",
                columns: table => new
                {
                    PoczatekWizyty = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PacjentId = table.Column<long>(type: "bigint", nullable: false),
                    DoktorId = table.Column<long>(type: "bigint", nullable: false),
                    KoniecWizyty = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    ProceduraId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PakietMedycznyProcedura_pk", x => new { x.PacjentId, x.DoktorId, x.PoczatekWizyty });
                    table.ForeignKey(
                        name: "FK_Wizyta_Pacjent_PacjentId",
                        column: x => x.PacjentId,
                        principalTable: "Pacjent",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Wizyta_Pracownik_DoktorId",
                        column: x => x.DoktorId,
                        principalTable: "Pracownik",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Wizyta_Procedura_ProceduraId",
                        column: x => x.ProceduraId,
                        principalTable: "Procedura",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HospitalizacjaProcedura",
                columns: table => new
                {
                    ProceduraId = table.Column<long>(type: "bigint", nullable: false),
                    HospitalizacjaId = table.Column<long>(type: "bigint", nullable: false),
                    DataWykonania = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PakietMedycznyProcedura_pk", x => new { x.ProceduraId, x.HospitalizacjaId, x.DataWykonania });
                    table.ForeignKey(
                        name: "FK_HospitalizacjaProcedura_Hospitalizacja_HospitalizacjaId",
                        column: x => x.HospitalizacjaId,
                        principalTable: "Hospitalizacja",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HospitalizacjaProcedura_Procedura_ProceduraId",
                        column: x => x.ProceduraId,
                        principalTable: "Procedura",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Hospitalizacja_PacjentId",
                table: "Hospitalizacja",
                column: "PacjentId");

            migrationBuilder.CreateIndex(
                name: "IX_Hospitalizacja_ZespolOperacyjnyId",
                table: "Hospitalizacja",
                column: "ZespolOperacyjnyId");

            migrationBuilder.CreateIndex(
                name: "IX_HospitalizacjaProcedura_HospitalizacjaId",
                table: "HospitalizacjaProcedura",
                column: "HospitalizacjaId");

            migrationBuilder.CreateIndex(
                name: "IX_Pacjent_OsobaId",
                table: "Pacjent",
                column: "OsobaId");

            migrationBuilder.CreateIndex(
                name: "IX_Pacjent_PakietMedycznyId",
                table: "Pacjent",
                column: "PakietMedycznyId");

            migrationBuilder.CreateIndex(
                name: "IX_PakietMedycznyProcedura_ProceduraId",
                table: "PakietMedycznyProcedura",
                column: "ProceduraId");

            migrationBuilder.CreateIndex(
                name: "IX_Pracownik_Doktor_ZespolOperacyjnyId",
                table: "Pracownik",
                column: "Doktor_ZespolOperacyjnyId");

            migrationBuilder.CreateIndex(
                name: "IX_Pracownik_OsobaId",
                table: "Pracownik",
                column: "OsobaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pracownik_Salowy_ZespolOperacyjnyId",
                table: "Pracownik",
                column: "Salowy_ZespolOperacyjnyId");

            migrationBuilder.CreateIndex(
                name: "IX_Pracownik_ZespolOperacyjnyId",
                table: "Pracownik",
                column: "ZespolOperacyjnyId");

            migrationBuilder.CreateIndex(
                name: "IX_Wizyta_DoktorId",
                table: "Wizyta",
                column: "DoktorId");

            migrationBuilder.CreateIndex(
                name: "IX_Wizyta_ProceduraId",
                table: "Wizyta",
                column: "ProceduraId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HospitalizacjaProcedura");

            migrationBuilder.DropTable(
                name: "PakietMedycznyProcedura");

            migrationBuilder.DropTable(
                name: "Wizyta");

            migrationBuilder.DropTable(
                name: "Hospitalizacja");

            migrationBuilder.DropTable(
                name: "Pracownik");

            migrationBuilder.DropTable(
                name: "Procedura");

            migrationBuilder.DropTable(
                name: "Pacjent");

            migrationBuilder.DropTable(
                name: "ZespolOperacyjny");

            migrationBuilder.DropTable(
                name: "Osoba");

            migrationBuilder.DropTable(
                name: "PakietMedyczny");
        }
    }
}
