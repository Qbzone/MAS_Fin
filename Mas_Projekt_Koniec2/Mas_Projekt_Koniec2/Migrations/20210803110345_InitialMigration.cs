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
                    NumerPesel = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
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
                    NazwaPakiet = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false)
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
                    NazwaProcedura = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    KosztProcedura = table.Column<int>(type: "int", nullable: false),
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
                    PakietMedycznyId = table.Column<long>(type: "bigint", nullable: true)
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
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PakietMedycznyProcedura",
                columns: table => new
                {
                    PakietMedycznyId = table.Column<long>(type: "bigint", nullable: false),
                    ProceduraId = table.Column<long>(type: "bigint", nullable: false),
                    DataPrzypisania = table.Column<DateTime>(type: "datetime2", nullable: false)
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
                    ZespolOperacyjnyId = table.Column<long>(type: "bigint", nullable: true),
                    SpecjalizacjaDoktor = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    SpecjalizacjaPielegniarz = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    JezykDodatkowy = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    CzyPelniFunkcjePomocnicza = table.Column<bool>(type: "bit", nullable: true)
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
                        name: "FK_Pracownik_ZespolOperacyjny_ZespolOperacyjnyId",
                        column: x => x.ZespolOperacyjnyId,
                        principalTable: "ZespolOperacyjny",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Hospitalizacja",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PoczatekHospitalizacji = table.Column<DateTime>(type: "datetime2", nullable: false),
                    KoniecHospitalizacji = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StatusHospitalizacja = table.Column<int>(type: "int", nullable: false),
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
                name: "DoktorProcedura",
                columns: table => new
                {
                    DoktorzyId = table.Column<long>(type: "bigint", nullable: false),
                    UprawnieniaId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoktorProcedura", x => new { x.DoktorzyId, x.UprawnieniaId });
                    table.ForeignKey(
                        name: "FK_DoktorProcedura_Pracownik_DoktorzyId",
                        column: x => x.DoktorzyId,
                        principalTable: "Pracownik",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DoktorProcedura_Procedura_UprawnieniaId",
                        column: x => x.UprawnieniaId,
                        principalTable: "Procedura",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Wizyta",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PoczatekWizyty = table.Column<DateTime>(type: "datetime2", nullable: false),
                    KoniecWizyty = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StatusWizyta = table.Column<int>(type: "int", nullable: false),
                    PacjentId = table.Column<long>(type: "bigint", nullable: false),
                    DoktorId = table.Column<long>(type: "bigint", nullable: true),
                    ProceduraId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wizyta", x => x.Id);
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
                        onDelete: ReferentialAction.Restrict);
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
                    DataWykonania = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("HospitalizacjaProcedura_pk", x => new { x.ProceduraId, x.HospitalizacjaId, x.DataWykonania });
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

            migrationBuilder.InsertData(
                table: "Osoba",
                columns: new[] { "Id", "AdresEmail", "AdresZamieszkania", "DataUrodzenia", "Imie", "Nazwisko", "NumerPesel", "NumerTelefonu" },
                values: new object[,]
                {
                    { 1L, "aPodlaski@gmail.com", "Warszawa", new DateTime(1997, 8, 8, 20, 20, 20, 0, DateTimeKind.Unspecified), "Adam", "Podlaski", "97080812345", "123456789" },
                    { 2L, "mPietras@gmail.com", "Kaski", new DateTime(1997, 5, 18, 12, 20, 30, 0, DateTimeKind.Unspecified), "Mateusz", "Pietras", "97051812345", "113456789" },
                    { 3L, "jachoStera@gmail.com", "Piastów", new DateTime(1997, 8, 5, 10, 10, 10, 0, DateTimeKind.Unspecified), "Jan", "Kostera", "97080512345", "123156789" },
                    { 4L, "kPlac@gmail.com", "Warszawa", new DateTime(1997, 8, 8, 2, 2, 2, 0, DateTimeKind.Unspecified), "Karol", "Plac", "97080814345", "123454789" },
                    { 5L, "wWaldzki@gmail.com", "Warszawa", new DateTime(1997, 8, 8, 3, 3, 3, 0, DateTimeKind.Unspecified), "Waldemar", "Waldzki", "97080818345", "123458789" },
                    { 6L, "BediMaciej@gmail.com", "Warszawa", new DateTime(1997, 8, 8, 2, 3, 3, 0, DateTimeKind.Unspecified), "Maciej", "Bedi", "97080818645", "123458769" },
                    { 7L, "RomaNKocz@gmail.com", "Grodzisk Mazowiecki", new DateTime(1997, 8, 9, 3, 3, 3, 0, DateTimeKind.Unspecified), "Roman", "Koczan", "97080919345", "123458999" },
                    { 8L, "TymnoGold@gmail.com", "Piastów", new DateTime(1990, 8, 8, 3, 3, 3, 0, DateTimeKind.Unspecified), "Tymon", "Gołda", "90080818345", "120058789" }
                });

            migrationBuilder.InsertData(
                table: "PakietMedyczny",
                columns: new[] { "Id", "NazwaPakiet" },
                values: new object[] { 1L, "MedPack" });

            migrationBuilder.InsertData(
                table: "Procedura",
                columns: new[] { "Id", "CzyPotrzebnyZespolOperacyjny", "CzyProceduraInwazyjna", "KosztProcedura", "NazwaProcedura" },
                values: new object[,]
                {
                    { 1L, false, false, 20, "Badanie kontrolne" },
                    { 2L, true, true, 10000, "Operacja serca" },
                    { 3L, false, true, 50, "Badanie krwi" },
                    { 4L, false, false, 140, "Usg Serca" }
                });

            migrationBuilder.InsertData(
                table: "Pacjent",
                columns: new[] { "Id", "OsobaId", "PakietMedycznyId", "UbezpiecznieZdrowotne" },
                values: new object[,]
                {
                    { 3L, 3L, null, false },
                    { 4L, 6L, null, true },
                    { 1L, 1L, 1L, false },
                    { 2L, 2L, 1L, true },
                    { 5L, 7L, 1L, false },
                    { 6L, 8L, 1L, true }
                });

            migrationBuilder.InsertData(
                table: "PakietMedycznyProcedura",
                columns: new[] { "PakietMedycznyId", "ProceduraId", "DataPrzypisania" },
                values: new object[,]
                {
                    { 1L, 1L, new DateTime(2020, 8, 8, 3, 3, 3, 0, DateTimeKind.Unspecified) },
                    { 1L, 2L, new DateTime(2019, 8, 8, 3, 3, 3, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Pracownik",
                columns: new[] { "Id", "Discriminator", "OsobaId", "Pensja", "SpecjalizacjaDoktor", "ZespolOperacyjnyId" },
                values: new object[,]
                {
                    { 3L, "Doktor", 2L, 3300, "Laryngolog", null },
                    { 1L, "Doktor", 4L, 3400, "Kardiolog", null },
                    { 2L, "Doktor", 5L, 3400, "Kardiolog", null }
                });

            migrationBuilder.InsertData(
                table: "DoktorProcedura",
                columns: new[] { "DoktorzyId", "UprawnieniaId" },
                values: new object[,]
                {
                    { 3L, 1L },
                    { 1L, 1L },
                    { 1L, 2L },
                    { 1L, 4L },
                    { 2L, 1L },
                    { 2L, 2L },
                    { 2L, 4L }
                });

            migrationBuilder.CreateIndex(
                name: "IX_DoktorProcedura_UprawnieniaId",
                table: "DoktorProcedura",
                column: "UprawnieniaId");

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
                column: "OsobaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pacjent_PakietMedycznyId",
                table: "Pacjent",
                column: "PakietMedycznyId");

            migrationBuilder.CreateIndex(
                name: "IX_PakietMedycznyProcedura_ProceduraId",
                table: "PakietMedycznyProcedura",
                column: "ProceduraId");

            migrationBuilder.CreateIndex(
                name: "IX_Pracownik_OsobaId",
                table: "Pracownik",
                column: "OsobaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pracownik_ZespolOperacyjnyId",
                table: "Pracownik",
                column: "ZespolOperacyjnyId");

            migrationBuilder.CreateIndex(
                name: "IX_Wizyta_DoktorId",
                table: "Wizyta",
                column: "DoktorId");

            migrationBuilder.CreateIndex(
                name: "IX_Wizyta_PacjentId",
                table: "Wizyta",
                column: "PacjentId");

            migrationBuilder.CreateIndex(
                name: "IX_Wizyta_ProceduraId",
                table: "Wizyta",
                column: "ProceduraId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DoktorProcedura");

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
