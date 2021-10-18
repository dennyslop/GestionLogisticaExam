using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace BodegasApi.EFModels
{
    public partial class GestionLogisticaContext : DbContext
    {
        public GestionLogisticaContext()
        {
        }

        public GestionLogisticaContext(DbContextOptions<GestionLogisticaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Bodega> Bodegas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AI");

            modelBuilder.Entity<Bodega>(entity =>
            {
                entity.Property(e => e.CodBodega)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.NombreBodega)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
