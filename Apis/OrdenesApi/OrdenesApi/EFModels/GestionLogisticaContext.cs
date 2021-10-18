using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace OrdenesApi.EFModels
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
        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<EntregaMaritimo> EntregaMaritimos { get; set; }
        public virtual DbSet<EntregaTerrestre> EntregaTerrestres { get; set; }
        public virtual DbSet<Puerto> Puertos { get; set; }

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

            modelBuilder.Entity<EntregaMaritimo>(entity =>
            {
                entity.HasKey(e => e.EntregaId);

                entity.ToTable("EntregaMaritimo");

                entity.Property(e => e.FechaEntrega).HasColumnType("date");

                entity.Property(e => e.FechaRegistro).HasColumnType("date");

                entity.Property(e => e.NumeroFlota)
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.NumeroGuia)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.PrecioEnvio).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.Cliente)
                    .WithMany(p => p.EntregaMaritimos)
                    .HasForeignKey(d => d.ClienteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EntregaMaritimo_Clientes");

                entity.HasOne(d => d.Puerto)
                    .WithMany(p => p.EntregaMaritimos)
                    .HasForeignKey(d => d.PuertoId)
                    .HasConstraintName("FK_EntregaMaritimo_Puertos");
            });

            modelBuilder.Entity<EntregaTerrestre>(entity =>
            {
                entity.HasKey(e => e.EntregaId);

                entity.ToTable("EntregaTerrestre");

                entity.Property(e => e.FechaEntrega).HasColumnType("date");

                entity.Property(e => e.FechaRegistro).HasColumnType("date");

                entity.Property(e => e.NumeroGuia)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.PlacaVehiculo)
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.PrecioEnvio).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.Bodega)
                    .WithMany(p => p.EntregaTerrestres)
                    .HasForeignKey(d => d.BodegaId)
                    .HasConstraintName("FK_EntregaTerrestre_Bodegas");

                entity.HasOne(d => d.Cliente)
                    .WithMany(p => p.EntregaTerrestres)
                    .HasForeignKey(d => d.ClienteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EntregaTerrestre_Clientes");
            });

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
