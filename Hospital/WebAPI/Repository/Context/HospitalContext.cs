using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Repository.Model;

namespace WebAPI.Repository.Context
{
    public class HospitalContext : DbContext
    {
        public HospitalContext(DbContextOptions<HospitalContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        private static DbContextOptions GetOptions(string connectionString) =>
        SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder(), connectionString).Options;


        #region [ DbSet ]

        public DbSet<TB_ATENDIMENTO> Atendimentos { get; set; }
        public DbSet<TB_ENDERECO> Enderecos { get; set; }
        public DbSet<TB_FUNCIONARIO> Funcionarios { get; set; }
        public DbSet<TB_MEDICAMENTO> Medicamentos { get; set; }
        public DbSet<TB_PACIENTE> Pacientes { get; set; }

        #endregion

        #region [ ModelCreating ]

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region [ TB_PACIENTE ]
            modelBuilder.Entity<TB_PACIENTE>()
            .HasKey(p => p.Id);

            modelBuilder.Entity<TB_PACIENTE>()
            .HasMany(p => p.Atendimentos)
            .WithOne(a => a.TB_PACIENTE);

            modelBuilder.Entity<TB_PACIENTE>()
            .HasOne(e => e.TB_ENDERECO);
            #endregion


            #region [ TB_MEDICAMENTO ]
            modelBuilder.Entity<TB_MEDICAMENTO>()
            .HasKey(e => e.Id);

            modelBuilder.Entity<TB_MEDICAMENTO>()
            .HasOne(m => m.TB_ATENDIMENTO)
            .WithMany(a => a.Medicamentos);
            #endregion

            #region [ TB_FUNCIONARIO ]

            modelBuilder.Entity<TB_FUNCIONARIO>()
            .HasKey(e => e.Id);

            modelBuilder.Entity<TB_FUNCIONARIO>()
            .HasMany(a => a.Atendimentos)
            .WithOne(f => f.TB_FUNCIONARIO);

            modelBuilder.Entity<TB_FUNCIONARIO>()
            .HasOne(f => f.TB_ATENDIMENTO)
            .WithMany(a => a.Funcionarios);

            modelBuilder.Entity<TB_FUNCIONARIO>()
            .HasOne(e => e.TB_ENDERECO);

            #endregion

            #region [ TB_ATENDIMENTO ]

            modelBuilder.Entity<TB_ATENDIMENTO>()
            .HasKey(a => a.Id);

            modelBuilder.Entity<TB_ATENDIMENTO>()
            .HasMany(p => p.Pacientes)
            .WithOne(a => a.TB_ATENDIMENTO);

            modelBuilder.Entity<TB_ATENDIMENTO>()
            .HasMany(f => f.Funcionarios)
            .WithOne(a => a.TB_ATENDIMENTO);

            modelBuilder.Entity<TB_ATENDIMENTO>()
            .HasOne(f => f.TB_FUNCIONARIO)
            .WithMany(a => a.Atendimentos);

            modelBuilder.Entity<TB_ATENDIMENTO>()
            .HasMany(m => m.Medicamentos)
            .WithOne(a => a.TB_ATENDIMENTO);


            #endregion

            #region [ TB_ENDERECO ]

            modelBuilder.Entity<TB_ENDERECO>()
            .HasKey(e => e.Id);
            #endregion

        }

        #endregion

    }
}
