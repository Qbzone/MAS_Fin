﻿// <auto-generated />
using System;
using Mas_Projekt_Koniec2;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Mas_Projekt_Koniec2.Migrations
{
    [DbContext(typeof(MasDBContext))]
    [Migration("20210614103327_test2")]
    partial class test2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Mas_Projekt_Koniec2.Models.Hospitalizacja", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("KoniecHospitalizacji")
                        .HasColumnType("datetime2");

                    b.Property<long>("PacjentId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("PoczatekHospitalizacji")
                        .HasColumnType("datetime2");

                    b.Property<int>("StatusHospitalizacja")
                        .HasColumnType("int");

                    b.Property<long>("ZespolOperacyjnyId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("PacjentId");

                    b.HasIndex("ZespolOperacyjnyId");

                    b.ToTable("Hospitalizacja");
                });

            modelBuilder.Entity("Mas_Projekt_Koniec2.Models.HospitalizacjaProcedura", b =>
                {
                    b.Property<long>("ProceduraId")
                        .HasColumnType("bigint");

                    b.Property<long>("HospitalizacjaId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("DataWykonania")
                        .HasColumnType("datetime2");

                    b.Property<long>("Id")
                        .HasColumnType("bigint");

                    b.HasKey("ProceduraId", "HospitalizacjaId", "DataWykonania")
                        .HasName("HospitalizacjaProcedura_pk");

                    b.HasIndex("HospitalizacjaId");

                    b.ToTable("HospitalizacjaProcedura");
                });

            modelBuilder.Entity("Mas_Projekt_Koniec2.Models.Osoba", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AdresEmail")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("AdresZamieszkania")
                        .IsRequired()
                        .HasMaxLength(75)
                        .HasColumnType("nvarchar(75)");

                    b.Property<DateTime>("DataUrodzenia")
                        .HasColumnType("datetime2");

                    b.Property<string>("Imie")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("Nazwisko")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("NumerPesel")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<string>("NumerTelefonu")
                        .IsRequired()
                        .HasMaxLength(9)
                        .HasColumnType("nvarchar(9)");

                    b.HasKey("Id");

                    b.ToTable("Osoba");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            AdresEmail = "aPodlaski@gmail.com",
                            AdresZamieszkania = "Warszawa",
                            DataUrodzenia = new DateTime(1997, 8, 8, 20, 20, 20, 0, DateTimeKind.Unspecified),
                            Imie = "Adam",
                            Nazwisko = "Podlaski",
                            NumerPesel = "97080812345",
                            NumerTelefonu = "123456789"
                        },
                        new
                        {
                            Id = 2L,
                            AdresEmail = "mPietras@gmail.com",
                            AdresZamieszkania = "Kaski",
                            DataUrodzenia = new DateTime(1997, 5, 18, 12, 20, 30, 0, DateTimeKind.Unspecified),
                            Imie = "Mateusz",
                            Nazwisko = "Pietras",
                            NumerPesel = "97051812345",
                            NumerTelefonu = "113456789"
                        },
                        new
                        {
                            Id = 3L,
                            AdresEmail = "jachoStera@gmail.com",
                            AdresZamieszkania = "Piastów",
                            DataUrodzenia = new DateTime(1997, 8, 5, 10, 10, 10, 0, DateTimeKind.Unspecified),
                            Imie = "Jan",
                            Nazwisko = "Kostera",
                            NumerPesel = "97080512345",
                            NumerTelefonu = "123156789"
                        },
                        new
                        {
                            Id = 4L,
                            AdresEmail = "kPlac@gmail.com",
                            AdresZamieszkania = "Warszawa",
                            DataUrodzenia = new DateTime(1997, 8, 8, 2, 2, 2, 0, DateTimeKind.Unspecified),
                            Imie = "Karol",
                            Nazwisko = "Plac",
                            NumerPesel = "97080814345",
                            NumerTelefonu = "123454789"
                        },
                        new
                        {
                            Id = 5L,
                            AdresEmail = "wWaldzki@gmail.com",
                            AdresZamieszkania = "Warszawa",
                            DataUrodzenia = new DateTime(1997, 8, 8, 3, 3, 3, 0, DateTimeKind.Unspecified),
                            Imie = "Waldemar",
                            Nazwisko = "Waldzki",
                            NumerPesel = "97080818345",
                            NumerTelefonu = "123458789"
                        },
                        new
                        {
                            Id = 6L,
                            AdresEmail = "BediMaciej@gmail.com",
                            AdresZamieszkania = "Warszawa",
                            DataUrodzenia = new DateTime(1997, 8, 8, 2, 3, 3, 0, DateTimeKind.Unspecified),
                            Imie = "Maciej",
                            Nazwisko = "Bedi",
                            NumerPesel = "97080818645",
                            NumerTelefonu = "123458769"
                        },
                        new
                        {
                            Id = 7L,
                            AdresEmail = "RomaNKocz@gmail.com",
                            AdresZamieszkania = "Grodzisk Mazowiecki",
                            DataUrodzenia = new DateTime(1997, 8, 9, 3, 3, 3, 0, DateTimeKind.Unspecified),
                            Imie = "Roman",
                            Nazwisko = "Koczan",
                            NumerPesel = "97080919345",
                            NumerTelefonu = "123458999"
                        },
                        new
                        {
                            Id = 8L,
                            AdresEmail = "TymnoGold@gmail.com",
                            AdresZamieszkania = "Piastów",
                            DataUrodzenia = new DateTime(1990, 8, 8, 3, 3, 3, 0, DateTimeKind.Unspecified),
                            Imie = "Tymon",
                            Nazwisko = "Gołda",
                            NumerPesel = "90080818345",
                            NumerTelefonu = "120058789"
                        });
                });

            modelBuilder.Entity("Mas_Projekt_Koniec2.Models.Pacjent", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("OsobaId")
                        .HasColumnType("bigint");

                    b.Property<long?>("PakietMedycznyId")
                        .HasColumnType("bigint");

                    b.Property<bool>("UbezpiecznieZdrowotne")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("OsobaId")
                        .IsUnique();

                    b.HasIndex("PakietMedycznyId");

                    b.ToTable("Pacjent");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            OsobaId = 1L,
                            PakietMedycznyId = 1L,
                            UbezpiecznieZdrowotne = false
                        },
                        new
                        {
                            Id = 2L,
                            OsobaId = 2L,
                            PakietMedycznyId = 1L,
                            UbezpiecznieZdrowotne = true
                        },
                        new
                        {
                            Id = 3L,
                            OsobaId = 3L,
                            UbezpiecznieZdrowotne = true
                        },
                        new
                        {
                            Id = 4L,
                            OsobaId = 6L,
                            UbezpiecznieZdrowotne = true
                        },
                        new
                        {
                            Id = 5L,
                            OsobaId = 7L,
                            PakietMedycznyId = 1L,
                            UbezpiecznieZdrowotne = false
                        },
                        new
                        {
                            Id = 6L,
                            OsobaId = 8L,
                            PakietMedycznyId = 1L,
                            UbezpiecznieZdrowotne = true
                        });
                });

            modelBuilder.Entity("Mas_Projekt_Koniec2.Models.PakietMedyczny", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NazwaPakiet")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.HasKey("Id");

                    b.ToTable("PakietMedyczny");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            NazwaPakiet = "MedPack"
                        });
                });

            modelBuilder.Entity("Mas_Projekt_Koniec2.Models.PakietMedycznyProcedura", b =>
                {
                    b.Property<long>("PakietMedycznyId")
                        .HasColumnType("bigint");

                    b.Property<long>("ProceduraId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("DataPrzypisania")
                        .HasColumnType("datetime2");

                    b.HasKey("PakietMedycznyId", "ProceduraId")
                        .HasName("PakietMedycznyProcedura_pk");

                    b.HasIndex("ProceduraId");

                    b.ToTable("PakietMedycznyProcedura");

                    b.HasData(
                        new
                        {
                            PakietMedycznyId = 1L,
                            ProceduraId = 1L,
                            DataPrzypisania = new DateTime(2020, 8, 8, 3, 3, 3, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            PakietMedycznyId = 1L,
                            ProceduraId = 2L,
                            DataPrzypisania = new DateTime(2019, 8, 8, 3, 3, 3, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("Mas_Projekt_Koniec2.Models.Pracownik", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("OsobaId")
                        .HasColumnType("bigint");

                    b.Property<int>("Pensja")
                        .HasColumnType("int");

                    b.Property<long?>("ZespolOperacyjnyId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("OsobaId")
                        .IsUnique();

                    b.HasIndex("ZespolOperacyjnyId");

                    b.ToTable("Pracownik");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Pracownik");
                });

            modelBuilder.Entity("Mas_Projekt_Koniec2.Models.Procedura", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("CzyPotrzebnyZespolOperacyjny")
                        .HasColumnType("bit");

                    b.Property<bool>("CzyProceduraInwazyjna")
                        .HasColumnType("bit");

                    b.Property<int>("KosztProcedura")
                        .HasColumnType("int");

                    b.Property<string>("NazwaProcedura")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("WymaganaSpecjalizacja")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.ToTable("Procedura");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            CzyPotrzebnyZespolOperacyjny = false,
                            CzyProceduraInwazyjna = false,
                            KosztProcedura = 20,
                            NazwaProcedura = "Badanie kontrolne",
                            WymaganaSpecjalizacja = "Dowolna"
                        },
                        new
                        {
                            Id = 2L,
                            CzyPotrzebnyZespolOperacyjny = true,
                            CzyProceduraInwazyjna = true,
                            KosztProcedura = 10000,
                            NazwaProcedura = "Operacja serca",
                            WymaganaSpecjalizacja = "Kardiolog"
                        },
                        new
                        {
                            Id = 3L,
                            CzyPotrzebnyZespolOperacyjny = false,
                            CzyProceduraInwazyjna = true,
                            KosztProcedura = 50,
                            NazwaProcedura = "Badanie krwi",
                            WymaganaSpecjalizacja = "Dowolna"
                        });
                });

            modelBuilder.Entity("Mas_Projekt_Koniec2.Models.Wizyta", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("DoktorId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("KoniecWizyty")
                        .HasColumnType("datetime2");

                    b.Property<long>("PacjentId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("PoczatekWizyty")
                        .HasColumnType("datetime2");

                    b.Property<long>("ProceduraId")
                        .HasColumnType("bigint");

                    b.Property<int>("StatusWizyta")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DoktorId");

                    b.HasIndex("PacjentId");

                    b.HasIndex("ProceduraId");

                    b.ToTable("Wizyta");
                });

            modelBuilder.Entity("Mas_Projekt_Koniec2.Models.ZespolOperacyjny", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.HasKey("Id");

                    b.ToTable("ZespolOperacyjny");
                });

            modelBuilder.Entity("Mas_Projekt_Koniec2.Models.Doktor", b =>
                {
                    b.HasBaseType("Mas_Projekt_Koniec2.Models.Pracownik");

                    b.Property<string>("SpecjalizacjaDoktor")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.HasDiscriminator().HasValue("Doktor");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            OsobaId = 4L,
                            Pensja = 3400,
                            SpecjalizacjaDoktor = "Kardiolog"
                        },
                        new
                        {
                            Id = 2L,
                            OsobaId = 5L,
                            Pensja = 3400,
                            SpecjalizacjaDoktor = "Kardiolog"
                        });
                });

            modelBuilder.Entity("Mas_Projekt_Koniec2.Models.Pielegniarz", b =>
                {
                    b.HasBaseType("Mas_Projekt_Koniec2.Models.Pracownik");

                    b.Property<string>("SpecjalizacjaPielegniarz")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.HasDiscriminator().HasValue("Pielegniarz");
                });

            modelBuilder.Entity("Mas_Projekt_Koniec2.Models.Recepcjonista", b =>
                {
                    b.HasBaseType("Mas_Projekt_Koniec2.Models.Pracownik");

                    b.HasDiscriminator().HasValue("Recepcjonista");
                });

            modelBuilder.Entity("Mas_Projekt_Koniec2.Models.Salowy", b =>
                {
                    b.HasBaseType("Mas_Projekt_Koniec2.Models.Pracownik");

                    b.HasDiscriminator().HasValue("Salowy");
                });

            modelBuilder.Entity("Mas_Projekt_Koniec2.Models.Hospitalizacja", b =>
                {
                    b.HasOne("Mas_Projekt_Koniec2.Models.Pacjent", "Pacjent")
                        .WithMany("Hospitalizacja")
                        .HasForeignKey("PacjentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Mas_Projekt_Koniec2.Models.ZespolOperacyjny", "ZespolOperacyjny")
                        .WithMany("Hospitalizacje")
                        .HasForeignKey("ZespolOperacyjnyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pacjent");

                    b.Navigation("ZespolOperacyjny");
                });

            modelBuilder.Entity("Mas_Projekt_Koniec2.Models.HospitalizacjaProcedura", b =>
                {
                    b.HasOne("Mas_Projekt_Koniec2.Models.Hospitalizacja", "Hospitalizacja")
                        .WithMany("Procedury")
                        .HasForeignKey("HospitalizacjaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Mas_Projekt_Koniec2.Models.Procedura", "Procedura")
                        .WithMany("Hospitalizacje")
                        .HasForeignKey("ProceduraId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hospitalizacja");

                    b.Navigation("Procedura");
                });

            modelBuilder.Entity("Mas_Projekt_Koniec2.Models.Pacjent", b =>
                {
                    b.HasOne("Mas_Projekt_Koniec2.Models.Osoba", "Osoba")
                        .WithOne("Pacjent")
                        .HasForeignKey("Mas_Projekt_Koniec2.Models.Pacjent", "OsobaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Mas_Projekt_Koniec2.Models.PakietMedyczny", "PakietMedyczny")
                        .WithMany("Pacjenci")
                        .HasForeignKey("PakietMedycznyId");

                    b.Navigation("Osoba");

                    b.Navigation("PakietMedyczny");
                });

            modelBuilder.Entity("Mas_Projekt_Koniec2.Models.PakietMedycznyProcedura", b =>
                {
                    b.HasOne("Mas_Projekt_Koniec2.Models.PakietMedyczny", "PakietMedyczny")
                        .WithMany("Procedury")
                        .HasForeignKey("PakietMedycznyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Mas_Projekt_Koniec2.Models.Procedura", "Procedura")
                        .WithMany("PakietyMedyczne")
                        .HasForeignKey("ProceduraId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PakietMedyczny");

                    b.Navigation("Procedura");
                });

            modelBuilder.Entity("Mas_Projekt_Koniec2.Models.Pracownik", b =>
                {
                    b.HasOne("Mas_Projekt_Koniec2.Models.Osoba", "Osoba")
                        .WithOne("Pracownik")
                        .HasForeignKey("Mas_Projekt_Koniec2.Models.Pracownik", "OsobaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Mas_Projekt_Koniec2.Models.ZespolOperacyjny", null)
                        .WithMany("Pracownicy")
                        .HasForeignKey("ZespolOperacyjnyId");

                    b.Navigation("Osoba");
                });

            modelBuilder.Entity("Mas_Projekt_Koniec2.Models.Wizyta", b =>
                {
                    b.HasOne("Mas_Projekt_Koniec2.Models.Doktor", "Doktor")
                        .WithMany("Wizyty")
                        .HasForeignKey("DoktorId");

                    b.HasOne("Mas_Projekt_Koniec2.Models.Pacjent", "Pacjent")
                        .WithMany("Wizyty")
                        .HasForeignKey("PacjentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Mas_Projekt_Koniec2.Models.Procedura", "Procedura")
                        .WithMany("Wizyty")
                        .HasForeignKey("ProceduraId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Doktor");

                    b.Navigation("Pacjent");

                    b.Navigation("Procedura");
                });

            modelBuilder.Entity("Mas_Projekt_Koniec2.Models.Hospitalizacja", b =>
                {
                    b.Navigation("Procedury");
                });

            modelBuilder.Entity("Mas_Projekt_Koniec2.Models.Osoba", b =>
                {
                    b.Navigation("Pacjent");

                    b.Navigation("Pracownik");
                });

            modelBuilder.Entity("Mas_Projekt_Koniec2.Models.Pacjent", b =>
                {
                    b.Navigation("Hospitalizacja");

                    b.Navigation("Wizyty");
                });

            modelBuilder.Entity("Mas_Projekt_Koniec2.Models.PakietMedyczny", b =>
                {
                    b.Navigation("Pacjenci");

                    b.Navigation("Procedury");
                });

            modelBuilder.Entity("Mas_Projekt_Koniec2.Models.Procedura", b =>
                {
                    b.Navigation("Hospitalizacje");

                    b.Navigation("PakietyMedyczne");

                    b.Navigation("Wizyty");
                });

            modelBuilder.Entity("Mas_Projekt_Koniec2.Models.ZespolOperacyjny", b =>
                {
                    b.Navigation("Hospitalizacje");

                    b.Navigation("Pracownicy");
                });

            modelBuilder.Entity("Mas_Projekt_Koniec2.Models.Doktor", b =>
                {
                    b.Navigation("Wizyty");
                });
#pragma warning restore 612, 618
        }
    }
}
