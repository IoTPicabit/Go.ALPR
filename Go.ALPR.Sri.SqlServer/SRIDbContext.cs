using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Go.ALPR.Sri.SqlServer.Entities;

#nullable disable

namespace Go.ALPR.Sri.SqlServer
{
    public partial class SRIDbContext : DbContext
    {
        public SRIDbContext()
        {
        }

        public SRIDbContext(DbContextOptions<SRIDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Acceso> Accesos { get; set; }
        public virtual DbSet<Contacto> Contactos { get; set; }
        public virtual DbSet<Empresa> Empresas { get; set; }
        public virtual DbSet<EstadoProceso> EstadoProcesos { get; set; }
        public virtual DbSet<Foto> Fotos { get; set; }
        public virtual DbSet<Localizacion> Localizacions { get; set; }
        public virtual DbSet<Operacion> Operacions { get; set; }
        public virtual DbSet<TVision> TVisions { get; set; }
        public virtual DbSet<TVisionAcceso> TVisionAccesos { get; set; }
        public virtual DbSet<TipoCarga> TipoCargas { get; set; }
        public virtual DbSet<TipoOperacion> TipoOperacions { get; set; }
        public virtual DbSet<Transporte> Transportes { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Contacto>(entity =>
            {
                entity.Property(e => e.Habilitado).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.IdEmpresaNavigation)
                    .WithMany(p => p.Contactos)
                    .HasForeignKey(d => d.IdEmpresa)
                    .HasConstraintName("FK_Contacto_Empresa");

                entity.HasOne(d => d.IdTipoCargaNavigation)
                    .WithMany(p => p.Contactos)
                    .HasForeignKey(d => d.IdTipoCarga)
                    .HasConstraintName("FK_Contacto_TipoCarga");
            });

            modelBuilder.Entity<Empresa>(entity =>
            {
                entity.Property(e => e.Habilitado).HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<Foto>(entity =>
            {
                entity.HasKey(e => new { e.IdOperacion, e.Tipo });

                entity.HasOne(d => d.IdOperacionNavigation)
                    .WithMany(p => p.Fotos)
                    .HasForeignKey(d => d.IdOperacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Foto_Operacion");
            });

            modelBuilder.Entity<Localizacion>(entity =>
            {
                entity.Property(e => e.Habilitado).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.IdTipoOperacionNavigation)
                    .WithMany(p => p.Localizacions)
                    .HasForeignKey(d => d.IdTipoOperacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Localizacion_TipoOperacion");
            });

            modelBuilder.Entity<Operacion>(entity =>
            {
                entity.HasOne(d => d.IdTipoOperacionNavigation)
                    .WithMany(p => p.Operacions)
                    .HasForeignKey(d => d.IdTipoOperacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Operacion_TipoOperacion");
            });

            modelBuilder.Entity<TVision>(entity =>
            {
                entity.Property(e => e.BitVida).HasDefaultValueSql("((0))");

                entity.Property(e => e.Fecha).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<TVisionAcceso>(entity =>
            {
                entity.Property(e => e.BitVida).HasDefaultValueSql("((0))");

                entity.Property(e => e.Fecha).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<TipoCarga>(entity =>
            {
                entity.HasOne(d => d.IdEmpresaExpedicionNavigation)
                    .WithMany(p => p.TipoCargas)
                    .HasForeignKey(d => d.IdEmpresaExpedicion)
                    .HasConstraintName("FK_TipoCarga_Empresa");

                entity.HasOne(d => d.IdTipoCargaPadreNavigation)
                    .WithMany(p => p.InverseIdTipoCargaPadreNavigation)
                    .HasForeignKey(d => d.IdTipoCargaPadre)
                    .HasConstraintName("FK_TipoCarga_TipoCargaPadre");

                entity.HasOne(d => d.IdTipoOperacionNavigation)
                    .WithMany(p => p.TipoCargas)
                    .HasForeignKey(d => d.IdTipoOperacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TipoCarga_TipoOperacion");
            });

            modelBuilder.Entity<Transporte>(entity =>
            {
                entity.HasOne(d => d.IdEmpresaNavigation)
                    .WithMany(p => p.Transportes)
                    .HasForeignKey(d => d.IdEmpresa)
                    .HasConstraintName("FK_Transporte_Empresa");

                entity.HasOne(d => d.IdTipoCargaNavigation)
                    .WithMany(p => p.Transportes)
                    .HasForeignKey(d => d.IdTipoCarga)
                    .HasConstraintName("FK_Transporte_TipoCarga");

                entity.HasOne(d => d.IdTipoOperacionNavigation)
                    .WithMany(p => p.Transportes)
                    .HasForeignKey(d => d.IdTipoOperacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Transporte_TipoOperacion");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
