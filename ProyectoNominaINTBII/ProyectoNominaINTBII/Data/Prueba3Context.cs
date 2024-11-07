﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ProyectoNominaINTBII.Models;
namespace ProyectoNominaINTBII.Data;

public partial class Prueba3Context : DbContext
{
    public Prueba3Context()
    {
    }

    public Prueba3Context(DbContextOptions<Prueba3Context> options)
        : base(options)
    {
    }

    public virtual DbSet<AreaGeografica> AreaGeograficas { get; set; }

    public virtual DbSet<BaseCotizacion> BaseCotizacions { get; set; }

    public virtual DbSet<Categorium> Categoria { get; set; }

    public virtual DbSet<Departamento> Departamentos { get; set; }

    public virtual DbSet<Empresa> Empresas { get; set; }

    public virtual DbSet<EmpresaRegPat> EmpresaRegPats { get; set; }

    public virtual DbSet<EstadoCivil> EstadoCivils { get; set; }

    public virtual DbSet<MotivoNoTimbrar> MotivoNoTimbrars { get; set; }

    public virtual DbSet<Puesto> Puestos { get; set; }

    public virtual DbSet<SatBanco> SatBancos { get; set; }

    public virtual DbSet<SatEstado> SatEstados { get; set; }

    public virtual DbSet<SatFormaPago> SatFormaPagos { get; set; }

    public virtual DbSet<SatMonedum> SatMoneda { get; set; }

    public virtual DbSet<SatMunicipio> SatMunicipios { get; set; }

    public virtual DbSet<SatOrigenRecurso> SatOrigenRecursos { get; set; }

    public virtual DbSet<SatPai> SatPais { get; set; }

    public virtual DbSet<SatPeriocidadPago> SatPeriocidadPagos { get; set; }

    public virtual DbSet<SatRegimenFiscal> SatRegimenFiscals { get; set; }

    public virtual DbSet<SatRiesgoPuesto> SatRiesgoPuestos { get; set; }

    public virtual DbSet<SatTipoContrato> SatTipoContratos { get; set; }

    public virtual DbSet<SatTipoHora> SatTipoHoras { get; set; }

    public virtual DbSet<SatTipoJornadum> SatTipoJornada { get; set; }

    public virtual DbSet<SatTipoRegiman> SatTipoRegimen { get; set; }

    public virtual DbSet<Sexo> Sexos { get; set; }

    public virtual DbSet<TipoConstitucion> TipoConstitucions { get; set; }

    public virtual DbSet<TipoEmpleado> TipoEmpleados { get; set; }

    public virtual DbSet<TipoEmpresa> TipoEmpresas { get; set; }

    public virtual DbSet<Trabajador> Trabajadors { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-F3JTBSV;Initial Catalog=PRUEBA3;Integrated Security=True;Encrypt=True;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AreaGeografica>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__AreaGeog__3214EC078CDFB954");

            entity.ToTable("AreaGeografica");

            entity.Property(e => e.Clave)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Descripcion)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Estatus)
                .HasMaxLength(1)
                .IsUnicode(false);
        });

        modelBuilder.Entity<BaseCotizacion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__BaseCoti__3214EC07FD714EE0");

            entity.ToTable("BaseCotizacion");

            entity.Property(e => e.Descripcion)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Estatus)
                .HasMaxLength(1)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Categorium>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Categori__3214EC07534C5BE5");

            entity.Property(e => e.Descripcion)
                .HasMaxLength(60)
                .IsUnicode(false);
            entity.Property(e => e.Estatus)
                .HasMaxLength(1)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Departamento>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Departam__3214EC071B0464FC");

            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Estatus)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.MontoPropio).HasColumnType("decimal(15, 3)").IsRequired(true);
        });

        modelBuilder.Entity<Empresa>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Empresa__3214EC0741E1CD59");

            entity.ToTable("Empresa");

            entity.Property(e => e.Calle)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ClaveFonacot)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("ClaveFONACOT");
            entity.Property(e => e.ClaveImss)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("ClaveIMSS");
            entity.Property(e => e.ClaveInfonavit)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("ClaveINFONAVIT");
            entity.Property(e => e.Colonia)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ContraseñaSat)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("ContraseñaSAT");
            entity.Property(e => e.Cp)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasColumnName("CP");
            entity.Property(e => e.Curp)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("CURP");
            entity.Property(e => e.Email)
                .HasMaxLength(60)
                .IsUnicode(false);
            entity.Property(e => e.Estatus)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.FechaAlta).HasColumnType("datetime");
            entity.Property(e => e.LugarExpedicion)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.NumeroExt)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.NumeroInt)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.PathCertificadoSat)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("PathCertificadoSAT");
            entity.Property(e => e.PathLlaveSat)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("PathLlaveSAT");
            entity.Property(e => e.PathLogo)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.PathTimbrado)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.PorcentajePresFed).HasColumnType("decimal(10, 3)");
            entity.Property(e => e.ProveedorSat)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("ProveedorSAT");
            entity.Property(e => e.Rfc)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("RFC");
            entity.Property(e => e.TelefonoFijo)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.TelefonoWhatsApp)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.TipoComprobante)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Estado).WithMany(p => p.Empresas)
                .HasForeignKey(d => d.EstadoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Empresa_SatEstados");

            entity.HasOne(d => d.Moneda).WithMany(p => p.Empresas)
                .HasForeignKey(d => d.MonedaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Empresa_SatMoneda");

            entity.HasOne(d => d.Municipio).WithMany(p => p.Empresas)
                .HasForeignKey(d => d.MunicipioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Empresa_SatMunicipios");

            entity.HasOne(d => d.Pais).WithMany(p => p.Empresas)
                .HasForeignKey(d => d.PaisId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Empresa_SatPais");

            entity.HasOne(d => d.RegimenFiscal).WithMany(p => p.Empresas)
                .HasForeignKey(d => d.RegimenFiscalId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Empresa_SatRegimenFiscal");

            entity.HasOne(d => d.TipoConstitucion).WithMany(p => p.Empresas)
                .HasForeignKey(d => d.TipoConstitucionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Empresa_TipoConstitucion");

            entity.HasOne(d => d.TipoEmpresa).WithMany(p => p.Empresas)
                .HasForeignKey(d => d.TipoEmpresaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Empresa_tipoEmpresa");

            entity.HasOne(d => d.TipoHora).WithMany(p => p.Empresas)
                .HasForeignKey(d => d.TipoHoraId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Empresa_SatTipoHoras1");
        });

        modelBuilder.Entity<EmpresaRegPat>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__EmpresaR__3214EC0738218455");

            entity.ToTable("EmpresaRegPat");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.LugarExpedicion)
                .HasMaxLength(450)
                .IsUnicode(false);
            entity.Property(e => e.NumeroSerie)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.PassSat)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("PassSAT");
            entity.Property(e => e.PathCertificadoSat)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("PathCertificadoSAT");
            entity.Property(e => e.PathLlaveSat)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("PathLlaveSAT");
            entity.Property(e => e.RegistroPatronal)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.VigenciaFinal).HasColumnType("datetime");
            entity.Property(e => e.VigenciaInicial).HasColumnType("datetime");

            entity.HasOne(d => d.AreaGeografica).WithMany(p => p.EmpresaRegPats)
                .HasForeignKey(d => d.AreaGeograficaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EmpresaRegPat_AreaGeografica");

            entity.HasOne(d => d.Empresa).WithMany(p => p.EmpresaRegPats)
                .HasForeignKey(d => d.EmpresaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EmpresaRegPat_Empresa");

            entity.HasOne(d => d.RiesgoPuesto).WithMany(p => p.EmpresaRegPats)
                .HasForeignKey(d => d.RiesgoPuestoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EmpresaRegPat_SatRiesgoPuesto");
        });

        modelBuilder.Entity<EstadoCivil>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__EstadoCi__3214EC071C523635");

            entity.ToTable("EstadoCivil");

            entity.Property(e => e.Descripcion)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Estatus)
                .HasMaxLength(1)
                .IsUnicode(false);
        });

        modelBuilder.Entity<MotivoNoTimbrar>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__MotivoNo__3214EC070FB1E5C4");

            entity.ToTable("MotivoNoTimbrar");

            entity.Property(e => e.Descripcion)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Estatus)
                .HasMaxLength(1)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Puesto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Puesto__3214EC0762B9311C");

            entity.ToTable("Puesto");

            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Estatus)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.SalarioFin).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.SalarioIni).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Categoria).WithMany(p => p.Puestos)
                .HasForeignKey(d => d.CategoriaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Puesto_Categoria");

            entity.HasOne(d => d.Empresa).WithMany(p => p.Puestos)
                .HasForeignKey(d => d.EmpresaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Puesto_Empresa");
        });

        modelBuilder.Entity<SatBanco>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__SatBanco__3214EC07C70C43B2");

            entity.Property(e => e.ClaveAbm).HasColumnName("ClaveABM");
            entity.Property(e => e.ClaveSat)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("ClaveSAT");
            entity.Property(e => e.DescripcionSat)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("DescripcionSAT");
            entity.Property(e => e.Estatus)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.FechaInicioVigenciaSat)
                .HasColumnType("datetime")
                .HasColumnName("FechaInicioVigenciaSAT");
            entity.Property(e => e.FehcaFinVigenciaSat)
                .HasColumnType("datetime")
                .HasColumnName("FehcaFinVigenciaSAT");
            entity.Property(e => e.RazonSocialSat)
                .HasMaxLength(120)
                .IsUnicode(false)
                .HasColumnName("RazonSocialSAT");
        });

        modelBuilder.Entity<SatEstado>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__SatEstad__3214EC0794816D66");

            entity.Property(e => e.ClaveSat)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("ClaveSAT");
            entity.Property(e => e.DescripcionSat)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("DescripcionSAT");
            entity.Property(e => e.Estatus)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.FechaFinVigenciaSat)
                .HasColumnType("datetime")
                .HasColumnName("FechaFinVigenciaSAT");
            entity.Property(e => e.FechaInicioVigenciaSat)
                .HasColumnType("datetime")
                .HasColumnName("FechaInicioVigenciaSAT");
            entity.Property(e => e.FolioInegi).HasColumnName("FolioINEGI");
        });

        modelBuilder.Entity<SatFormaPago>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__SatForma__3214EC07B07706B2");

            entity.ToTable("SatFormaPago");

            entity.Property(e => e.BancarizadoSat)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("BancarizadoSAT");
            entity.Property(e => e.ClaveSat)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("ClaveSAT");
            entity.Property(e => e.DescripcionSat)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("DescripcionSAT");
            entity.Property(e => e.Estatus)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.FechaFinVigenciaSat)
                .HasColumnType("datetime")
                .HasColumnName("FechaFinVigenciaSAT");
            entity.Property(e => e.FechaInicioVigenciaSat)
                .HasColumnType("datetime")
                .HasColumnName("FechaInicioVigenciaSAT");
            entity.Property(e => e.Tipo)
                .HasMaxLength(5)
                .IsUnicode(false);
        });

        modelBuilder.Entity<SatMonedum>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__SatMoned__3214EC07A64E60AF");

            entity.Property(e => e.ClaveSat)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("ClaveSAT");
            entity.Property(e => e.DecimalesSat).HasColumnName("DecimalesSAT");
            entity.Property(e => e.DescripcionSat)
                .HasMaxLength(90)
                .IsUnicode(false)
                .HasColumnName("DescripcionSAT");
            entity.Property(e => e.Estatus)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.FechaFinVigenciaSat)
                .HasColumnType("datetime")
                .HasColumnName("FechaFinVigenciaSAT");
            entity.Property(e => e.FechaInicioVariacionSat)
                .HasColumnType("datetime")
                .HasColumnName("FechaInicioVariacionSAT");
            entity.Property(e => e.PorcentajeVariacionSat).HasColumnName("PorcentajeVariacionSAT");
        });

        modelBuilder.Entity<SatMunicipio>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__SatMunic__3214EC0791466ACB");

            entity.Property(e => e.ClaveSat)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("ClaveSAT");
            entity.Property(e => e.DescripcionSat)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("DescripcionSAT");
            entity.Property(e => e.Estatus)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.FechaFinVigenciaSat)
                .HasColumnType("datetime")
                .HasColumnName("FechaFinVigenciaSAT");
            entity.Property(e => e.FechaInicioVigenciaSat)
                .HasColumnType("datetime")
                .HasColumnName("FechaInicioVigenciaSAT");
        });

        modelBuilder.Entity<SatOrigenRecurso>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__SatOrige__3214EC076736D59B");

            entity.ToTable("SatOrigenRecurso");

            entity.Property(e => e.DscripcionSat)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("DscripcionSAT");
            entity.Property(e => e.Estatus)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.OrigenRecursoSat)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("OrigenRecursoSAT");
        });

        modelBuilder.Entity<SatPai>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__SatPais__3214EC0712955279");

            entity.Property(e => e.AgrupacionesSat)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("AgrupacionesSAT");
            entity.Property(e => e.ClaveSat)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("ClaveSAT");
            entity.Property(e => e.DescripcionSat)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("DescripcionSAT");
            entity.Property(e => e.Estatus)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.FmotRegIdenTribSat)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("FmotRegIdenTribSAT");
            entity.Property(e => e.FmtoCodPostalSat)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("FmtoCodPostalSAT");
            entity.Property(e => e.ValidaRegIdenTribSat)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ValidaRegIdenTribSAT");
        });

        modelBuilder.Entity<SatPeriocidadPago>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__SatPerio__3214EC0718BE1F93");

            entity.ToTable("SatPeriocidadPago");

            entity.Property(e => e.ClaveSat)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("ClaveSAT");
            entity.Property(e => e.DescripcionSat)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("DescripcionSAT");
            entity.Property(e => e.DiasValidos)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Estatus)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.FechaFinVigenciaSat)
                .HasColumnType("datetime")
                .HasColumnName("FechaFinVigenciaSAT");
            entity.Property(e => e.FechaInicioVigenciaSat)
                .HasColumnType("datetime")
                .HasColumnName("FechaInicioVigenciaSAT");
        });

        modelBuilder.Entity<SatRegimenFiscal>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__SatRegim__3214EC074604F1C9");

            entity.ToTable("SatRegimenFiscal");

            entity.Property(e => e.ClaveSat)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("ClaveSAT");
            entity.Property(e => e.DescripcionSat)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("DescripcionSAT");
            entity.Property(e => e.Estatus)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.FechaFinVigenciaSat)
                .HasColumnType("datetime")
                .HasColumnName("FechaFinVigenciaSAT");
            entity.Property(e => e.FechaInicioVigenciaSat)
                .HasColumnType("datetime")
                .HasColumnName("FechaInicioVigenciaSAT");
            entity.Property(e => e.PersonaFisicaSat)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("PersonaFisicaSAT");
            entity.Property(e => e.PersonaMoralSat)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("PersonaMoralSAT");
        });

        modelBuilder.Entity<SatRiesgoPuesto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__SatRiesg__3214EC07ACA33F99");

            entity.ToTable("SatRiesgoPuesto");

            entity.Property(e => e.ClaveSat)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("ClaveSAT");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Estatus)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.FechaFinVigencia).HasColumnType("datetime");
            entity.Property(e => e.FechaInicioVigencia).HasColumnType("datetime");
        });

        modelBuilder.Entity<SatTipoContrato>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__SatTipoC__3214EC078E837AFF");

            entity.ToTable("SatTipoContrato");

            entity.Property(e => e.ClaveSat)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ClaveSAT");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Estatus)
                .HasMaxLength(1)
                .IsUnicode(false);
        });

        modelBuilder.Entity<SatTipoHora>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__SatTipoH__3214EC0780F05EE9");

            entity.Property(e => e.ClaveSat)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ClaveSAT");
            entity.Property(e => e.DescripcionSat)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("DescripcionSAT");
            entity.Property(e => e.Estatus)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.Monto).HasColumnType("decimal(15, 2)");
        });

        modelBuilder.Entity<SatTipoJornadum>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__SatTipoJ__3214EC07D92BB009");

            entity.Property(e => e.ClaveSat)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("ClaveSAT");
            entity.Property(e => e.DescripcionSat)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("DescripcionSAT");
            entity.Property(e => e.Estatus)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.Horas).HasColumnType("decimal(15, 3)");
        });

        modelBuilder.Entity<SatTipoRegiman>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__SatTipoR__3214EC0731F5BB49");

            entity.Property(e => e.ClaveSat)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("ClaveSAT");
            entity.Property(e => e.DescripcionSat)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("DescripcionSAT");
            entity.Property(e => e.Estatus)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.FechaFinVigenciaSat)
                .HasColumnType("datetime")
                .HasColumnName("FechaFinVigenciaSAT");
            entity.Property(e => e.FechaInicioVigenciaSat)
                .HasColumnType("datetime")
                .HasColumnName("FechaInicioVigenciaSAT");
        });

        modelBuilder.Entity<Sexo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Sexo__3214EC078398C340");

            entity.ToTable("Sexo");

            entity.Property(e => e.Descipcion)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Estatus)
                .HasMaxLength(1)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TipoConstitucion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TipoCons__3214EC0709C33A0C");

            entity.ToTable("TipoConstitucion");

            entity.Property(e => e.Descripcion)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Estatus)
                .HasMaxLength(1)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TipoEmpleado>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TipoEmpl__3214EC0746321B0D");

            entity.ToTable("TipoEmpleado");

            entity.Property(e => e.Descipcion)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Estatus)
                .HasMaxLength(1)
                .IsUnicode(false);

            entity.HasOne(d => d.Empresa).WithMany(p => p.TipoEmpleados)
                .HasForeignKey(d => d.EmpresaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TipoEmpleado_Empresa");
        });

        modelBuilder.Entity<TipoEmpresa>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TipoEmpr__3214EC07723FB68D");

            entity.ToTable("TipoEmpresa");

            entity.Property(e => e.Descripcion)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Estatus)
                .HasMaxLength(1)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Trabajador>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Trabajad__3214EC073726F55B");

            entity.ToTable("Trabajador");

            entity.Property(e => e.ApellidoMaterno)
                .HasMaxLength(35)
                .IsUnicode(false);
            entity.Property(e => e.ApellidoPaterno)
                .HasMaxLength(35)
                .IsUnicode(false);
            entity.Property(e => e.Calle)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Clabe)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("CLABE");
            entity.Property(e => e.Colonia)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Cp)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasColumnName("CP");
            entity.Property(e => e.Curp)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("CURP");
            entity.Property(e => e.Email)
                .HasMaxLength(60)
                .IsUnicode(false);
            entity.Property(e => e.Estatus)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.FechaBaja).HasColumnType("datetime");
            entity.Property(e => e.FechaIngreso).HasColumnType("datetime");
            entity.Property(e => e.FechaNac).HasColumnType("datetime");
            entity.Property(e => e.MontoPropio).HasColumnType("decimal(15, 3)");
            entity.Property(e => e.Nombre)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.Nss)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("NSS");
            entity.Property(e => e.NumEmpleado)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.NumeroExt)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.NumeroInt)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.PorcentajePresFed).HasColumnType("decimal(15, 3)");
            entity.Property(e => e.Rfc)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("RFC");
            entity.Property(e => e.Salario).HasColumnType("decimal(18, 3)");
            entity.Property(e => e.SalarioDiario).HasColumnType("decimal(18, 3)");
            entity.Property(e => e.SalarioDiarioInte).HasColumnType("decimal(18, 3)");
            entity.Property(e => e.TelefonoFijo)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.TelefonoMovil)
                .HasMaxLength(15)
                .IsUnicode(false);

            entity.HasOne(d => d.Banco).WithMany(p => p.Trabajadors)
                .HasForeignKey(d => d.BancoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Trabajador_SatBancos");

            entity.HasOne(d => d.BaseCotizacion).WithMany(p => p.Trabajadors)
                .HasForeignKey(d => d.BaseCotizacionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Trabajador_BaseCotizacion");

            entity.HasOne(d => d.Departamento).WithMany(p => p.Trabajadors)
                .HasForeignKey(d => d.DepartamentoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Trabajador_Departamentos");

            entity.HasOne(d => d.Empresa).WithMany(p => p.Trabajadors)
                .HasForeignKey(d => d.EmpresaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Trabajador_Empresa");

            entity.HasOne(d => d.EmpresaRegimenPat).WithMany(p => p.Trabajadors)
                .HasForeignKey(d => d.EmpresaRegimenPatId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Trabajador_EmpresaRegPat");

            entity.HasOne(d => d.EstadoCivil).WithMany(p => p.Trabajadors)
                .HasForeignKey(d => d.EstadoCivilId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Trabajador_EstadoCivil");

            entity.HasOne(d => d.Estado).WithMany(p => p.Trabajadors)
                .HasForeignKey(d => d.EstadoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Trabajador_SatEstados");

            entity.HasOne(d => d.FormaPago).WithMany(p => p.Trabajadors)
                .HasForeignKey(d => d.FormaPagoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Trabajador_SatFormaPago");

            entity.HasOne(d => d.MotivoNoTimbrar).WithMany(p => p.Trabajadors)
                .HasForeignKey(d => d.MotivoNoTimbrarId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Trabajador_MotivoNoTimbrar");

            entity.HasOne(d => d.Municipio).WithMany(p => p.Trabajadors)
                .HasForeignKey(d => d.MunicipioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Trabajador_SatMunicipios");

            entity.HasOne(d => d.OrigenRecurso).WithMany(p => p.Trabajadors)
                .HasForeignKey(d => d.OrigenRecursoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Trabajador_SatOrigenRecurso");

            entity.HasOne(d => d.Pais).WithMany(p => p.Trabajadors)
                .HasForeignKey(d => d.PaisId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Trabajador_SatPais");

            entity.HasOne(d => d.PeriocidadPago).WithMany(p => p.Trabajadors)
                .HasForeignKey(d => d.PeriocidadPagoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Trabajador_SatPeriocidadPago");

            entity.HasOne(d => d.Puesto).WithMany(p => p.Trabajadors)
                .HasForeignKey(d => d.PuestoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Trabajador_Puesto");

            entity.HasOne(d => d.Sexo).WithMany(p => p.Trabajadors)
                .HasForeignKey(d => d.SexoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Trabajador_Sexo");

            entity.HasOne(d => d.TipoContrato).WithMany(p => p.Trabajadors)
                .HasForeignKey(d => d.TipoContratoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Trabajador_SatTipoContrato");

            entity.HasOne(d => d.TipoEmpleado).WithMany(p => p.Trabajadors)
                .HasForeignKey(d => d.TipoEmpleadoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Trabajador_TipoEmpleado");

            entity.HasOne(d => d.TipoJornada).WithMany(p => p.Trabajadors)
                .HasForeignKey(d => d.TipoJornadaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Trabajador_SatTipoJornada");

            entity.HasOne(d => d.TipoRegimen).WithMany(p => p.Trabajadors)
                .HasForeignKey(d => d.TipoRegimenId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Trabajador_SatTipoRegimen");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
