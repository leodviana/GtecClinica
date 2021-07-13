using System;
using GtecClinica.Dados.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace GtecClinica.Dados.Contexto
{
    public partial class GtecContexto : DbContext
    {
        public GtecContexto()
        {
        }

        public GtecContexto(DbContextOptions<GtecContexto> options)
            : base(options)
        {
        }

        public virtual DbSet<Teste> Teste { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.;Database=Gtec;Trusted_Connection=Yes;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Teste>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Nome)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
