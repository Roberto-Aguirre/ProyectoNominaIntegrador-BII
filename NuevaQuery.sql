USE [master]
GO
/****** Object:  Database [PROY_BD_2B]    Script Date: 08/10/2024 07:42:29 p. m. ******/
CREATE DATABASE [PROY_BD_2B]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'PROY_BD_2B', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\PROY_BD_2B.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'PROY_BD_2B_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\PROY_BD_2B_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [PROY_BD_2B] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [PROY_BD_2B].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [PROY_BD_2B] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [PROY_BD_2B] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [PROY_BD_2B] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [PROY_BD_2B] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [PROY_BD_2B] SET ARITHABORT OFF 
GO
ALTER DATABASE [PROY_BD_2B] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [PROY_BD_2B] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [PROY_BD_2B] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [PROY_BD_2B] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [PROY_BD_2B] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [PROY_BD_2B] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [PROY_BD_2B] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [PROY_BD_2B] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [PROY_BD_2B] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [PROY_BD_2B] SET  DISABLE_BROKER 
GO
ALTER DATABASE [PROY_BD_2B] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [PROY_BD_2B] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [PROY_BD_2B] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [PROY_BD_2B] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [PROY_BD_2B] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [PROY_BD_2B] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [PROY_BD_2B] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [PROY_BD_2B] SET RECOVERY FULL 
GO
ALTER DATABASE [PROY_BD_2B] SET  MULTI_USER 
GO
ALTER DATABASE [PROY_BD_2B] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [PROY_BD_2B] SET DB_CHAINING OFF 
GO
ALTER DATABASE [PROY_BD_2B] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [PROY_BD_2B] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [PROY_BD_2B] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [PROY_BD_2B] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'PROY_BD_2B', N'ON'
GO
ALTER DATABASE [PROY_BD_2B] SET QUERY_STORE = ON
GO
ALTER DATABASE [PROY_BD_2B] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [PROY_BD_2B]
GO
/****** Object:  Table [dbo].[AreaGeografica]    Script Date: 08/10/2024 07:42:29 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AreaGeografica](
	[Id] [int] NOT NULL IDENTITY(1,1),
	[Clave] [varchar](10) NOT NULL,
	[Descripcion] [varchar](50) NOT NULL,
	[Estatus] [varchar](1) NOT NULL,
 CONSTRAINT [PK_AreaGeografica] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BaseCotizacion]    Script Date: 08/10/2024 07:42:30 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BaseCotizacion](
	[Id] [int] NOT NULL IDENTITY(1,1),
	[Descripcion] [varchar](20) NOT NULL,
	[Estatus] [varchar](1) NOT NULL,
 CONSTRAINT [PK_BaseCotizacion] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categoria]    Script Date: 08/10/2024 07:42:30 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categoria](
	[Id] [int] NOT NULL IDENTITY(1,1),
	[Descripcion] [varchar](60) NOT NULL,
	[Empresa] [int] NULL,
	[Estatus] [varchar](1) NOT NULL,
 CONSTRAINT [PK_Categoria] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Departamentos]    Script Date: 08/10/2024 07:42:30 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Departamentos](
	[Id] [int] NOT NULL IDENTITY(1,1),
	[Descripcion] [varchar](60) NOT NULL,
	[Empresa] [int] NULL,
	[MontoPropio] [decimal](15, 3) NULL,
	[Estatus] [varchar](1) NOT NULL,
 CONSTRAINT [PK_Departamentos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Empresa]    Script Date: 08/10/2024 07:42:30 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Empresa](
	[Id] [int] NOT NULL IDENTITY(1,1),
	[FechaAlta] [datetime] NOT NULL,
	[RFC] [varchar](15) NOT NULL,
	[Nombre] [varchar](150) NOT NULL,
	[Calle] [varchar](50) NULL,
	[NumeroExt] [varchar](15) NULL,
	[NumeroInt] [varchar](15) NULL,
	[Colonia] [varchar](50) NULL,
	[CP] [varchar](8) NOT NULL,
	[CURP] [varchar](20) NULL,
	[Municipio] [int] NOT NULL,
	[Estado] [int] NOT NULL,
	[Pais] [int] NOT NULL,
	[Email] [varchar](60) NULL,
	[TipoComprobante] [varchar](50) NULL,
	[PathLogo] [varchar](100) NULL,
	[PathCertificadoSAT] [varchar](100) NULL,
	[PathLlaveSAT] [varchar](100) NULL,
	[ContraseñaSAT] [varchar](100) NULL,
	[ProveedorSAT] [varchar](100) NULL,
	[PathTimbrado] [varchar](100) NULL,
	[Moneda] [int] NOT NULL,
	[RegimenFiscal] [int] NOT NULL,
	[CumpleReqCuotas] [bit] NOT NULL,
	[ClaveIMSS] [varchar](40) NULL,
	[ClaveINFONAVIT] [varchar](40) NULL,
	[ClaveFONACOT] [varchar](40) NULL,
	[LugarExpedicion] [varchar](100) NULL,
	[TipoEmpresa] [int] NOT NULL,
	[TipoHora] [int] NOT NULL,
	[PorcentajePresFed] [decimal](10, 3) NULL,
	[TelefonoWhatsApp] [varchar](15) NULL,
	[TelefonoFijo] [varchar](15) NULL,
	[TipoConstitucion] [int] NOT NULL,
	[Estatus] [varchar](1) NOT NULL,
 CONSTRAINT [PK_Empresa] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EmpresaRegPat]    Script Date: 08/10/2024 07:42:30 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmpresaRegPat](
	[Id] [int] NOT NULL,
	[Empresa] [int] NOT NULL,
	[AreaGeografica] [int] NOT NULL,
	[RiesgoPuesto] [int] NOT NULL,
	[RegistroPatronal] [varchar](20) NULL,
	[LugarExpedicion] [varchar](450) NULL,
	[PathCertificadoSAT] [varchar](100) NULL,
	[PathLlaveSAT] [varchar](100) NULL,
	[PassSAT] [varchar](100) NULL,
	[VigenciaInicial] [datetime] NULL,
	[VigenciaFinal] [datetime] NULL,
	[NumeroSerie] [varchar](30) NULL,
 CONSTRAINT [PK_EmpresaRegPat] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EstadoCivil]    Script Date: 08/10/2024 07:42:30 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EstadoCivil](
	[Id] [int] NOT NULL IDENTITY(1,1),
	[Descripcion] [varchar](50) NOT NULL,
	[Estatus] [varchar](1) NOT NULL,
 CONSTRAINT [PK_EstadoCivil] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MotivoNoTimbrar]    Script Date: 08/10/2024 07:42:30 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MotivoNoTimbrar](
	[Id] [int] NOT NULL IDENTITY(1,1),
	[Descripcion] [varchar](50) NOT NULL,
	[Estatus] [varchar](1) NOT NULL,
 CONSTRAINT [PK_MotivoNoTimbrar] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Puesto]    Script Date: 08/10/2024 07:42:30 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Puesto](
	[Id] [int] NOT NULL IDENTITY(1,1),
	[Categoria] [int] NOT NULL,
	[Descripcion] [varchar](60) NOT NULL,
	[SalarioIni] [decimal](18, 2) NULL,
	[SalarioFin] [decimal](18, 2) NULL,
	[Empresa] [int] NULL,
	[Estatus] [varchar](1) NOT NULL,
 CONSTRAINT [PK_Puesto] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SatBancos]    Script Date: 08/10/2024 07:42:30 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SatBancos](
	[Id] [int] NOT NULL IDENTITY(1,1),
	[ClaveSAT] [varchar](5) NOT NULL,
	[DescripcionSAT] [varchar](40) NOT NULL,
	[RazonSocialSAT] [varchar](120) NOT NULL,
	[FechaInicioVigenciaSAT] [datetime] NULL,
	[FehcaFinVigenciaSAT] [datetime] NULL,
	[ClaveABM] [int] NOT NULL,
	[Estatus] [varchar](1) NOT NULL,
 CONSTRAINT [PK_SatBancos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SatEstados]    Script Date: 08/10/2024 07:42:30 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SatEstados](
	[Id] [int] NOT NULL IDENTITY(1,1),
	[Pais] [int] NOT NULL,
	[ClaveSAT] [varchar](5) NOT NULL,
	[DescripcionSAT] [varchar](50) NOT NULL,
	[FechaInicioVigenciaSAT] [datetime] NULL,
	[FechaFinVigenciaSAT] [datetime] NULL,
	[FolioINEGI] [int] NOT NULL,
	[Estatus] [varchar](1) NOT NULL,
 CONSTRAINT [PK_SatEstados] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SatFormaPago]    Script Date: 08/10/2024 07:42:30 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SatFormaPago](
	[Id] [int] NOT NULL IDENTITY(1,1),
	[ClaveSAT] [varchar](5) NOT NULL,
	[DescripcionSAT] [varchar](50) NOT NULL,
	[BancarizadoSAT] [varchar](2) NOT NULL,
	[Tipo] [varchar](5) NOT NULL,
	[FechaInicioVigenciaSAT] [datetime] NULL,
	[FechaFinVigenciaSAT] [datetime] NULL,
	[Estatus] [varchar](1) NOT NULL,
 CONSTRAINT [PK_SatFormaPago] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SatMoneda]    Script Date: 08/10/2024 07:42:30 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SatMoneda](
	[Id] [int] NOT NULL IDENTITY(1,1),
	[ClaveSAT] [varchar](5) NOT NULL,
	[DescripcionSAT] [varchar](90) NOT NULL,
	[DecimalesSAT] [int] NOT NULL,
	[PorcentajeVariacionSAT] [int] NULL,
	[FechaInicioVariacionSAT] [datetime] NULL,
	[FechaFinVigenciaSAT] [datetime] NULL,
	[Estatus] [varchar](1) NOT NULL,
 CONSTRAINT [PK_SatMoneda] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SatMunicipios]    Script Date: 08/10/2024 07:42:30 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SatMunicipios](
	[Id] [int] NOT NULL IDENTITY(1,1),
	[Estado] [int] NOT NULL,
	[ClaveSAT] [varchar](5) NOT NULL,
	[DescripcionSAT] [varchar](60) NOT NULL,
	[FechaInicioVigenciaSAT] [datetime] NULL,
	[FechaFinVigenciaSAT] [datetime] NULL,
	[Estatus] [varchar](1) NOT NULL,
 CONSTRAINT [PK_SatMunicipios] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SatOrigenRecurso]    Script Date: 08/10/2024 07:42:30 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SatOrigenRecurso](
	[Id] [int] NOT NULL IDENTITY(1,1),
	[OrigenRecursoSAT] [varchar](5) NOT NULL,
	[DscripcionSAT] [varchar](25) NOT NULL,
	[Estatus] [varchar](1) NOT NULL,
 CONSTRAINT [PK_SatOrigenRecurso] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SatPais]    Script Date: 08/10/2024 07:42:30 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SatPais](
	[Id] [int] NOT NULL IDENTITY(1,1),
	[ClaveSAT] [varchar](5) NOT NULL,
	[DescripcionSAT] [varchar](60) NOT NULL,
	[FmtoCodPostalSAT] [varchar](50) NULL,
	[FmotRegIdenTribSAT] [varchar](100) NULL,
	[ValidaRegIdenTribSAT] [varchar](50) NULL,
	[AgrupacionesSAT] [varchar](50) NULL,
	[Estatus] [varchar](1) NOT NULL,
 CONSTRAINT [PK_SatPais] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SatPeriocidadPago]    Script Date: 08/10/2024 07:42:30 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SatPeriocidadPago](
	[Id] [int] NOT NULL IDENTITY(1,1),
	[ClaveSAT] [varchar](5) NOT NULL,
	[DescripcionSAT] [varchar](30) NOT NULL,
	[FechaInicioVigenciaSAT] [datetime] NULL,
	[FechaFinVigenciaSAT] [datetime] NULL,
	[Dias] [int] NOT NULL,
	[DiasValidos] [varchar](30) NULL,
	[Estatus] [varchar](1) NOT NULL,
 CONSTRAINT [PK_SatPeriocidadPago] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SatRegimenFiscal]    Script Date: 08/10/2024 07:42:30 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SatRegimenFiscal](
	[Id] [int] NOT NULL IDENTITY(1,1),
	[ClaveSAT] [varchar](5) NOT NULL,
	[DescripcionSAT] [varchar](100) NOT NULL,
	[PersonaFisicaSAT] [varchar](2) NOT NULL,
	[PersonaMoralSAT] [varchar](2) NOT NULL,
	[FechaInicioVigenciaSAT] [datetime] NULL,
	[FechaFinVigenciaSAT] [datetime] NULL,
	[Estatus] [varchar](1) NOT NULL,
 CONSTRAINT [PK_SatRegimenFiscal] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SatRiesgoPuesto]    Script Date: 08/10/2024 07:42:30 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SatRiesgoPuesto](
	[Id] [int] NOT NULL IDENTITY(1,1),
	[ClaveSAT] [varchar](5) NOT NULL,
	[Descripcion] [varchar](20) NOT NULL,
	[DechaInicioVigencia] [datetime] NULL,
	[DechaFinVigencia] [datetime] NULL,
	[Estatus] [varchar](1) NOT NULL,
 CONSTRAINT [PK_SatRiesgoPuesto] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SatTipoContrato]    Script Date: 08/10/2024 07:42:30 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SatTipoContrato](
	[Id] [int] NOT NULL IDENTITY(1,1),
	[ClaveSAT] [varchar](10) NOT NULL,
	[Descripcion] [varchar](60) NOT NULL,
	[Estatus] [varchar](1) NOT NULL,
 CONSTRAINT [PK_SatTipoContrato] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SatTipoHoras]    Script Date: 08/10/2024 07:42:30 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SatTipoHoras](
	[Id] [int] NOT NULL IDENTITY(1,1),
	[ClaveSAT] [varchar](10) NOT NULL,
	[DescripcionSAT] [varchar](250) NOT NULL,
	[Monto] [decimal](15, 2) NOT NULL,
	[Estatus] [varchar](1) NOT NULL,
 CONSTRAINT [PK_SatTipoHoras] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SatTipoJornada]    Script Date: 08/10/2024 07:42:30 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SatTipoJornada](
	[Id] [int] NOT NULL IDENTITY(1,1),
	[ClaveSAT] [varchar](5) NOT NULL,
	[DescripcionSAT] [varchar](20) NOT NULL,
	[Horas] [decimal](15, 3) NOT NULL,
	[Estatus] [varchar](1) NOT NULL,
 CONSTRAINT [PK_SatTipoJornada] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SatTipoRegimen]    Script Date: 08/10/2024 07:42:30 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SatTipoRegimen](
	[Id] [int] NOT NULL IDENTITY(1,1),
	[ClaveSAT] [varchar](5) NOT NULL,
	[DescripcionSAT] [varchar](60) NOT NULL,
	[FechaInicioVigenciaSAT] [datetime] NULL,
	[FechaFinVigenciaSAT] [datetime] NULL,
	[Estatus] [varchar](1) NOT NULL,
 CONSTRAINT [PK_SatTipoRegimen] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sexo]    Script Date: 08/10/2024 07:42:30 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sexo](
	[Id] [int] NOT NULL IDENTITY(1,1),
	[Descipcion] [varchar](50) NOT NULL,
	[Estatus] [varchar](1) NOT NULL,
 CONSTRAINT [PK_Sexo] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoConstitucion]    Script Date: 08/10/2024 07:42:30 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoConstitucion](
	[Id] [int] NOT NULL IDENTITY(1,1),
	[Descripcion] [varchar](30) NOT NULL,
	[Estatus] [varchar](1) NOT NULL,
 CONSTRAINT [PK_TipoConstitucion] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoEmpleado]    Script Date: 08/10/2024 07:42:30 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoEmpleado](
	[Id] [int] NOT NULL IDENTITY(1,1),
	[Descipcion] [varchar](50) NOT NULL,
	[Empresa] [int] NULL,
	[Estatus] [varchar](1) NOT NULL,
 CONSTRAINT [PK_TipoEmpleado] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tipoEmpresa]    Script Date: 08/10/2024 07:42:30 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tipoEmpresa](
	[Id] [int] NOT NULL IDENTITY(1,1),
	[Descripcion] [varchar](30) NOT NULL,
	[Estatus] [varchar](1) NOT NULL,
 CONSTRAINT [PK_tipoEmpresa] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Trabajador]    Script Date: 08/10/2024 07:42:30 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Trabajador](
	[Id] [int] NOT NULL IDENTITY(1,1),
	[Empresa] [int] NOT NULL,
	[TipoEmpleado] [int] NOT NULL,
	[TipoContrato] [int] NOT NULL,
	[NumEmpleado] [varchar](15) NOT NULL,
	[Nombre] [varchar](40) NOT NULL,
	[ApellidoPaterno] [varchar](35) NULL,
	[ApellidoMaterno] [varchar](35) NULL,
	[Sexo] [int] NOT NULL,
	[EstadoCivil] [int] NOT NULL,
	[FechaNac] [datetime] NULL,
	[Calle] [varchar](50) NULL,
	[NumeroExt] [varchar](15) NULL,
	[NumeroInt] [varchar](15) NULL,
	[Colonia] [varchar](50) NULL,
	[CP] [varchar](8) NOT NULL,
	[Pais] [int] NOT NULL,
	[Municipio] [int] NOT NULL,
	[Estado] [int] NOT NULL,
	[TelefonoMovil] [varchar](15) NULL,
	[TelefonoFijo] [varchar](15) NULL,
	[RFC] [varchar](15) NULL,
	[CURP] [varchar](20) NOT NULL,
	[NSS] [varchar](30) NULL,
	[FechaIngreso] [datetime] NOT NULL,
	[FechaBaja] [datetime] NULL,
	[PeriocidadPago] [int] NOT NULL,
	[FormaPago] [int] NOT NULL,
	[CuentaBanco] [int] NOT NULL,
	[CLABE] [varchar](20) NOT NULL,
	[Banco] [int] NOT NULL,
	[Email] [varchar](60) NULL,
	[Salario] [decimal](18, 3) NOT NULL,
	[SalarioDiario] [decimal](18, 3) NOT NULL,
	[SalarioDiarioInte] [decimal](18, 3) NOT NULL,
	[CumpleReqDisminucion] [bit] NOT NULL,
	[TipoRegimen] [int] NOT NULL,
	[Puesto] [int] NOT NULL,
	[Departamento] [int] NOT NULL,
	[BaseCotizacion] [int] NOT NULL,
	[TipoJornada] [int] NOT NULL,
	[OrigenRecurso] [int] NOT NULL,
	[PorcentajePresFed] [decimal](15, 3) NULL,
	[MontoPropio] [decimal](15, 3) NULL,
	[NominaGen] [bit] NOT NULL,
	[EmpresaRegimenPat] [int] NULL,
	[EstatusTimbrado] [int] NOT NULL,
	[MotivoNoTimbrar] [int] NOT NULL,
	[Estatus] [varchar](1) NULL,
 CONSTRAINT [PK_Trabajador] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Categoria]  WITH CHECK ADD  CONSTRAINT [FK_Categoria_Empresa] FOREIGN KEY([Id])
REFERENCES [dbo].[Empresa] ([Id])
GO
ALTER TABLE [dbo].[Categoria] CHECK CONSTRAINT [FK_Categoria_Empresa]
GO
ALTER TABLE [dbo].[Departamentos]  WITH CHECK ADD  CONSTRAINT [FK_Departamentos_Empresa] FOREIGN KEY([Id])
REFERENCES [dbo].[Empresa] ([Id])
GO
ALTER TABLE [dbo].[Departamentos] CHECK CONSTRAINT [FK_Departamentos_Empresa]
GO
ALTER TABLE [dbo].[Empresa]  WITH CHECK ADD  CONSTRAINT [FK_Empresa_SatEstados] FOREIGN KEY([Id])
REFERENCES [dbo].[SatEstados] ([Id])
GO
ALTER TABLE [dbo].[Empresa] CHECK CONSTRAINT [FK_Empresa_SatEstados]
GO
ALTER TABLE [dbo].[Empresa]  WITH CHECK ADD  CONSTRAINT [FK_Empresa_SatMoneda] FOREIGN KEY([Id])
REFERENCES [dbo].[SatMoneda] ([Id])
GO
ALTER TABLE [dbo].[Empresa] CHECK CONSTRAINT [FK_Empresa_SatMoneda]
GO
ALTER TABLE [dbo].[Empresa]  WITH CHECK ADD  CONSTRAINT [FK_Empresa_SatMunicipios] FOREIGN KEY([Id])
REFERENCES [dbo].[SatMunicipios] ([Id])
GO
ALTER TABLE [dbo].[Empresa] CHECK CONSTRAINT [FK_Empresa_SatMunicipios]
GO
ALTER TABLE [dbo].[Empresa]  WITH CHECK ADD  CONSTRAINT [FK_Empresa_SatPais] FOREIGN KEY([Id])
REFERENCES [dbo].[SatPais] ([Id])
GO
ALTER TABLE [dbo].[Empresa] CHECK CONSTRAINT [FK_Empresa_SatPais]
GO
ALTER TABLE [dbo].[Empresa]  WITH CHECK ADD  CONSTRAINT [FK_Empresa_SatRegimenFiscal] FOREIGN KEY([Id])
REFERENCES [dbo].[SatRegimenFiscal] ([Id])
GO
ALTER TABLE [dbo].[Empresa] CHECK CONSTRAINT [FK_Empresa_SatRegimenFiscal]
GO
ALTER TABLE [dbo].[Empresa]  WITH CHECK ADD  CONSTRAINT [FK_Empresa_SatTipoHoras] FOREIGN KEY([Id])
REFERENCES [dbo].[SatTipoHoras] ([Id])
GO
ALTER TABLE [dbo].[Empresa] CHECK CONSTRAINT [FK_Empresa_SatTipoHoras]
GO
ALTER TABLE [dbo].[Empresa]  WITH CHECK ADD  CONSTRAINT [FK_Empresa_TipoConstitucion] FOREIGN KEY([Id])
REFERENCES [dbo].[TipoConstitucion] ([Id])
GO
ALTER TABLE [dbo].[Empresa] CHECK CONSTRAINT [FK_Empresa_TipoConstitucion]
GO
ALTER TABLE [dbo].[Empresa]  WITH CHECK ADD  CONSTRAINT [FK_Empresa_tipoEmpresa] FOREIGN KEY([Id])
REFERENCES [dbo].[tipoEmpresa] ([Id])
GO
ALTER TABLE [dbo].[Empresa] CHECK CONSTRAINT [FK_Empresa_tipoEmpresa]
GO
ALTER TABLE [dbo].[EmpresaRegPat]  WITH CHECK ADD  CONSTRAINT [FK_EmpresaRegPat_AreaGeografica] FOREIGN KEY([Id])
REFERENCES [dbo].[AreaGeografica] ([Id])
GO
ALTER TABLE [dbo].[EmpresaRegPat] CHECK CONSTRAINT [FK_EmpresaRegPat_AreaGeografica]
GO
ALTER TABLE [dbo].[EmpresaRegPat]  WITH CHECK ADD  CONSTRAINT [FK_EmpresaRegPat_Empresa] FOREIGN KEY([Id])
REFERENCES [dbo].[Empresa] ([Id])
GO
ALTER TABLE [dbo].[EmpresaRegPat] CHECK CONSTRAINT [FK_EmpresaRegPat_Empresa]
GO
ALTER TABLE [dbo].[EmpresaRegPat]  WITH CHECK ADD  CONSTRAINT [FK_EmpresaRegPat_SatRiesgoPuesto] FOREIGN KEY([Id])
REFERENCES [dbo].[SatRiesgoPuesto] ([Id])
GO
ALTER TABLE [dbo].[EmpresaRegPat] CHECK CONSTRAINT [FK_EmpresaRegPat_SatRiesgoPuesto]
GO
ALTER TABLE [dbo].[Puesto]  WITH CHECK ADD  CONSTRAINT [FK_Puesto_Categoria] FOREIGN KEY([Id])
REFERENCES [dbo].[Categoria] ([Id])
GO
ALTER TABLE [dbo].[Puesto] CHECK CONSTRAINT [FK_Puesto_Categoria]
GO
ALTER TABLE [dbo].[SatEstados]  WITH CHECK ADD  CONSTRAINT [FK_SatEstados_SatPais] FOREIGN KEY([Id])
REFERENCES [dbo].[SatPais] ([Id])
GO
ALTER TABLE [dbo].[SatEstados] CHECK CONSTRAINT [FK_SatEstados_SatPais]
GO
ALTER TABLE [dbo].[SatMunicipios]  WITH CHECK ADD  CONSTRAINT [FK_SatMunicipios_SatEstados] FOREIGN KEY([Id])
REFERENCES [dbo].[SatEstados] ([Id])
GO
ALTER TABLE [dbo].[SatMunicipios] CHECK CONSTRAINT [FK_SatMunicipios_SatEstados]
GO
ALTER TABLE [dbo].[TipoEmpleado]  WITH CHECK ADD  CONSTRAINT [FK_TipoEmpleado_Empresa] FOREIGN KEY([Id])
REFERENCES [dbo].[Empresa] ([Id])
GO
ALTER TABLE [dbo].[TipoEmpleado] CHECK CONSTRAINT [FK_TipoEmpleado_Empresa]
GO
ALTER TABLE [dbo].[Trabajador]  WITH CHECK ADD  CONSTRAINT [FK_Trabajador_BaseCotizacion] FOREIGN KEY([Id])
REFERENCES [dbo].[BaseCotizacion] ([Id])
GO
ALTER TABLE [dbo].[Trabajador] CHECK CONSTRAINT [FK_Trabajador_BaseCotizacion]
GO
ALTER TABLE [dbo].[Trabajador]  WITH CHECK ADD  CONSTRAINT [FK_Trabajador_Departamentos] FOREIGN KEY([Id])
REFERENCES [dbo].[Departamentos] ([Id])
GO
ALTER TABLE [dbo].[Trabajador] CHECK CONSTRAINT [FK_Trabajador_Departamentos]
GO
ALTER TABLE [dbo].[Trabajador]  WITH CHECK ADD  CONSTRAINT [FK_Trabajador_Empresa] FOREIGN KEY([Id])
REFERENCES [dbo].[Empresa] ([Id])
GO
ALTER TABLE [dbo].[Trabajador] CHECK CONSTRAINT [FK_Trabajador_Empresa]
GO
ALTER TABLE [dbo].[Trabajador]  WITH CHECK ADD  CONSTRAINT [FK_Trabajador_EmpresaRegPat] FOREIGN KEY([Id])
REFERENCES [dbo].[EmpresaRegPat] ([Id])
GO
ALTER TABLE [dbo].[Trabajador] CHECK CONSTRAINT [FK_Trabajador_EmpresaRegPat]
GO
ALTER TABLE [dbo].[Trabajador]  WITH CHECK ADD  CONSTRAINT [FK_Trabajador_EstadoCivil] FOREIGN KEY([Id])
REFERENCES [dbo].[EstadoCivil] ([Id])
GO
ALTER TABLE [dbo].[Trabajador] CHECK CONSTRAINT [FK_Trabajador_EstadoCivil]
GO
ALTER TABLE [dbo].[Trabajador]  WITH CHECK ADD  CONSTRAINT [FK_Trabajador_MotivoNoTimbrar] FOREIGN KEY([Id])
REFERENCES [dbo].[MotivoNoTimbrar] ([Id])
GO
ALTER TABLE [dbo].[Trabajador] CHECK CONSTRAINT [FK_Trabajador_MotivoNoTimbrar]
GO
ALTER TABLE [dbo].[Trabajador]  WITH CHECK ADD  CONSTRAINT [FK_Trabajador_Puesto] FOREIGN KEY([Id])
REFERENCES [dbo].[Puesto] ([Id])
GO
ALTER TABLE [dbo].[Trabajador] CHECK CONSTRAINT [FK_Trabajador_Puesto]
GO
ALTER TABLE [dbo].[Trabajador]  WITH CHECK ADD  CONSTRAINT [FK_Trabajador_SatBancos] FOREIGN KEY([Id])
REFERENCES [dbo].[SatBancos] ([Id])
GO
ALTER TABLE [dbo].[Trabajador] CHECK CONSTRAINT [FK_Trabajador_SatBancos]
GO
ALTER TABLE [dbo].[Trabajador]  WITH CHECK ADD  CONSTRAINT [FK_Trabajador_SatEstados] FOREIGN KEY([Id])
REFERENCES [dbo].[SatEstados] ([Id])
GO
ALTER TABLE [dbo].[Trabajador] CHECK CONSTRAINT [FK_Trabajador_SatEstados]
GO
ALTER TABLE [dbo].[Trabajador]  WITH CHECK ADD  CONSTRAINT [FK_Trabajador_SatFormaPago] FOREIGN KEY([Id])
REFERENCES [dbo].[SatFormaPago] ([Id])
GO
ALTER TABLE [dbo].[Trabajador] CHECK CONSTRAINT [FK_Trabajador_SatFormaPago]
GO
ALTER TABLE [dbo].[Trabajador]  WITH CHECK ADD  CONSTRAINT [FK_Trabajador_SatMunicipios] FOREIGN KEY([Id])
REFERENCES [dbo].[SatMunicipios] ([Id])
GO
ALTER TABLE [dbo].[Trabajador] CHECK CONSTRAINT [FK_Trabajador_SatMunicipios]
GO
ALTER TABLE [dbo].[Trabajador]  WITH CHECK ADD  CONSTRAINT [FK_Trabajador_SatOrigenRecurso] FOREIGN KEY([Id])
REFERENCES [dbo].[SatOrigenRecurso] ([Id])
GO
ALTER TABLE [dbo].[Trabajador] CHECK CONSTRAINT [FK_Trabajador_SatOrigenRecurso]
GO
ALTER TABLE [dbo].[Trabajador]  WITH CHECK ADD  CONSTRAINT [FK_Trabajador_SatPais] FOREIGN KEY([Id])
REFERENCES [dbo].[SatPais] ([Id])
GO
ALTER TABLE [dbo].[Trabajador] CHECK CONSTRAINT [FK_Trabajador_SatPais]
GO
ALTER TABLE [dbo].[Trabajador]  WITH CHECK ADD  CONSTRAINT [FK_Trabajador_SatPeriocidadPago] FOREIGN KEY([Id])
REFERENCES [dbo].[SatPeriocidadPago] ([Id])
GO
ALTER TABLE [dbo].[Trabajador] CHECK CONSTRAINT [FK_Trabajador_SatPeriocidadPago]
GO
ALTER TABLE [dbo].[Trabajador]  WITH CHECK ADD  CONSTRAINT [FK_Trabajador_SatTipoContrato] FOREIGN KEY([Id])
REFERENCES [dbo].[SatTipoContrato] ([Id])
GO
ALTER TABLE [dbo].[Trabajador] CHECK CONSTRAINT [FK_Trabajador_SatTipoContrato]
GO
ALTER TABLE [dbo].[Trabajador]  WITH CHECK ADD  CONSTRAINT [FK_Trabajador_SatTipoJornada] FOREIGN KEY([Id])
REFERENCES [dbo].[SatTipoJornada] ([Id])
GO
ALTER TABLE [dbo].[Trabajador] CHECK CONSTRAINT [FK_Trabajador_SatTipoJornada]
GO
ALTER TABLE [dbo].[Trabajador]  WITH CHECK ADD  CONSTRAINT [FK_Trabajador_SatTipoRegimen] FOREIGN KEY([Id])
REFERENCES [dbo].[SatTipoRegimen] ([Id])
GO
ALTER TABLE [dbo].[Trabajador] CHECK CONSTRAINT [FK_Trabajador_SatTipoRegimen]
GO
ALTER TABLE [dbo].[Trabajador]  WITH CHECK ADD  CONSTRAINT [FK_Trabajador_Sexo] FOREIGN KEY([Id])
REFERENCES [dbo].[Sexo] ([Id])
GO
ALTER TABLE [dbo].[Trabajador] CHECK CONSTRAINT [FK_Trabajador_Sexo]
GO
ALTER TABLE [dbo].[Trabajador]  WITH CHECK ADD  CONSTRAINT [FK_Trabajador_TipoEmpleado] FOREIGN KEY([Id])
REFERENCES [dbo].[TipoEmpleado] ([Id])
GO
ALTER TABLE [dbo].[Trabajador] CHECK CONSTRAINT [FK_Trabajador_TipoEmpleado]
GO
USE [master]
GO
ALTER DATABASE [PROY_BD_2B] SET  READ_WRITE 
GO


