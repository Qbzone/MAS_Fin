using Mas_Final_Project.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace Mas_Final_Project
{
    internal class MasDBContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Properties.Settings.Default.connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<MedicalPackageProcedure>(entity =>
                {
                    entity
                        .HasKey(e => new { e.MedicalPackageId, e.ProcedureId })
                        .HasName("MedicalPackageProcedure_pk");
                });

            modelBuilder
                .Entity<HospitalizationProcedure>(entity =>
                {
                    entity
                        .HasKey(e => new { e.ProcedureId, e.HospitalizationId, e.ExecutionDate })
                        .HasName("HospitalizationProcedure_pk");
                });

            modelBuilder
                .Entity<Person>(o =>
                {
                    o.HasData(new
                    {
                        Id = 1L,
                        FirstName = "Adam",
                        LastName = "Podlaski",
                        BirthDate = new DateTime(1997, 08, 08, 20, 20, 20),
                        PeselNumber = "97080812345",
                        PhoneNumber = "123456789",
                        EmailAddress = "aPodlaski@gmail.com",
                        HomeAddress = "Warszawa"
                    });
                    o.HasData(new
                    {
                        Id = 2L,
                        FirstName = "Mateusz",
                        LastName = "Pietras",
                        BirthDate = new DateTime(1997, 05, 18, 12, 20, 30),
                        PeselNumber = "97051812345",
                        PhoneNumber = "113456789",
                        EmailAddress = "mPietras@gmail.com",
                        HomeAddress = "Kaski"
                    });
                    o.HasData(new
                    {
                        Id = 3L,
                        FirstName = "Jan",
                        LastName = "Kostera",
                        BirthDate = new DateTime(1997, 08, 05, 10, 10, 10),
                        PeselNumber = "97080512345",
                        PhoneNumber = "123156789",
                        EmailAddress = "jachoStera@gmail.com",
                        HomeAddress = "Piastów"
                    });
                    o.HasData(new
                    {
                        Id = 4L,
                        FirstName = "Karol",
                        LastName = "Plac",
                        BirthDate = new DateTime(1997, 08, 08, 02, 02, 02),
                        PeselNumber = "97080814345",
                        PhoneNumber = "123454789",
                        EmailAddress = "kPlac@gmail.com",
                        HomeAddress = "Warszawa"
                    });
                    o.HasData(new
                    {
                        Id = 5L,
                        FirstName = "Waldemar",
                        LastName = "Waldzki",
                        BirthDate = new DateTime(1997, 08, 08, 03, 03, 03),
                        PeselNumber = "97080818345",
                        PhoneNumber = "123458789",
                        EmailAddress = "wWaldzki@gmail.com",
                        HomeAddress = "Warszawa"
                    });
                    o.HasData(new
                    {
                        Id = 6L,
                        FirstName = "Maciej",
                        LastName = "Bedi",
                        BirthDate = new DateTime(1997, 08, 08, 02, 03, 03),
                        PeselNumber = "97080818645",
                        PhoneNumber = "123458769",
                        EmailAddress = "BediMaciej@gmail.com",
                        HomeAddress = "Warszawa"
                    });
                    o.HasData(new
                    {
                        Id = 7L,
                        FirstName = "Roman",
                        LastName = "Koczan",
                        BirthDate = new DateTime(1997, 08, 09, 03, 03, 03),
                        PeselNumber = "97080919345",
                        PhoneNumber = "123458999",
                        EmailAddress = "RomaNKocz@gmail.com",
                        HomeAddress = "Grodzisk Mazowiecki"
                    });
                    o.HasData(new
                    {
                        Id = 8L,
                        FirstName = "Tymon",
                        LastName = "Gołda",
                        BirthDate = new DateTime(1990, 08, 08, 03, 03, 03),
                        PeselNumber = "90080818345",
                        PhoneNumber = "120058789",
                        EmailAddress = "TymnoGold@gmail.com",
                        HomeAddress = "Piastów"
                    });
                });

            modelBuilder
                .Entity<Procedure>(p =>
                {
                    p.HasData(new
                    {
                        Id = 1L,
                        ProcedureName = "Badanie kontrolne",
                        ProcedureCost = 20,
                        IsOperationalTeamNeeded = false,
                        IsProcedureInvasive = false
                    });
                    p.HasData(new
                    {
                        Id = 2L,
                        ProcedureName = "Operacja serca",
                        ProcedureCost = 10000,
                        IsOperationalTeamNeeded = true,
                        IsProcedureInvasive = true
                    });
                    p.HasData(new
                    {
                        Id = 3L,
                        ProcedureName = "Badanie krwi",
                        ProcedureCost = 50,
                        IsOperationalTeamNeeded = false,
                        IsProcedureInvasive = true
                    });
                    p.HasData(new
                    {
                        Id = 4L,
                        ProcedureName = "Usg Serca",
                        ProcedureCost = 140,
                        IsOperationalTeamNeeded = false,
                        IsProcedureInvasive = false
                    });
                });

            modelBuilder
                .Entity<MedicalPackage>(pm =>
                {
                    pm.HasData(new
                    {
                        Id = 1L,
                        PackageName = "MedPack"
                    });
                });

            modelBuilder
                .Entity<MedicalPackageProcedure>(pmp =>
                {
                    pmp.HasData(new
                    {
                        MedicalPackageId = 1L,
                        ProcedureId = 1L,
                        AssignmentDate = new DateTime(2020, 08, 08, 03, 03, 03)
                    });
                    pmp.HasData(new
                    {
                        MedicalPackageId = 1L,
                        ProcedureId = 2L,
                        AssignmentDate = new DateTime(2019, 08, 08, 03, 03, 03)
                    });
                });

            modelBuilder
                .Entity<Patient>(p =>
                {
                    p.HasData(new
                    {
                        Id = 1L,
                        PersonId = 1L,
                        HealthInsurance = false,
                        MedicalPackageId = 1L
                    });
                    p.HasData(new
                    {
                        Id = 2L,
                        PersonId = 2L,
                        HealthInsurance = true,
                        MedicalPackageId = 1L
                    });
                    p.HasData(new
                    {
                        Id = 3L,
                        PersonId = 3L,
                        HealthInsurance = false
                    });
                    p.HasData(new
                    {
                        Id = 4L,
                        PersonId = 6L,
                        HealthInsurance = true
                    });
                    p.HasData(new
                    {
                        Id = 5L,
                        PersonId = 7L,
                        HealthInsurance = false,
                        MedicalPackageId = 1L
                    });
                    p.HasData(new
                    {
                        Id = 6L,
                        PersonId = 8L,
                        HealthInsurance = true,
                        MedicalPackageId = 1L
                    });
                });

            modelBuilder
                .Entity<Doctor>(d =>
                {
                    d.HasData(new
                    {
                        Id = 1L,
                        PersonId = 4L,
                        Salary = 3400,
                        DoctorSpecialization = "Cardiologist"
                    });
                    d.HasData(new
                    {
                        Id = 2L,
                        PersonId = 5L,
                        Salary = 3400,
                        DoctorSpecialization = "Cardiologist"
                    });
                    d.HasData(new
                    {
                        Id = 3L,
                        PersonId = 2L,
                        Salary = 3300,
                        DoctorSpecialization = "Laryngologist"
                    });
                });

            modelBuilder
                .Entity<Doctor>()
                .HasMany(p => p.Entitlements)
                .WithMany(p => p.Doctors)
                .UsingEntity(j =>
                {
                    j.HasData(new
                    {
                        EntitlementsId = 1L,
                        DoctorsId = 1L
                    });
                    j.HasData(new
                    {
                        EntitlementsId = 2L,
                        DoctorsId = 1L
                    });
                    j.HasData(new
                    {
                        EntitlementsId = 4L,
                        DoctorsId = 1L
                    });
                    j.HasData(new
                    {
                        EntitlementsId = 1L,
                        DoctorsId = 2L
                    });
                    j.HasData(new
                    {
                        EntitlementsId = 2L,
                        DoctorsId = 2L
                    });
                    j.HasData(new
                    {
                        EntitlementsId = 4L,
                        DoctorsId = 2L
                    });
                    j.HasData(new
                    {
                        EntitlementsId = 1L,
                        DoctorsId = 3L
                    });
                });
        }

        public virtual DbSet<Person> Person { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Doctor> Doctor { get; set; }
        public virtual DbSet<Nurse> Nurse { get; set; }
        public virtual DbSet<Orderly> Orderly { get; set; }
        public virtual DbSet<Receptionist> Receptionist { get; set; }
        public virtual DbSet<Patient> Patient { get; set; }
        public virtual DbSet<MedicalPackage> MedicalPackage { get; set; }
        public virtual DbSet<Procedure> Procedure { get; set; }
        public virtual DbSet<MedicalPackageProcedure> MedicalPackageProcedure { get; set; }
        public virtual DbSet<OperationalTeam> OperationalTeam { get; set; }
        public virtual DbSet<Visit> Visit { get; set; }
        public virtual DbSet<Hospitalization> Hospitalization { get; set; }
        public virtual DbSet<HospitalizationProcedure> HospitalizationProcedure { get; set; }
    }
}