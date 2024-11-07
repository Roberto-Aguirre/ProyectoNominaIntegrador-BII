CREATE DATABASE PRUEBA3
GO
USE PRUEBA3

GO
CREATE TABLE [dbo].[AreaGeografica](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Clave] [varchar](10) NOT NULL,
	[Descripcion] [varchar](50) NOT NULL,
	[Estatus] [varchar](1) NOT NULL,
 	PRIMARY KEY (Id)
)

GO
CREATE TABLE [dbo].[BaseCotizacion](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](20) NOT NULL,
	[Estatus] [varchar](1) NOT NULL,
 	PRIMARY KEY (Id)
)

GO
CREATE TABLE [dbo].[Categoria](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](60) NOT NULL,
	[EmpresaId] [int] NOT NULL,
	[Estatus] [varchar](1) NOT NULL,
 PRIMARY KEY (Id)
)

GO
CREATE TABLE [dbo].[Departamentos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](100) NOT NULL,
	[EmpresaId] [int] NOT NULL,
	[MontoPropio] [decimal](15, 3) NOT NULL,
	[Estatus] [varchar](1) NOT NULL,
 PRIMARY KEY (Id)
)

GO
CREATE TABLE [dbo].[Empresa](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FechaAlta] [datetime] NOT NULL,
	[RFC] [varchar](15) NOT NULL,
	[Nombre] [varchar](150) NOT NULL,
	[Calle] [varchar](50) NOT NULL,
	[NumeroExt] [varchar](15) NOT NULL,
	[NumeroInt] [varchar](15) NULL,
	[Colonia] [varchar](50) NOT NULL,
	[CP] [varchar](8) NOT NULL,
	[CURP] [varchar](20) NOT NULL,
	[MunicipioId] [int] NOT NULL,
	[EstadoId] [int] NOT NULL,
	[PaisId] [int] NOT NULL,
	[Email] [varchar](60) NOT NULL,
	[TipoComprobante] [varchar](50) NOT NULL,
	[PathLogo] [varchar](100) NULL,
	[PathCertificadoSAT] [varchar](100) NULL,
	[PathLlaveSAT] [varchar](100) NULL,
	[ContraseñaSAT] [varchar](100) NULL,
	[ProveedorSAT] [varchar](100) NULL,
	[PathTimbrado] [varchar](100) NULL,
	[MonedaId] [int] NOT NULL,
	[RegimenFiscalId] [int] NOT NULL,
	[CumpleReqCuotas] [bit] NOT NULL,
	[ClaveIMSS] [varchar](40) NULL,
	[ClaveINFONAVIT] [varchar](40) NULL,
	[ClaveFONACOT] [varchar](40) NULL,
	[LugarExpedicion] [varchar](100) NULL,
	[TipoEmpresaId] [int] NOT NULL,
	[TipoHoraId] [int] NOT NULL,
	[PorcentajePresFed] [decimal](10, 3) NULL,
	[TelefonoWhatsApp] [varchar](15) NOT NULL,
	[TelefonoFijo] [varchar](15) NULL,
	[TipoConstitucionId] [int] NOT NULL,
	[Estatus] [varchar](1) NOT NULL,
 PRIMARY KEY (Id)
)

GO
CREATE TABLE [dbo].[EmpresaRegPat](
	[Id] [int] NOT NULL,
	[EmpresaId] [int] NOT NULL,
	[AreaGeograficaId] [int] NOT NULL,
	[RiesgoPuestoId] [int] NOT NULL,
	[RegistroPatronal] [varchar](20) NOT NULL,
	[LugarExpedicion] [varchar](450) NOT NULL,
	[PathCertificadoSAT] [varchar](100) NULL,
	[PathLlaveSAT] [varchar](100) NULL,
	[PassSAT] [varchar](100) NULL,
	[VigenciaInicial] [datetime] NOT NULL,
	[VigenciaFinal] [datetime] NOT NULL,
	[NumeroSerie] [varchar](30) NOT NULL,
 PRIMARY KEY (Id)
)

GO
CREATE TABLE [dbo].[EstadoCivil](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](50) NOT NULL,
	[Estatus] [varchar](1) NOT NULL,
 PRIMARY KEY (Id)
)

GO
CREATE TABLE [dbo].[MotivoNoTimbrar](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](50) NOT NULL,
	[Estatus] [varchar](1) NOT NULL,
 PRIMARY KEY (Id)
)

GO
CREATE TABLE [dbo].[Puesto](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Categoria] [int] NOT NULL,
	[Descripcion] [varchar](100) NOT NULL,
	[SalarioIni] [decimal](18, 2) NOT NULL,
	[SalarioFin] [decimal](18, 2) NULL,
	[EmpresaId] [int] NOT NULL,
	[Estatus] [varchar](1) NOT NULL,
 PRIMARY KEY (Id)
)

GO
CREATE TABLE [dbo].[SatBancos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ClaveSAT] [varchar](5) NOT NULL,
	[DescripcionSAT] [varchar](40) NOT NULL,
	[RazonSocialSAT] [varchar](120) NOT NULL,
	[FechaInicioVigenciaSAT] [datetime] NOT NULL,
	[FehcaFinVigenciaSAT] [datetime] NOT NULL,
	[ClaveABM] [int] NOT NULL,
	[Estatus] [varchar](1) NOT NULL,
 PRIMARY KEY (Id)
)

GO
CREATE TABLE [dbo].[SatEstados](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PaisId] [int] NOT NULL,
	[ClaveSAT] [varchar](5) NOT NULL,
	[DescripcionSAT] [varchar](50) NOT NULL,
	[FechaInicioVigenciaSAT] [datetime] NOT NULL,
	[FechaFinVigenciaSAT] [datetime] NOT NULL,
	[FolioINEGI] [int] NOT NULL,
	[Estatus] [varchar](1) NOT NULL,
 PRIMARY KEY (Id)
)

GO
CREATE TABLE [dbo].[SatFormaPago](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ClaveSAT] [varchar](5) NOT NULL,
	[DescripcionSAT] [varchar](50) NOT NULL,
	[BancarizadoSAT] [varchar](2) NOT NULL,
	[Tipo] [varchar](5) NOT NULL,
	[FechaInicioVigenciaSAT] [datetime] NOT NULL,
	[FechaFinVigenciaSAT] [datetime] NOT NULL,
	[Estatus] [varchar](1) NOT NULL,
 PRIMARY KEY (Id)
)

GO
CREATE TABLE [dbo].[SatMoneda](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ClaveSAT] [varchar](5) NOT NULL,
	[DescripcionSAT] [varchar](90) NOT NULL,
	[DecimalesSAT] [int] NOT NULL,
	[PorcentajeVariacionSAT] [int] NOT NULL,
	[FechaInicioVariacionSAT] [datetime] NOT NULL,
	[FechaFinVigenciaSAT] [datetime] NOT NULL,
	[Estatus] [varchar](1) NOT NULL,
 PRIMARY KEY (Id)
)

GO
CREATE TABLE [dbo].[SatMunicipios](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[EstadoId] [int] NOT NULL,
	[ClaveSAT] [varchar](5) NOT NULL,
	[DescripcionSAT] [varchar](60) NOT NULL,
	[FechaInicioVigenciaSAT] [datetime] NOT NULL,
	[FechaFinVigenciaSAT] [datetime] NOT NULL,
	[Estatus] [varchar](1) NOT NULL,
 PRIMARY KEY (Id)
)

GO
CREATE TABLE [dbo].[SatOrigenRecurso](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OrigenRecursoSAT] [varchar](5) NOT NULL,
	[DscripcionSAT] [varchar](25) NOT NULL,
	[Estatus] [varchar](1) NOT NULL,
 PRIMARY KEY (Id)
)

GO
CREATE TABLE [dbo].[SatPais](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ClaveSAT] [varchar](5) NOT NULL,
	[DescripcionSAT] [varchar](60) NOT NULL,
	[FmtoCodPostalSAT] [varchar](50) NULL,
	[FmotRegIdenTribSAT] [varchar](100) NULL,
	[ValidaRegIdenTribSAT] [varchar](50) NULL,
	[AgrupacionesSAT] [varchar](50) NULL,
	[Estatus] [varchar](1) NOT NULL,
 PRIMARY KEY (Id)
)

GO
CREATE TABLE [dbo].[SatPeriocidadPago](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ClaveSAT] [varchar](5) NOT NULL,
	[DescripcionSAT] [varchar](30) NOT NULL,
	[FechaInicioVigenciaSAT] [datetime] NOT NULL,
	[FechaFinVigenciaSAT] [datetime] NOT NULL,
	[Dias] [int] NOT NULL,
	[DiasValidos] [varchar](30) NULL,
	[Estatus] [varchar](1) NOT NULL,
 PRIMARY KEY (Id)
)

GO
CREATE TABLE [dbo].[SatRegimenFiscal](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ClaveSAT] [varchar](5) NOT NULL,
	[DescripcionSAT] [varchar](100) NOT NULL,
	[PersonaFisicaSAT] [varchar](2) NOT NULL,
	[PersonaMoralSAT] [varchar](2) NOT NULL,
	[FechaInicioVigenciaSAT] [datetime] NOT NULL,
	[FechaFinVigenciaSAT] [datetime] NOT NULL,
	[Estatus] [varchar](1) NOT NULL,
 PRIMARY KEY (Id)
)

GO
CREATE TABLE [dbo].[SatRiesgoPuesto](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ClaveSAT] [varchar](5) NOT NULL,
	[Descripcion] [varchar](20) NOT NULL,
	[FechaInicioVigencia] [datetime] NOT NULL,
	[FechaFinVigencia] [datetime] NOT NULL,
	[Estatus] [varchar](1) NOT NULL,
 PRIMARY KEY (Id)
)

GO
CREATE TABLE [dbo].[SatTipoContrato](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ClaveSAT] [varchar](10) NOT NULL,
	[Descripcion] [varchar](100) NOT NULL,
	[Estatus] [varchar](1) NOT NULL,
 PRIMARY KEY (Id)
)

GO
CREATE TABLE [dbo].[SatTipoHoras](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ClaveSAT] [varchar](10) NOT NULL,
	[DescripcionSAT] [varchar](250) NOT NULL,
	[Monto] [decimal](15, 2) NOT NULL,
	[Estatus] [varchar](1) NOT NULL,
 PRIMARY KEY (Id)
)

GO
CREATE TABLE [dbo].[SatTipoJornada](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ClaveSAT] [varchar](5) NOT NULL,
	[DescripcionSAT] [varchar](20) NOT NULL,
	[Horas] [decimal](15, 3) NOT NULL,
	[Estatus] [varchar](1) NOT NULL,
 PRIMARY KEY (Id)
)

GO
CREATE TABLE [dbo].[SatTipoRegimen](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ClaveSAT] [varchar](5) NOT NULL,
	[DescripcionSAT] [varchar](60) NOT NULL,
	[FechaInicioVigenciaSAT] [datetime] NOT NULL,
	[FechaFinVigenciaSAT] [datetime] NOT NULL,
	[Estatus] [varchar](1) NOT NULL,
 PRIMARY KEY (Id)
)

GO
CREATE TABLE [dbo].[Sexo](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Descipcion] [varchar](50) NOT NULL,
	[Estatus] [varchar](1) NOT NULL,
 PRIMARY KEY (Id)
)

GO
CREATE TABLE [dbo].[TipoConstitucion](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](30) NOT NULL,
	[Estatus] [varchar](1) NOT NULL,
 PRIMARY KEY (Id)
)

GO
CREATE TABLE [dbo].[TipoEmpleado](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Descipcion] [varchar](50) NOT NULL,
	[EmpresaId] [int] NOT NULL,
	[Estatus] [varchar](1) NOT NULL,
 PRIMARY KEY (Id)
)

GO
CREATE TABLE [dbo].[TipoEmpresa](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](30) NOT NULL,
	[Estatus] [varchar](1) NOT NULL,
 PRIMARY KEY (Id)
)

GO
CREATE TABLE [dbo].[Trabajador](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[EmpresaId] [int] NOT NULL,
	[TipoEmpleadoId] [int] NOT NULL,
	[TipoContratoId] [int] NOT NULL,
	[NumEmpleado] [varchar](15) NOT NULL,
	[Nombre] [varchar](40) NOT NULL,
	[ApellidoPaterno] [varchar](35) NOT NULL,
	[ApellidoMaterno] [varchar](35) NOT NULL,
	[SexoId] [int] NOT NULL,
	[EstadoCivilId] [int] NOT NULL,
	[FechaNac] [datetime] NOT NULL,
	[Calle] [varchar](50) NOT NULL,
	[NumeroExt] [varchar](15) NOT NULL,
	[NumeroInt] [varchar](15) NULL,
	[Colonia] [varchar](50) NOT NULL,
	[CP] [varchar](8) NOT NULL,
	[PaisId] [int] NOT NULL,
	[MunicipioId] [int] NOT NULL,
	[EstadoId] [int] NOT NULL,
	[TelefonoMovil] [varchar](15) NOT NULL,
	[TelefonoFijo] [varchar](15) NULL,
	[RFC] [varchar](15) NOT NULL,
	[CURP] [varchar](20) NOT NULL,
	[NSS] [varchar](30) NOT NULL,
	[FechaIngreso] [datetime] NOT NULL,
	[FechaBaja] [datetime] NULL,
	[PeriocidadPagoId] [int] NOT NULL,
	[FormaPagoId] [int] NOT NULL,
	[CuentaBanco] [int] NOT NULL,
	[CLABE] [varchar](20) NOT NULL,
	[BancoId] [int] NOT NULL,
	[Email] [varchar](60) NOT NULL,
	[Salario] [decimal](18, 3) NOT NULL,
	[SalarioDiario] [decimal](18, 3) NOT NULL,
	[SalarioDiarioInte] [decimal](18, 3) NOT NULL,
	[CumpleReqDisminucion] [bit] NOT NULL,
	[TipoRegimenId] [int] NOT NULL,
	[PuestoId] [int] NOT NULL,
	[Departamento] [int] NOT NULL,
	[BaseCotizacionId] [int] NOT NULL,
	[TipoJornadaId] [int] NOT NULL,
	[OrigenRecursoId] [int] NOT NULL,
	[PorcentajePresFed] [decimal](15, 3) NOT NULL,
	[MontoPropio] [decimal](15, 3) NOT NULL,
	[NominaGen] [bit] NOT NULL,
	[EmpresaRegimenPatId] [int] NOT NULL,
	[EstatusTimbrado] [int] NOT NULL,
	[MotivoNoTimbrarId] [int] NOT NULL,
	[Estatus] [varchar](1) NOT NULL,
 PRIMARY KEY (Id)
)
GO

GO
ALTER TABLE [dbo].[Empresa]  WITH CHECK ADD  CONSTRAINT [FK_Empresa_SatEstados] FOREIGN KEY([EstadoId]) REFERENCES [dbo].[SatEstados] ([Id])
GO
ALTER TABLE [dbo].[Empresa] CHECK CONSTRAINT [FK_Empresa_SatEstados]
GO
ALTER TABLE [dbo].[Empresa]  WITH CHECK ADD  CONSTRAINT [FK_Empresa_SatMoneda] FOREIGN KEY([MonedaId]) REFERENCES [dbo].[SatMoneda] ([Id])
GO
ALTER TABLE [dbo].[Empresa] CHECK CONSTRAINT [FK_Empresa_SatMoneda]
GO
ALTER TABLE [dbo].[Empresa]  WITH CHECK ADD  CONSTRAINT [FK_Empresa_SatMunicipios] FOREIGN KEY([MunicipioId]) REFERENCES [dbo].[SatMunicipios] ([Id])
GO
ALTER TABLE [dbo].[Empresa] CHECK CONSTRAINT [FK_Empresa_SatMunicipios]
GO
ALTER TABLE [dbo].[Empresa]  WITH CHECK ADD  CONSTRAINT [FK_Empresa_SatPais] FOREIGN KEY([PaisId]) REFERENCES [dbo].[SatPais] ([Id])
GO
ALTER TABLE [dbo].[Empresa] CHECK CONSTRAINT [FK_Empresa_SatPais]
GO
ALTER TABLE [dbo].[Empresa]  WITH CHECK ADD  CONSTRAINT [FK_Empresa_SatRegimenFiscal] FOREIGN KEY([RegimenFiscalId]) REFERENCES [dbo].[SatRegimenFiscal] ([Id])
GO
ALTER TABLE [dbo].[Empresa] CHECK CONSTRAINT [FK_Empresa_SatRegimenFiscal]
GO
ALTER TABLE [dbo].[Empresa]  WITH CHECK ADD  CONSTRAINT [FK_Empresa_SatTipoHoras1] FOREIGN KEY([TipoHoraId]) REFERENCES [dbo].[SatTipoHoras] ([Id])
GO
ALTER TABLE [dbo].[Empresa] CHECK CONSTRAINT [FK_Empresa_SatTipoHoras1]
GO
ALTER TABLE [dbo].[Empresa]  WITH CHECK ADD  CONSTRAINT [FK_Empresa_TipoConstitucion] FOREIGN KEY([TipoConstitucionId]) REFERENCES [dbo].[TipoConstitucion] ([Id])
GO
ALTER TABLE [dbo].[Empresa] CHECK CONSTRAINT [FK_Empresa_TipoConstitucion]
GO
ALTER TABLE [dbo].[Empresa]  WITH CHECK ADD  CONSTRAINT [FK_Empresa_tipoEmpresa] FOREIGN KEY([TipoEmpresaId]) REFERENCES [dbo].[tipoEmpresa] ([Id])
GO
ALTER TABLE [dbo].[Empresa] CHECK CONSTRAINT [FK_Empresa_tipoEmpresa]
GO
ALTER TABLE [dbo].[EmpresaRegPat]  WITH CHECK ADD  CONSTRAINT [FK_EmpresaRegPat_AreaGeografica] FOREIGN KEY([AreaGeograficaId]) REFERENCES [dbo].[AreaGeografica] ([Id])
GO
ALTER TABLE [dbo].[EmpresaRegPat] CHECK CONSTRAINT [FK_EmpresaRegPat_AreaGeografica]
GO
ALTER TABLE [dbo].[EmpresaRegPat]  WITH CHECK ADD  CONSTRAINT [FK_EmpresaRegPat_Empresa] FOREIGN KEY([EmpresaId]) REFERENCES [dbo].[Empresa] ([Id])
GO
ALTER TABLE [dbo].[EmpresaRegPat] CHECK CONSTRAINT [FK_EmpresaRegPat_Empresa]
GO
ALTER TABLE [dbo].[EmpresaRegPat]  WITH CHECK ADD  CONSTRAINT [FK_EmpresaRegPat_SatRiesgoPuesto] FOREIGN KEY([RiesgoPuestoId]) REFERENCES [dbo].[SatRiesgoPuesto] ([Id])
GO
ALTER TABLE [dbo].[EmpresaRegPat] CHECK CONSTRAINT [FK_EmpresaRegPat_SatRiesgoPuesto]
GO
ALTER TABLE [dbo].[Puesto]  WITH CHECK ADD  CONSTRAINT [FK_Puesto_Categoria] FOREIGN KEY([Categoria]) REFERENCES [dbo].[Categoria] ([Id])
GO
ALTER TABLE [dbo].[Puesto] CHECK CONSTRAINT [FK_Puesto_Categoria]
GO
ALTER TABLE [dbo].[Puesto]  WITH CHECK ADD  CONSTRAINT [FK_Puesto_Empresa] FOREIGN KEY([EmpresaId]) REFERENCES [dbo].[Empresa] ([Id])
GO
ALTER TABLE [dbo].[Puesto] CHECK CONSTRAINT [FK_Puesto_Empresa]
GO
ALTER TABLE [dbo].[TipoEmpleado]  WITH CHECK ADD  CONSTRAINT [FK_TipoEmpleado_Empresa] FOREIGN KEY([EmpresaId]) REFERENCES [dbo].[Empresa] ([Id])
GO
ALTER TABLE [dbo].[TipoEmpleado] CHECK CONSTRAINT [FK_TipoEmpleado_Empresa]
GO
ALTER TABLE [dbo].[Trabajador]  WITH CHECK ADD  CONSTRAINT [FK_Trabajador_BaseCotizacion] FOREIGN KEY([BaseCotizacionId]) REFERENCES [dbo].[BaseCotizacion] ([Id])
GO
ALTER TABLE [dbo].[Trabajador] CHECK CONSTRAINT [FK_Trabajador_BaseCotizacion]
GO
ALTER TABLE [dbo].[Trabajador]  WITH CHECK ADD  CONSTRAINT [FK_Trabajador_Departamentos] FOREIGN KEY([Departamento]) REFERENCES [dbo].[Departamentos] ([Id])
GO
ALTER TABLE [dbo].[Trabajador] CHECK CONSTRAINT [FK_Trabajador_Departamentos]
GO
ALTER TABLE [dbo].[Trabajador]  WITH CHECK ADD  CONSTRAINT [FK_Trabajador_Empresa] FOREIGN KEY([EmpresaId]) REFERENCES [dbo].[Empresa] ([Id])
GO
ALTER TABLE [dbo].[Trabajador] CHECK CONSTRAINT [FK_Trabajador_Empresa]
GO
ALTER TABLE [dbo].[Trabajador]  WITH CHECK ADD  CONSTRAINT [FK_Trabajador_EmpresaRegPat] FOREIGN KEY([EmpresaRegimenPatId]) REFERENCES [dbo].[EmpresaRegPat] ([Id])
GO
ALTER TABLE [dbo].[Trabajador] CHECK CONSTRAINT [FK_Trabajador_EmpresaRegPat]
GO
ALTER TABLE [dbo].[Trabajador]  WITH CHECK ADD  CONSTRAINT [FK_Trabajador_EstadoCivil] FOREIGN KEY([EstadoCivilId]) REFERENCES [dbo].[EstadoCivil] ([Id])
GO
ALTER TABLE [dbo].[Trabajador] CHECK CONSTRAINT [FK_Trabajador_EstadoCivil]
GO
ALTER TABLE [dbo].[Trabajador]  WITH CHECK ADD  CONSTRAINT [FK_Trabajador_MotivoNoTimbrar] FOREIGN KEY([MotivoNoTimbrarId]) REFERENCES [dbo].[MotivoNoTimbrar] ([Id])
GO
ALTER TABLE [dbo].[Trabajador] CHECK CONSTRAINT [FK_Trabajador_MotivoNoTimbrar]
GO
ALTER TABLE [dbo].[Trabajador]  WITH CHECK ADD  CONSTRAINT [FK_Trabajador_Puesto] FOREIGN KEY([PuestoId]) REFERENCES [dbo].[Puesto] ([Id])
GO
ALTER TABLE [dbo].[Trabajador] CHECK CONSTRAINT [FK_Trabajador_Puesto]
GO
ALTER TABLE [dbo].[Trabajador]  WITH CHECK ADD  CONSTRAINT [FK_Trabajador_SatBancos] FOREIGN KEY([BancoId]) REFERENCES [dbo].[SatBancos] ([Id])
GO
ALTER TABLE [dbo].[Trabajador] CHECK CONSTRAINT [FK_Trabajador_SatBancos]
GO
ALTER TABLE [dbo].[Trabajador]  WITH CHECK ADD  CONSTRAINT [FK_Trabajador_SatEstados] FOREIGN KEY([EstadoId]) REFERENCES [dbo].[SatEstados] ([Id])
GO
ALTER TABLE [dbo].[Trabajador] CHECK CONSTRAINT [FK_Trabajador_SatEstados]
GO
ALTER TABLE [dbo].[Trabajador]  WITH CHECK ADD  CONSTRAINT [FK_Trabajador_SatFormaPago] FOREIGN KEY([FormaPagoId]) REFERENCES [dbo].[SatFormaPago] ([Id])
GO
ALTER TABLE [dbo].[Trabajador] CHECK CONSTRAINT [FK_Trabajador_SatFormaPago]
GO
ALTER TABLE [dbo].[Trabajador]  WITH CHECK ADD  CONSTRAINT [FK_Trabajador_SatMunicipios] FOREIGN KEY([MunicipioId]) REFERENCES [dbo].[SatMunicipios] ([Id])
GO
ALTER TABLE [dbo].[Trabajador] CHECK CONSTRAINT [FK_Trabajador_SatMunicipios]
GO
ALTER TABLE [dbo].[Trabajador]  WITH CHECK ADD  CONSTRAINT [FK_Trabajador_SatOrigenRecurso] FOREIGN KEY([OrigenRecursoId]) REFERENCES [dbo].[SatOrigenRecurso] ([Id])
GO
ALTER TABLE [dbo].[Trabajador] CHECK CONSTRAINT [FK_Trabajador_SatOrigenRecurso]
GO
ALTER TABLE [dbo].[Trabajador]  WITH CHECK ADD  CONSTRAINT [FK_Trabajador_SatPais] FOREIGN KEY([PaisId]) REFERENCES [dbo].[SatPais] ([Id])
GO
ALTER TABLE [dbo].[Trabajador] CHECK CONSTRAINT [FK_Trabajador_SatPais]
GO
ALTER TABLE [dbo].[Trabajador]  WITH CHECK ADD  CONSTRAINT [FK_Trabajador_SatPeriocidadPago] FOREIGN KEY([PeriocidadPagoId]) REFERENCES [dbo].[SatPeriocidadPago] ([Id])
GO
ALTER TABLE [dbo].[Trabajador] CHECK CONSTRAINT [FK_Trabajador_SatPeriocidadPago]
GO
ALTER TABLE [dbo].[Trabajador]  WITH CHECK ADD  CONSTRAINT [FK_Trabajador_SatTipoContrato] FOREIGN KEY([TipoContratoId]) REFERENCES [dbo].[SatTipoContrato] ([Id])
GO
ALTER TABLE [dbo].[Trabajador] CHECK CONSTRAINT [FK_Trabajador_SatTipoContrato]
GO
ALTER TABLE [dbo].[Trabajador]  WITH CHECK ADD  CONSTRAINT [FK_Trabajador_SatTipoJornada] FOREIGN KEY([TipoJornadaId]) REFERENCES [dbo].[SatTipoJornada] ([Id])
GO
ALTER TABLE [dbo].[Trabajador] CHECK CONSTRAINT [FK_Trabajador_SatTipoJornada]
GO
ALTER TABLE [dbo].[Trabajador]  WITH CHECK ADD  CONSTRAINT [FK_Trabajador_SatTipoRegimen] FOREIGN KEY([TipoRegimenId]) REFERENCES [dbo].[SatTipoRegimen] ([Id])
GO
ALTER TABLE [dbo].[Trabajador] CHECK CONSTRAINT [FK_Trabajador_SatTipoRegimen]
GO
ALTER TABLE [dbo].[Trabajador]  WITH CHECK ADD  CONSTRAINT [FK_Trabajador_Sexo] FOREIGN KEY([SexoId]) REFERENCES [dbo].[Sexo] ([Id])
GO
ALTER TABLE [dbo].[Trabajador] CHECK CONSTRAINT [FK_Trabajador_Sexo]
GO
ALTER TABLE [dbo].[Trabajador]  WITH CHECK ADD  CONSTRAINT [FK_Trabajador_TipoEmpleado] FOREIGN KEY([TipoEmpleadoId]) REFERENCES [dbo].[TipoEmpleado] ([Id])
GO
ALTER TABLE [dbo].[Trabajador] CHECK CONSTRAINT [FK_Trabajador_TipoEmpleado]
GO
