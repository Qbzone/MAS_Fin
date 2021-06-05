using Mas_Projekt_Koniec.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.OData.Edm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mas_Projekt_Koniec
{
    class MasDBContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=db-mssql;Initial Catalog=s16693;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var osoba1 = new Osoba
            {
                Id = 1L,
                Imie = "Adam",
                Nazwisko = "Podlaski",
                DataUrodzenia = new Date(1997, 08, 08),
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
                DataUrodzenia = new Date(1997, 05, 18),
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
                DataUrodzenia = new Date(1997, 08, 05),
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
                DataUrodzenia = new Date(1997, 08, 08),
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
                DataUrodzenia = new Date(1997, 08, 08),
                NumerPesel = "97080818345",
                NumerTelefonu = "123458789",
                AdresEmail = "wWaldzki@gmail.com",
                AdresZamieszkania = "Warszawa"
            };

            modelBuilder.Entity<Osoba>().HasData(osoba1, osoba2, osoba3, osoba4, osoba5);

            var procedura1 = new Procedura()
            {
                Id = 1L,
                NazwaProcedury = "Badanie kontrolne",
                KosztWykonania = 20,
                CzyPotrzebnyZespolOperacyjny = false,
                CzyProceduraInwazyjna = false
            };
            var procedura2 = new Procedura()
            {
                Id = 2L,
                NazwaProcedury = "Operacja serca",
                KosztWykonania = 10000,
                CzyPotrzebnyZespolOperacyjny = true,
                CzyProceduraInwazyjna = true,
            };

            modelBuilder.Entity<Procedura>().HasData(procedura1, procedura2);

            var pakietMedyczny1 = new PakietMedyczny()
            {
                Id = 1L,
                NazwaPakietu = "MediGel",
                Procedury = { procedura1, procedura2 }
            };

            modelBuilder.Entity<PakietMedyczny>().HasData(pakietMedyczny1);

            var pacjent1 = new Pacjent()
            {
                Id = osoba1.Id,
                UbezpiecznieZdrowotne = false,
                PakietMedyczny = pakietMedyczny1
            };

            modelBuilder.Entity<Pacjent>().HasData(pacjent1);

            var pracownik1 = new Doktor()
            {
                Id = osoba2.Id,
                Pensja = 3400,
                Specjalizacja = "Kardiolog",
            };
            var pracownik2 = new Pielegniarz()
            {
                Id = osoba2.Id,
                Pensja = 2900,
                Specjalizacja = "Odziałowy",
            };
            var pracownik3 = new Salowy()
            {
                Id = osoba2.Id,
                Pensja = 2400,
            };
            var pracownik4 = new Recepcjonista()
            {
                Id = osoba2.Id,
                Pensja = 2500,

            };

            modelBuilder.Entity<Pracownik>().HasData(pracownik1, pracownik2, pracownik3, pracownik4);

            var zespolOperacyjny = new ZespolOperacyjny()
            {
                Id = 1L,
                Doktorzy = { pracownik1 },
                Lider = pracownik1,
                Pielegniarze = { pracownik2 },
                Salowi = { pracownik3 }
            };
        }

        public virtual DbSet<Osoba> Osobas { get; set; }
        public virtual DbSet<Pacjent> Pacjents { get; set; }
        public virtual DbSet<Pracownik> Pracowniks { get; set; }
        public virtual DbSet<Doktor> Doktors { get; set; }
        public virtual DbSet<Pielegniarz> Pielegniarzs { get; set; }
        public virtual DbSet<Salowy> Salowies { get; set; }
        public virtual DbSet<Recepcjonista> Recepcjonistas { get; set; }
        public virtual DbSet<Procedura> Proceduras { get; set; }
        public virtual DbSet<PakietMedyczny> PakietMedycznies { get; set; }
        public virtual DbSet<Wizyta> Wizytas { get; set; }
        public virtual DbSet<Hospitalizacja> Hospitalizacjas { get; set; }
        public virtual DbSet<ZespolOperacyjny> ZespolOperacyjnies { get; set; }
    }
}
