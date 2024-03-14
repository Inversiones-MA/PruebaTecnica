using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.SqlServerContext;

public partial class PruebaTecnicaContext : DbContext
{
    public PruebaTecnicaContext()
    {
    }

    public PruebaTecnicaContext(DbContextOptions<PruebaTecnicaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Ciudad> Ciudads { get; set; }

    public virtual DbSet<Comuna> Comunas { get; set; }

    public virtual DbSet<Persona> Personas { get; set; }

    public virtual DbSet<Region> Regions { get; set; }

    public virtual DbSet<Sexo> Sexos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DANIPC\\SQLEXPRESS02;Initial Catalog=PruebaTecnica;Integrated Security=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Ciudad>(entity =>
        {
            entity.HasKey(e => new { e.RegionCodigo, e.Codigo });

            entity.ToTable("Ciudad");

            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.RegionCodigoNavigation).WithMany(p => p.Ciudads)
                .HasForeignKey(d => d.RegionCodigo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Ciudad_Region");
        });

        modelBuilder.Entity<Comuna>(entity =>
        {
            entity.HasKey(e => new { e.RegionCodigo, e.CiudadCodigo, e.Codigo });

            entity.ToTable("Comuna");

            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Ciudad).WithMany(p => p.Comunas)
                .HasForeignKey(d => new { d.RegionCodigo, d.CiudadCodigo })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Comuna_Ciudad");
        });

        modelBuilder.Entity<Persona>(entity =>
        {
            entity.ToTable("Persona");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.ApellidoMaterno)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.ApellidoPaterno)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.Direccion).HasColumnType("text");
            entity.Property(e => e.Email)
                .HasMaxLength(256)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(95)
                .IsUnicode(false)
                .HasComputedColumnSql("(CONVERT([varchar](95),(((rtrim(ltrim([ApellidoPaterno]))+' ')+isnull(rtrim(ltrim([ApellidoMaterno])),''))+', ')+rtrim(ltrim([Nombres])),(0)))", false);
            entity.Property(e => e.Nombres)
                .HasMaxLength(45)
                .IsUnicode(false);
            entity.Property(e => e.Observaciones).HasColumnType("text");
            entity.Property(e => e.Run)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasComputedColumnSql("(CONVERT([varchar],([dbo].[FormatInt]([RunCuerpo])+'-')+[RunDigito],(0)))", false);
            entity.Property(e => e.RunDigito)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();

            entity.HasOne(d => d.SexoCodigoNavigation).WithMany(p => p.Personas)
                .HasForeignKey(d => d.SexoCodigo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Persona_Sexo");

            entity.HasOne(d => d.Comuna).WithMany(p => p.Personas)
                .HasForeignKey(d => new { d.RegionCodigo, d.CiudadCodigo, d.ComunaCodigo })
                .HasConstraintName("FK_Persona_Comuna");
        });

        modelBuilder.Entity<Region>(entity =>
        {
            entity.HasKey(e => e.Codigo);

            entity.ToTable("Region");

            entity.Property(e => e.Codigo).ValueGeneratedNever();
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.NombreOficial)
                .HasMaxLength(40)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Sexo>(entity =>
        {
            entity.HasKey(e => e.Codigo);

            entity.ToTable("Sexo");

            entity.Property(e => e.Codigo).ValueGeneratedNever();
            entity.Property(e => e.Letra)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
