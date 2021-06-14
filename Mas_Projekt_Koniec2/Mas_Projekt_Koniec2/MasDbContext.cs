using Mas_Projekt_Koniec2.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mas_Projekt_Koniec2
{
    class MasDBContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=db-mssql;Initial Catalog=s16693;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PakietMedycznyProcedura>(entity =>
            {
                entity.HasKey(e => new { e.PakietMedycznyId, e.ProceduraId })
                .HasName("PakietMedycznyProcedura_pk");
            });
            modelBuilder.Entity<HospitalizacjaProcedura>(entity =>
            {
                entity.HasKey(e => new { e.ProceduraId, e.HospitalizacjaId, e.DataWykonania })
                .HasName("HospitalizacjaProcedura_pk");
            });
            /*modelBuilder.Entity<Wizyta>(entity =>
            {
                entity.HasKey(e => new { e.PacjentId, e.DoktorId, e.PoczatekWizyty })
                .HasName("Wizyta_pk");
            });*/

            var osoba1 = new Osoba
            {
                Id = 1L,
                Imie = "Adam",
                Nazwisko = "Podlaski",
                DataUrodzenia = new DateTime(1997, 08, 08, 20, 20, 20),
                NumerPesel = "97080812345",
                NumerTelefonu = "123456789",
                AdresEmail = "aPodlaski@gmail.com",
                AdresZamieszkania = "Warszawa"
            };
            var osoba2 = new Osoba
            {
                Id = 2L,
                Imie = "Mateusz",
                Nazwisko = "Pietras",
                DataUrodzenia = new DateTime(1997, 05, 18, 12, 20, 30),
                NumerPesel = "97051812345",
                NumerTelefonu = "113456789",
                AdresEmail = "mPietras@gmail.com",
                AdresZamieszkania = "Kaski"
            };
            var osoba3 = new Osoba
            {
                Id = 3L,
                Imie = "Jan",
                Nazwisko = "Kostera",
                DataUrodzenia = new DateTime(1997, 08, 05, 10, 10, 10),
                NumerPesel = "97080512345",
                NumerTelefonu = "123156789",
                AdresEmail = "jachoStera@gmail.com",
                AdresZamieszkania = "Piastów"
            };
            var osoba4 = new Osoba
            {
                Id = 4L,
                Imie = "Karol",
                Nazwisko = "Plac",
                DataUrodzenia = new DateTime(1997, 08, 08, 02, 02, 02),
                NumerPesel = "97080814345",
                NumerTelefonu = "123454789",
                AdresEmail = "kPlac@gmail.com",
                AdresZamieszkania = "Warszawa"
            };
            var osoba5 = new Osoba
            {
                Id = 5L,
                Imie = "Waldemar",
                Nazwisko = "Waldzki",
                DataUrodzenia = new DateTime(1997, 08, 08, 03, 03, 03),
                NumerPesel = "97080818345",
                NumerTelefonu = "123458789",
                AdresEmail = "wWaldzki@gmail.com",
                AdresZamieszkania = "Warszawa"
            };
            var osoba6 = new Osoba
            {
                Id = 6L,
                Imie = "Maciej",
                Nazwisko = "Bedi",
                DataUrodzenia = new DateTime(1997, 08, 08, 02, 03, 03),
                NumerPesel = "97080818645",
                NumerTelefonu = "123458769",
                AdresEmail = "BediMaciej@gmail.com",
                AdresZamieszkania = "Warszawa"
            };
            var osoba7 = new Osoba
            {
                Id = 7L,
                Imie = "Roman",
                Nazwisko = "Koczan",
                DataUrodzenia = new DateTime(1997, 08, 09, 03, 03, 03),
                NumerPesel = "97080919345",
                NumerTelefonu = "123458999",
                AdresEmail = "RomaNKocz@gmail.com",
                AdresZamieszkania = "Grodzisk Mazowiecki"
            };
            var osoba8 = new Osoba
            {
                Id = 8L,
                Imie = "Tymon",
                Nazwisko = "Gołda",
                DataUrodzenia = new DateTime(1990, 08, 08, 03, 03, 03),
                NumerPesel = "90080818345",
                NumerTelefonu = "120058789",
                AdresEmail = "TymnoGold@gmail.com",
                AdresZamieszkania = "Piastów"
            };

            modelBuilder.Entity<Osoba>().HasData(osoba1, osoba2, osoba3, osoba4, osoba5, osoba6, osoba7, osoba8);

            var procedura1 = new Procedura()
            {
                Id = 1L,
                NazwaProcedura = "Badanie kontrolne",
                KosztProcedura = 20,
                WymaganaSpecjalizacja = "Dowolna",
                CzyPotrzebnyZespolOperacyjny = false,
                CzyProceduraInwazyjna = false
            };
            var procedura2 = new Procedura()
            {
                Id = 2L,
                NazwaProcedura = "Operacja serca",
                KosztProcedura = 10000,
                WymaganaSpecjalizacja = "Kardiolog",
                CzyPotrzebnyZespolOperacyjny = true,
                CzyProceduraInwazyjna = true,
            };
            var procedura3 = new Procedura()
            {
                Id = 3L,
                NazwaProcedura = "Badanie krwi",
                KosztProcedura = 50,
                WymaganaSpecjalizacja = "Diagnosta",
                CzyPotrzebnyZespolOperacyjny = false,
                CzyProceduraInwazyjna = true,
            };

            modelBuilder.Entity<Procedura>().HasData(procedura1, procedura2, procedura3);

            var pakietMedyczny1 = new PakietMedyczny()
            {
                Id = 1L,
                NazwaPakiet = "MedPack"
            };

            modelBuilder.Entity<PakietMedyczny>().HasData(pakietMedyczny1);

            var pakietProcedura1 = new PakietMedycznyProcedura()
            {
                PakietMedycznyId = pakietMedyczny1.Id,
                ProceduraId = procedura1.Id,
                DataPrzypisania = new DateTime(2020, 08, 08, 03, 03, 03)
            };
            var pakietProcedura2 = new PakietMedycznyProcedura()
            {
                PakietMedycznyId = pakietMedyczny1.Id,
                ProceduraId = procedura2.Id,
                DataPrzypisania = new DateTime(2019, 08, 08, 03, 03, 03)
            };

            modelBuilder.Entity<PakietMedycznyProcedura>().HasData(pakietProcedura1, pakietProcedura2);

            var pacjent1 = new Pacjent()
            {
                Id = 1L,
                OsobaId = 1L,
                UbezpiecznieZdrowotne = false,
                PakietMedycznyId = 1L
            };
            var pacjent2 = new Pacjent()
            {
                Id = 2L,
                OsobaId = 2L,
                UbezpiecznieZdrowotne = true,
                PakietMedycznyId = 1L
            };
            var pacjent3 = new Pacjent()
            {
                Id = 3L,
                OsobaId = 3L,
                UbezpiecznieZdrowotne = false,
            };
            var pacjent4 = new Pacjent()
            {
                Id = 4L,
                OsobaId = 6L,
                UbezpiecznieZdrowotne = true,
            };
            var pacjent5 = new Pacjent()
            {
                Id = 5L,
                OsobaId = 7L,
                UbezpiecznieZdrowotne = false,
                PakietMedycznyId = 1L
            };
            var pacjent6 = new Pacjent()
            {
                Id = 6L,
                OsobaId = 8L,
                UbezpiecznieZdrowotne = true,
                PakietMedycznyId = 1L
            };

            modelBuilder.Entity<Pacjent>().HasData(pacjent1, pacjent2, pacjent3, pacjent4, pacjent5, pacjent6);

            var pracownik1 = new Doktor()
            {
                Id = 1L,
                OsobaId = 4L,
                Pensja = 3400,
                SpecjalizacjaDoktor = "Kardiolog",
            };

            var pracownik2 = new Doktor()
            {
                Id = 2L,
                OsobaId = 5L,
                Pensja = 3400,
                SpecjalizacjaDoktor = "Kardiolog",
            };

            modelBuilder.Entity<Doktor>().HasData(pracownik1, pracownik2);

        }

        public virtual DbSet<Osoba> Osoba { get; set; }
        public virtual DbSet<Pracownik> Pracownik { get; set; }
        public virtual DbSet<Doktor> Doktor { get; set; }
        public virtual DbSet<Pielegniarz> Pielegniarz { get; set; }
        public virtual DbSet<Salowy> Salowy { get; set; }
        public virtual DbSet<Recepcjonista> Recepcjonista { get; set; }
        public virtual DbSet<Pacjent> Pacjent { get; set; }
        public virtual DbSet<PakietMedyczny> PakietMedyczny { get; set; }
        public virtual DbSet<Procedura> Procedura { get; set; }
        public virtual DbSet<PakietMedycznyProcedura> PakietMedycznyProcedura { get; set; }
        public virtual DbSet<ZespolOperacyjny> ZespolOperacyjny { get; set; }
        public virtual DbSet<Wizyta> Wizyta { get; set; }
        public virtual DbSet<Hospitalizacja> Hospitalizacja { get; set; }
        public virtual DbSet<HospitalizacjaProcedura> HospitalizacjaProcedura { get; set; }
    }
}
