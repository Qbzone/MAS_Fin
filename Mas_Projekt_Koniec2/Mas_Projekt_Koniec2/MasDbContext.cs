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
            modelBuilder.Entity<Wizyta>(entity =>
            {
                entity.HasKey(e => new { e.PacjentId, e.DoktorId, e.PoczatekWizyty })
                .HasName("PakietMedycznyProcedura_pk");
            });
            modelBuilder.Entity<HospitalizacjaProcedura>(entity =>
            {
                entity.HasKey(e => new { e.ProceduraId, e.HospitalizacjaId, e.DataWykonania })
                .HasName("PakietMedycznyProcedura_pk");
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
        public virtual DbSet<Hospitalizacja> Hospitalizacja {get; set;}
        public virtual DbSet<HospitalizacjaProcedura> HospitalizacjaProcedura { get; set; }
    }
}
