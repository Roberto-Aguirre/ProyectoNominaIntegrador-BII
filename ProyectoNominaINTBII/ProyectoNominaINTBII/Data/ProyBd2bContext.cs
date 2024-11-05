using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ProyectoNominaINTBII.Models;


namespace ProyectoNominaINTBII.Data;

public partial class ProyBd2bContext : DbContext
{
    public ProyBd2bContext()
    {
    }

    public ProyBd2bContext(DbContextOptions<ProyBd2bContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AreaGeografica> AreaGeograficas { get; set; }

    public virtual DbSet<BaseCotizacion> BaseCotizacions { get; set; }

    public virtual DbSet<Categorias> Categoria { get; set; }

    public virtual DbSet<Departamento> Departamentos { get; set; }

    public virtual DbSet<Empresa> Empresas { get; set; }

    public virtual DbSet<EmpresaRegPat> EmpresaRegPats { get; set; }

    public virtual DbSet<EstadoCivil> EstadoCivils { get; set; }

    public virtual DbSet<MotivoNoTimbrar> MotivoNoTimbrars { get; set; }

    public virtual DbSet<Puesto> Puestos { get; set; }

    public virtual DbSet<SatBanco> SatBancos { get; set; }

    public virtual DbSet<SatEstado> SatEstados { get; set; }

    public virtual DbSet<SatFormaPago> SatFormaPagos { get; set; }

    public virtual DbSet<SatMoneda> SatMoneda { get; set; }

    public virtual DbSet<SatMunicipio> SatMunicipios { get; set; }

    public virtual DbSet<SatOrigenRecurso> SatOrigenRecursos { get; set; }

    public virtual DbSet<SatPais> SatPais { get; set; }

    public virtual DbSet<SatPeriocidadPago> SatPeriocidadPagos { get; set; }

    public virtual DbSet<SatRegimenFiscal> SatRegimenFiscals { get; set; }

    public virtual DbSet<SatRiesgoPuesto> SatRiesgoPuestos { get; set; }

    public virtual DbSet<SatTipoContrato> SatTipoContratos { get; set; }

    public virtual DbSet<SatTipoHora> SatTipoHoras { get; set; }

    public virtual DbSet<SatTipoJornada> SatTipoJornada { get; set; }

    public virtual DbSet<SatTipoRegimen> SatTipoRegimen { get; set; }

    public virtual DbSet<Sexo> Sexos { get; set; }

    public virtual DbSet<TipoConstitucion> TipoConstitucions { get; set; }

    public virtual DbSet<TipoEmpleado> TipoEmpleados { get; set; }

    public virtual DbSet<TipoEmpresa> TipoEmpresas { get; set; }

    public virtual DbSet<Trabajador> Trabajadors { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-F3JTBSV;Initial Catalog=PROY_BD_2B;Integrated Security=True;Encrypt=True;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AreaGeografica>(entity =>
        {
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
            entity.ToTable("BaseCotizacion");

            entity.Property(e => e.Descripcion)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Estatus)
                .HasMaxLength(1)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Categorias>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Descripcion)
                .HasMaxLength(60)
                .IsUnicode(false);
            entity.Property(e => e.Estatus)
                .HasMaxLength(1)
                .IsUnicode(false);

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.Categorium)
                .HasForeignKey<Categorias>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Categoria_Empresa");
        });

        modelBuilder.Entity<Departamento>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Descripcion)
                .HasMaxLength(60)
                .IsUnicode(false);
            entity.Property(e => e.Estatus)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.MontoPropio).HasColumnType("decimal(15, 3)");

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.Departamento)
                .HasForeignKey<Departamento>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Departamentos_Empresa");
        });

        modelBuilder.Entity<Empresa>(entity =>
        {
            entity.ToTable("Empresa");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
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

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.Empresa)
                .HasForeignKey<Empresa>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Empresa_SatEstados");

            entity.HasOne(d => d.Id1).WithOne(p => p.Empresa)
                .HasForeignKey<Empresa>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Empresa_SatMoneda");

            entity.HasOne(d => d.Id2).WithOne(p => p.Empresa)
                .HasForeignKey<Empresa>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Empresa_SatMunicipios");

            entity.HasOne(d => d.Id3).WithOne(p => p.Empresa)
                .HasForeignKey<Empresa>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Empresa_SatPais");

            entity.HasOne(d => d.Id4).WithOne(p => p.Empresa)
                .HasForeignKey<Empresa>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Empresa_SatRegimenFiscal");

            entity.HasOne(d => d.Id5).WithOne(p => p.Empresa)
                .HasForeignKey<Empresa>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Empresa_SatTipoHoras");

            entity.HasOne(d => d.Id6).WithOne(p => p.Empresa)
                .HasForeignKey<Empresa>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Empresa_TipoConstitucion");

            entity.HasOne(d => d.Id7).WithOne(p => p.Empresa)
                .HasForeignKey<Empresa>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Empresa_tipoEmpresa");
        });

        modelBuilder.Entity<EmpresaRegPat>(entity =>
        {
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

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.EmpresaRegPat)
                .HasForeignKey<EmpresaRegPat>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EmpresaRegPat_AreaGeografica");

            entity.HasOne(d => d.Id1).WithOne(p => p.EmpresaRegPat)
                .HasForeignKey<EmpresaRegPat>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EmpresaRegPat_Empresa");

            entity.HasOne(d => d.Id2).WithOne(p => p.EmpresaRegPat)
                .HasForeignKey<EmpresaRegPat>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EmpresaRegPat_SatRiesgoPuesto");
        });

        modelBuilder.Entity<EstadoCivil>(entity =>
        {
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
            entity.ToTable("Puesto");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Descripcion)
                .HasMaxLength(60)
                .IsUnicode(false);
            entity.Property(e => e.Estatus)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.SalarioFin).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.SalarioIni).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.Puesto)
                .HasForeignKey<Puesto>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Puesto_Categoria");
        });

        modelBuilder.Entity<SatBanco>(entity =>
        {
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
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
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

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.SatEstado)
                .HasForeignKey<SatEstado>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SatEstados_SatPais");
        });

        modelBuilder.Entity<SatFormaPago>(entity =>
        {
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

        modelBuilder.Entity<SatMoneda>(entity =>
        {
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
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
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

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.SatMunicipio)
                .HasForeignKey<SatMunicipio>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SatMunicipios_SatEstados");
        });

        modelBuilder.Entity<SatOrigenRecurso>(entity =>
        {
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

        modelBuilder.Entity<SatPais>(entity =>
        {
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
            entity.ToTable("SatRiesgoPuesto");

            entity.Property(e => e.ClaveSat)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("ClaveSAT");
            entity.Property(e => e.DechaFinVigencia).HasColumnType("datetime");
            entity.Property(e => e.DechaInicioVigencia).HasColumnType("datetime");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Estatus)
                .HasMaxLength(1)
                .IsUnicode(false);
        });

        modelBuilder.Entity<SatTipoContrato>(entity =>
        {
            entity.ToTable("SatTipoContrato");

            entity.Property(e => e.ClaveSat)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ClaveSAT");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(60)
                .IsUnicode(false);
            entity.Property(e => e.Estatus)
                .HasMaxLength(1)
                .IsUnicode(false);
        });

        modelBuilder.Entity<SatTipoHora>(entity =>
        {
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

        modelBuilder.Entity<SatTipoJornada>(entity =>
        {
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

        modelBuilder.Entity<SatTipoRegimen>(entity =>
        {
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
            entity.ToTable("TipoEmpleado");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Descipcion)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Estatus)
                .HasMaxLength(1)
                .IsUnicode(false);

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.TipoEmpleado)
                .HasForeignKey<TipoEmpleado>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TipoEmpleado_Empresa");
        });

        modelBuilder.Entity<TipoEmpresa>(entity =>
        {
            entity.ToTable("tipoEmpresa");

            entity.Property(e => e.Descripcion)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Estatus)
                .HasMaxLength(1)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Trabajador>(entity =>
        {
            entity.ToTable("Trabajador");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
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

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.Trabajador)
                .HasForeignKey<Trabajador>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Trabajador_BaseCotizacion");

            entity.HasOne(d => d.Id1).WithOne(p => p.Trabajador)
                .HasForeignKey<Trabajador>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Trabajador_Departamentos");

            entity.HasOne(d => d.Id2).WithOne(p => p.Trabajador)
                .HasForeignKey<Trabajador>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Trabajador_Empresa");

            entity.HasOne(d => d.Id3).WithOne(p => p.Trabajador)
                .HasForeignKey<Trabajador>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Trabajador_EmpresaRegPat");

            entity.HasOne(d => d.Id4).WithOne(p => p.Trabajador)
                .HasForeignKey<Trabajador>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Trabajador_EstadoCivil");

            entity.HasOne(d => d.Id5).WithOne(p => p.Trabajador)
                .HasForeignKey<Trabajador>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Trabajador_MotivoNoTimbrar");

            entity.HasOne(d => d.Id6).WithOne(p => p.Trabajador)
                .HasForeignKey<Trabajador>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Trabajador_Puesto");

            entity.HasOne(d => d.Id7).WithOne(p => p.Trabajador)
                .HasForeignKey<Trabajador>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Trabajador_SatBancos");

            entity.HasOne(d => d.Id8).WithOne(p => p.Trabajador)
                .HasForeignKey<Trabajador>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Trabajador_SatEstados");

            entity.HasOne(d => d.Id9).WithOne(p => p.Trabajador)
                .HasForeignKey<Trabajador>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Trabajador_SatFormaPago");

            entity.HasOne(d => d.Id10).WithOne(p => p.Trabajador)
                .HasForeignKey<Trabajador>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Trabajador_SatMunicipios");

            entity.HasOne(d => d.Id11).WithOne(p => p.Trabajador)
                .HasForeignKey<Trabajador>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Trabajador_SatOrigenRecurso");

            entity.HasOne(d => d.Id12).WithOne(p => p.Trabajador)
                .HasForeignKey<Trabajador>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Trabajador_SatPais");

            entity.HasOne(d => d.Id13).WithOne(p => p.Trabajador)
                .HasForeignKey<Trabajador>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Trabajador_SatPeriocidadPago");

            entity.HasOne(d => d.Id14).WithOne(p => p.Trabajador)
                .HasForeignKey<Trabajador>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Trabajador_SatTipoContrato");

            entity.HasOne(d => d.Id15).WithOne(p => p.Trabajador)
                .HasForeignKey<Trabajador>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Trabajador_SatTipoJornada");

            entity.HasOne(d => d.Id16).WithOne(p => p.Trabajador)
                .HasForeignKey<Trabajador>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Trabajador_SatTipoRegimen");

            entity.HasOne(d => d.Id17).WithOne(p => p.Trabajador)
                .HasForeignKey<Trabajador>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Trabajador_Sexo");

            entity.HasOne(d => d.Id18).WithOne(p => p.Trabajador)
                .HasForeignKey<Trabajador>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Trabajador_TipoEmpleado");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
