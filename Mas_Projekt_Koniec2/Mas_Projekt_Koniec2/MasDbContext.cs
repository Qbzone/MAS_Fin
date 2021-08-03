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
            modelBuilder
                .Entity<PakietMedycznyProcedura>(entity =>
                {
                    entity.HasKey(e => new { e.PakietMedycznyId, e.ProceduraId })
                    .HasName("PakietMedycznyProcedura_pk");
                });

            modelBuilder
                .Entity<HospitalizacjaProcedura>(entity =>
                {
                    entity.HasKey(e => new { e.ProceduraId, e.HospitalizacjaId, e.DataWykonania })
                    .HasName("HospitalizacjaProcedura_pk");
                });

            modelBuilder
                .Entity<Osoba>(o =>
                {
                    o.HasData(new
                    {
                        Id = 1L,
                        Imie = "Adam",
                        Nazwisko = "Podlaski",
                        DataUrodzenia = new DateTime(1997, 08, 08, 20, 20, 20),
                        NumerPesel = "97080812345",
                        NumerTelefonu = "123456789",
                        AdresEmail = "aPodlaski@gmail.com",
                        AdresZamieszkania = "Warszawa"
                    });
                    o.HasData(new
                    {
                        Id = 2L,
                        Imie = "Mateusz",
                        Nazwisko = "Pietras",
                        DataUrodzenia = new DateTime(1997, 05, 18, 12, 20, 30),
                        NumerPesel = "97051812345",
                        NumerTelefonu = "113456789",
                        AdresEmail = "mPietras@gmail.com",
                        AdresZamieszkania = "Kaski"
                    });
                    o.HasData(new
                    {
                        Id = 3L,
                        Imie = "Jan",
                        Nazwisko = "Kostera",
                        DataUrodzenia = new DateTime(1997, 08, 05, 10, 10, 10),
                        NumerPesel = "97080512345",
                        NumerTelefonu = "123156789",
                        AdresEmail = "jachoStera@gmail.com",
                        AdresZamieszkania = "Piastów"
                    });
                    o.HasData(new
                    {
                        Id = 4L,
                        Imie = "Karol",
                        Nazwisko = "Plac",
                        DataUrodzenia = new DateTime(1997, 08, 08, 02, 02, 02),
                        NumerPesel = "97080814345",
                        NumerTelefonu = "123454789",
                        AdresEmail = "kPlac@gmail.com",
                        AdresZamieszkania = "Warszawa"
                    });
                    o.HasData(new
                    {
                        Id = 5L,
                        Imie = "Waldemar",
                        Nazwisko = "Waldzki",
                        DataUrodzenia = new DateTime(1997, 08, 08, 03, 03, 03),
                        NumerPesel = "97080818345",
                        NumerTelefonu = "123458789",
                        AdresEmail = "wWaldzki@gmail.com",
                        AdresZamieszkania = "Warszawa"
                    });
                    o.HasData(new
                    {
                        Id = 6L,
                        Imie = "Maciej",
                        Nazwisko = "Bedi",
                        DataUrodzenia = new DateTime(1997, 08, 08, 02, 03, 03),
                        NumerPesel = "97080818645",
                        NumerTelefonu = "123458769",
                        AdresEmail = "BediMaciej@gmail.com",
                        AdresZamieszkania = "Warszawa"
                    });
                    o.HasData(new
                    {
                        Id = 7L,
                        Imie = "Roman",
                        Nazwisko = "Koczan",
                        DataUrodzenia = new DateTime(1997, 08, 09, 03, 03, 03),
                        NumerPesel = "97080919345",
                        NumerTelefonu = "123458999",
                        AdresEmail = "RomaNKocz@gmail.com",
                        AdresZamieszkania = "Grodzisk Mazowiecki"
                    });
                    o.HasData(new
                    {
                        Id = 8L,
                        Imie = "Tymon",
                        Nazwisko = "Gołda",
                        DataUrodzenia = new DateTime(1990, 08, 08, 03, 03, 03),
                        NumerPesel = "90080818345",
                        NumerTelefonu = "120058789",
                        AdresEmail = "TymnoGold@gmail.com",
                        AdresZamieszkania = "Piastów"
                    });
                });

            modelBuilder
                .Entity<Procedura>(p =>
                {
                    p.HasData(new
                    {
                        Id = 1L,
                        NazwaProcedura = "Badanie kontrolne",
                        KosztProcedura = 20,
                        CzyPotrzebnyZespolOperacyjny = false,
                        CzyProceduraInwazyjna = false
                    });
                    p.HasData(new
                    {
                        Id = 2L,
                        NazwaProcedura = "Operacja serca",
                        KosztProcedura = 10000,
                        CzyPotrzebnyZespolOperacyjny = true,
                        CzyProceduraInwazyjna = true
                    });
                    p.HasData(new
                    {
                        Id = 3L,
                        NazwaProcedura = "Badanie krwi",
                        KosztProcedura = 50,
                        CzyPotrzebnyZespolOperacyjny = false,
                        CzyProceduraInwazyjna = true
                    });
                    p.HasData(new
                    {
                        Id = 4L,
                        NazwaProcedura = "Usg Serca",
                        KosztProcedura = 140,
                        CzyPotrzebnyZespolOperacyjny = false,
                        CzyProceduraInwazyjna = false
                    });
                });

            modelBuilder
                .Entity<PakietMedyczny>(pm =>
                {
                    pm.HasData(new
                    {
                        Id = 1L,
                        NazwaPakiet = "MedPack"
                    });
                });

            modelBuilder
                .Entity<PakietMedycznyProcedura>(pmp =>
                {
                    pmp.HasData(new
                    {
                        PakietMedycznyId = 1L,
                        ProceduraId = 1L,
                        DataPrzypisania = new DateTime(2020, 08, 08, 03, 03, 03)
                    });
                    pmp.HasData(new
                    {
                        PakietMedycznyId = 1L,
                        ProceduraId = 2L,
                        DataPrzypisania = new DateTime(2019, 08, 08, 03, 03, 03)
                    });
                });

            modelBuilder
                .Entity<Pacjent>(p =>
                {
                    p.HasData(new
                    {
                        Id = 1L,
                        OsobaId = 1L,
                        UbezpiecznieZdrowotne = false,
                        PakietMedycznyId = 1L
                    });
                    p.HasData(new
                    {
                        Id = 2L,
                        OsobaId = 2L,
                        UbezpiecznieZdrowotne = true,
                        PakietMedycznyId = 1L
                    });
                    p.HasData(new
                    {
                        Id = 3L,
                        OsobaId = 3L,
                        UbezpiecznieZdrowotne = false
                    });
                    p.HasData(new
                    {
                        Id = 4L,
                        OsobaId = 6L,
                        UbezpiecznieZdrowotne = true
                    });
                    p.HasData(new
                    {
                        Id = 5L,
                        OsobaId = 7L,
                        UbezpiecznieZdrowotne = false,
                        PakietMedycznyId = 1L
                    });
                    p.HasData(new
                    {
                        Id = 6L,
                        OsobaId = 8L,
                        UbezpiecznieZdrowotne = true,
                        PakietMedycznyId = 1L
                    });
                });

            modelBuilder
                .Entity<Doktor>(d =>
                {
                    d.HasData(new
                    {
                        Id = 1L,
                        OsobaId = 4L,
                        Pensja = 3400,
                        SpecjalizacjaDoktor = "Kardiolog"
                    });
                    d.HasData(new
                    {
                        Id = 2L,
                        OsobaId = 5L,
                        Pensja = 3400,
                        SpecjalizacjaDoktor = "Kardiolog"
                    });
                    d.HasData(new
                    {
                        Id = 3L,
                        OsobaId = 2L,
                        Pensja = 3300,
                        SpecjalizacjaDoktor = "Laryngolog"
                    });
                });

            modelBuilder
                .Entity<Doktor>()
                .HasMany(p => p.Uprawnienia)
                .WithMany(p => p.Doktorzy)
                .UsingEntity(j =>
                {
                    j.HasData(new
                    {
                        UprawnieniaId = 1L,
                        DoktorzyId = 1L
                    });
                    j.HasData(new
                    {
                        UprawnieniaId = 2L,
                        DoktorzyId = 1L
                    });
                    j.HasData(new
                    {
                        UprawnieniaId = 4L,
                        DoktorzyId = 1L
                    });
                    j.HasData(new
                    {
                        UprawnieniaId = 1L,
                        DoktorzyId = 2L
                    });
                    j.HasData(new
                    {
                        UprawnieniaId = 2L,
                        DoktorzyId = 2L
                    });
                    j.HasData(new
                    {
                        UprawnieniaId = 4L,
                        DoktorzyId = 2L
                    });
                    j.HasData(new
                    {
                        UprawnieniaId = 1L,
                        DoktorzyId = 3L
                    });
                });
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
