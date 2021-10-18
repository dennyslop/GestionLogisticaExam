using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace ClientesApi.EFModels
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

        public virtual DbSet<Cliente> Clientes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AI");

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.Property(e => e.DireccionCliente)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NombreCliente)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TelefonoCliente)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
