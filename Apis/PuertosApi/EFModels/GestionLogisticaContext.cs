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

        public virtual DbSet<Puerto> Puertos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AI");

            modelBuilder.Entity<Puerto>(entity =>
            {
                entity.Property(e => e.CodPuerto)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.NombrePuerto).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
