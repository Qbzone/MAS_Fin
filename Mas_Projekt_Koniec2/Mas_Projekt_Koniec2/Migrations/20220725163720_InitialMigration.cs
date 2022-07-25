using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Mas_Final_Project.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MedicalPackage",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PackageName = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalPackage", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OperationalTeam",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperationalTeam", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PeselNumber = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    HomeAddress = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: false),
                    EmailAddress = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Procedure",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProcedureName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ProcedureCost = table.Column<int>(type: "int", nullable: false),
                    IsOperationalTeamNeeded = table.Column<bool>(type: "bit", nullable: false),
                    IsProcedureInvasive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Procedure", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Salary = table.Column<int>(type: "int", nullable: false),
                    PersonId = table.Column<long>(type: "bigint", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OperationalTeamId = table.Column<long>(type: "bigint", nullable: true),
                    DoctorSpecialization = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    NurseSpacialization = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    DoesSupportFunctions = table.Column<bool>(type: "bit", nullable: true),
                    AdditionalLanguage = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employee_OperationalTeam_OperationalTeamId",
                        column: x => x.OperationalTeamId,
                        principalTable: "OperationalTeam",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Employee_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Patient",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HealthInsurance = table.Column<bool>(type: "bit", nullable: false),
                    PersonId = table.Column<long>(type: "bigint", nullable: false),
                    MedicalPackageId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patient", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Patient_MedicalPackage_MedicalPackageId",
                        column: x => x.MedicalPackageId,
                        principalTable: "MedicalPackage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Patient_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MedicalPackageProcedure",
                columns: table => new
                {
                    MedicalPackageId = table.Column<long>(type: "bigint", nullable: false),
                    ProcedureId = table.Column<long>(type: "bigint", nullable: false),
                    AssignmentDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("MedicalPackageProcedure_pk", x => new { x.MedicalPackageId, x.ProcedureId });
                    table.ForeignKey(
                        name: "FK_MedicalPackageProcedure_MedicalPackage_MedicalPackageId",
                        column: x => x.MedicalPackageId,
                        principalTable: "MedicalPackage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MedicalPackageProcedure_Procedure_ProcedureId",
                        column: x => x.ProcedureId,
                        principalTable: "Procedure",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DoctorProcedure",
                columns: table => new
                {
                    DoctorsId = table.Column<long>(type: "bigint", nullable: false),
                    EntitlementsId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorProcedure", x => new { x.DoctorsId, x.EntitlementsId });
                    table.ForeignKey(
                        name: "FK_DoctorProcedure_Employee_DoctorsId",
                        column: x => x.DoctorsId,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DoctorProcedure_Procedure_EntitlementsId",
                        column: x => x.EntitlementsId,
                        principalTable: "Procedure",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Hospitalization",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HospitalizationStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HospitalizationEnd = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HospitalizationState = table.Column<int>(type: "int", nullable: false),
                    PatientId = table.Column<long>(type: "bigint", nullable: false),
                    OperationalTeamId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hospitalization", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Hospitalization_OperationalTeam_OperationalTeamId",
                        column: x => x.OperationalTeamId,
                        principalTable: "OperationalTeam",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Hospitalization_Patient_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Visit",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VisitStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VisitEnd = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VisitState = table.Column<int>(type: "int", nullable: false),
                    PatientId = table.Column<long>(type: "bigint", nullable: false),
                    DoctorId = table.Column<long>(type: "bigint", nullable: true),
                    ProcedureId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Visit", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Visit_Employee_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Visit_Patient_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Visit_Procedure_ProcedureId",
                        column: x => x.ProcedureId,
                        principalTable: "Procedure",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HospitalizationProcedure",
                columns: table => new
                {
                    ProcedureId = table.Column<long>(type: "bigint", nullable: false),
                    HospitalizationId = table.Column<long>(type: "bigint", nullable: false),
                    ExecutionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("HospitalizationProcedure_pk", x => new { x.ProcedureId, x.HospitalizationId, x.ExecutionDate });
                    table.ForeignKey(
                        name: "FK_HospitalizationProcedure_Hospitalization_HospitalizationId",
                        column: x => x.HospitalizationId,
                        principalTable: "Hospitalization",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HospitalizationProcedure_Procedure_ProcedureId",
                        column: x => x.ProcedureId,
                        principalTable: "Procedure",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "MedicalPackage",
                columns: new[] { "Id", "PackageName" },
                values: new object[] { 1L, "MedPack" });

            migrationBuilder.InsertData(
                table: "Person",
                columns: new[] { "Id", "BirthDate", "EmailAddress", "FirstName", "HomeAddress", "LastName", "PeselNumber", "PhoneNumber" },
                values: new object[,]
                {
                    { 1L, new DateTime(1997, 8, 8, 20, 20, 20, 0, DateTimeKind.Unspecified), "aPodlaski@gmail.com", "Adam", "Warszawa", "Podlaski", "97080812345", "123456789" },
                    { 2L, new DateTime(1997, 5, 18, 12, 20, 30, 0, DateTimeKind.Unspecified), "mPietras@gmail.com", "Mateusz", "Kaski", "Pietras", "97051812345", "113456789" },
                    { 3L, new DateTime(1997, 8, 5, 10, 10, 10, 0, DateTimeKind.Unspecified), "jachoStera@gmail.com", "Jan", "Piastów", "Kostera", "97080512345", "123156789" },
                    { 4L, new DateTime(1997, 8, 8, 2, 2, 2, 0, DateTimeKind.Unspecified), "kPlac@gmail.com", "Karol", "Warszawa", "Plac", "97080814345", "123454789" },
                    { 5L, new DateTime(1997, 8, 8, 3, 3, 3, 0, DateTimeKind.Unspecified), "wWaldzki@gmail.com", "Waldemar", "Warszawa", "Waldzki", "97080818345", "123458789" },
                    { 6L, new DateTime(1997, 8, 8, 2, 3, 3, 0, DateTimeKind.Unspecified), "BediMaciej@gmail.com", "Maciej", "Warszawa", "Bedi", "97080818645", "123458769" },
                    { 7L, new DateTime(1997, 8, 9, 3, 3, 3, 0, DateTimeKind.Unspecified), "RomaNKocz@gmail.com", "Roman", "Grodzisk Mazowiecki", "Koczan", "97080919345", "123458999" },
                    { 8L, new DateTime(1990, 8, 8, 3, 3, 3, 0, DateTimeKind.Unspecified), "TymnoGold@gmail.com", "Tymon", "Piastów", "Gołda", "90080818345", "120058789" }
                });

            migrationBuilder.InsertData(
                table: "Procedure",
                columns: new[] { "Id", "IsOperationalTeamNeeded", "IsProcedureInvasive", "ProcedureCost", "ProcedureName" },
                values: new object[,]
                {
                    { 1L, false, false, 20, "Badanie kontrolne" },
                    { 2L, true, true, 10000, "Operacja serca" },
                    { 3L, false, true, 50, "Badanie krwi" },
                    { 4L, false, false, 140, "Usg Serca" }
                });

            migrationBuilder.InsertData(
                table: "Employee",
                columns: new[] { "Id", "Discriminator", "DoctorSpecialization", "OperationalTeamId", "PersonId", "Salary" },
                values: new object[,]
                {
                    { 3L, "Doctor", "Laryngologist", null, 2L, 3300 },
                    { 1L, "Doctor", "Cardiologist", null, 4L, 3400 },
                    { 2L, "Doctor", "Cardiologist", null, 5L, 3400 }
                });

            migrationBuilder.InsertData(
                table: "MedicalPackageProcedure",
                columns: new[] { "MedicalPackageId", "ProcedureId", "AssignmentDate" },
                values: new object[,]
                {
                    { 1L, 1L, new DateTime(2020, 8, 8, 3, 3, 3, 0, DateTimeKind.Unspecified) },
                    { 1L, 2L, new DateTime(2019, 8, 8, 3, 3, 3, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Patient",
                columns: new[] { "Id", "HealthInsurance", "MedicalPackageId", "PersonId" },
                values: new object[,]
                {
                    { 1L, false, 1L, 1L },
                    { 2L, true, 1L, 2L },
                    { 3L, false, null, 3L },
                    { 4L, true, null, 6L },
                    { 5L, false, 1L, 7L },
                    { 6L, true, 1L, 8L }
                });

            migrationBuilder.InsertData(
                table: "DoctorProcedure",
                columns: new[] { "DoctorsId", "EntitlementsId" },
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
                name: "IX_DoctorProcedure_EntitlementsId",
                table: "DoctorProcedure",
                column: "EntitlementsId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_OperationalTeamId",
                table: "Employee",
                column: "OperationalTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_PersonId",
                table: "Employee",
                column: "PersonId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Hospitalization_OperationalTeamId",
                table: "Hospitalization",
                column: "OperationalTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Hospitalization_PatientId",
                table: "Hospitalization",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_HospitalizationProcedure_HospitalizationId",
                table: "HospitalizationProcedure",
                column: "HospitalizationId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalPackageProcedure_ProcedureId",
                table: "MedicalPackageProcedure",
                column: "ProcedureId");

            migrationBuilder.CreateIndex(
                name: "IX_Patient_MedicalPackageId",
                table: "Patient",
                column: "MedicalPackageId");

            migrationBuilder.CreateIndex(
                name: "IX_Patient_PersonId",
                table: "Patient",
                column: "PersonId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Visit_DoctorId",
                table: "Visit",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Visit_PatientId",
                table: "Visit",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Visit_ProcedureId",
                table: "Visit",
                column: "ProcedureId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DoctorProcedure");

            migrationBuilder.DropTable(
                name: "HospitalizationProcedure");

            migrationBuilder.DropTable(
                name: "MedicalPackageProcedure");

            migrationBuilder.DropTable(
                name: "Visit");

            migrationBuilder.DropTable(
                name: "Hospitalization");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "Procedure");

            migrationBuilder.DropTable(
                name: "Patient");

            migrationBuilder.DropTable(
                name: "OperationalTeam");

            migrationBuilder.DropTable(
                name: "MedicalPackage");

            migrationBuilder.DropTable(
                name: "Person");
        }
    }
}
