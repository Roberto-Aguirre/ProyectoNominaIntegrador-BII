
CREATE TABLE Nomina(			
[Id] [int] NOT NULL,
[EmpresaId] [int] NOT NULL,
[Ejercicio] [int] NOT NULL,
[FechaInicial]	 [datetime] NULL,
[FechaFinal] [datetime] NULL,
[FechaPago] [datetime] NULL,
[SatPeriocidadPagoId] [int] NOT NULL,
[PeriodoId] [int] NOT NULL,
[TipoNominaSATId] [int] NOT NULL,
[NominaExtraordinariaId] [int] NOT NULL,
[ConceptoNomina] [varchar] (250) NULL,
[ConceptoTimbrado] [varchar] (250) NULL,
[TotalTrabajadores] [int] NOT NULL,
[TotalPercepciones]	[decimal] (18, 4) NULL,
[TotalDeducciones] [decimal] (18, 4) NOT NULL,
[Extraordinaria] [bit] 	NOT NULL,
[Generada] [bit] NOT NULL,
[Autorizada] [bit] NOT NULL,
[Timbrada] [bit] NOT NULL,
[Cerrada] [bit] NOT NULL,
[Estatus] [varchar] (1) NOT NULL
)

CREATE TABLE NominaDetalle(                                     
[Id] [int] NOT NULL,
[EmpresaId] [int] NOT NULL,
[PeriodoId] [int] NOT NULL,
[TrabajadorId] [int] NOT NULL,
[IncidenciaId] [int] NOT NULL,
[TipoIncapacidadId] [int] NOT NULL,
[DiasPagados] [decimal] (10, 3) NOT NULL,
[HorasExtra] [decimal] (10, 3) NOT NULL,
[Importe] [decimal] (18, 3) NOT NULL,
[Gravado] [decimal] (18, 3) NOT NULL,
[Exento] [decimal] (18, 3) NOT NULL,
[ISRaPagar] [decimal] (18, 3) NOT NULL,
[BaseImpuesto] [decimal] (18, 3) NOT NULL,
[TipoCaptura] [int] NOT NULL,
[Comentarios] [varchar] (350) NULL,
[Estatus] [varchar] (1) NULL
)



CREATE TABLE InicioNomina(
[Id] [int] NOT NULL,
[Ejercicio] [int] NOT NULL,
[EmpresaId] [int] NOT NULL,
[EmpresaRegPatId] [int] NOT NULL,
[SatPeriocidadPagoId] [int] NOT NULL,
[PeriodoId] [int] NOT NULL,
[FechaInicial] [datetime] NULL,
[FechaFinal] [datetime] NULL,
[FechaRegistro] [datetime] NULL,
[FechaCierre] [datetime] NULL,
[EstatusEjercicio] [varchar] (1) NULL,
[PeriodoActualId] [int] 	NOT NULL,
[Comentarios] [varchar] (250) NULL,
[Estatus] [varchar] (1) NOT NULL
)

ALTER TABLE [dbo].[InicioNomina]  WITH CHECK ADD  CONSTRAINT [FK_InicioNomina_Periodo] FOREIGN KEY([PeriodoId]) REFERENCES [dbo].[Periodo] ([Id])

-- ALTER TABLE [dbo].[InicioNomina]  WITH CHECK ADD  CONSTRAINT [FK_InicioNomina_PeriodoActual] FOREIGN KEY([PeriodoActualId]) REFERENCES [dbo].[PeriodoActual] ([Id])

CREATE TABLE Periodo(
[Id] [int] NOT NULL,
[SatPeriocidadPagoId] [int] NULL,
[Periodo] [int] NULL,
[Descripcion] [varchar] (150) NOT NULL,
[EmpresaId] [int] NULL,
[Estatus] [varchar] (1) NOT NULL
)

ALTER TABLE [dbo].[Nomina]  WITH CHECK ADD  CONSTRAINT [FK_Nomina_Empresa] FOREIGN KEY([EmpresaId]) REFERENCES [dbo].[Empresa] ([Id])
ALTER TABLE [dbo].[Nomina]  WITH CHECK ADD  CONSTRAINT [FK_Nomina_SatPeriocidadPago] FOREIGN KEY([SatPeriocidadPagoId]) REFERENCES [dbo].[SatPeriocidadPago] ([Id])
ALTER TABLE [dbo].[Nomina]  WITH CHECK ADD  CONSTRAINT [FK_Nomina_Periodo] FOREIGN KEY([PeriodoId]) REFERENCES [dbo].[Periodo] ([Id])
ALTER TABLE [dbo].[Nomina]  WITH CHECK ADD  CONSTRAINT [FK_Nomina_TipoNominaSAT] FOREIGN KEY([TipoNominaSATId]) REFERENCES [dbo].[TipoNominaSAT] ([Id])


ALTER TABLE [dbo].[Periodo]  WITH CHECK ADD  CONSTRAINT [FK_Periodo_SatPeriocidadPago] FOREIGN KEY([SatPeriocidadPagoId]) REFERENCES [dbo].[SatPeriocidadPago] ([Id])
ALTER TABLE [dbo].[Periodo]  WITH CHECK ADD  CONSTRAINT [FK_Periodo_Empresa] FOREIGN KEY([EmpresaId]) REFERENCES [dbo].[Empresa] ([Id])

ALTER TABLE [dbo].[NominaDetalle]  WITH CHECK ADD  CONSTRAINT [FK_NominaDetalle_Empresa] FOREIGN KEY([EmpresaId]) REFERENCES [dbo].[Empresa] ([Id])

ALTER TABLE [dbo].[NominaDetalle]  WITH CHECK ADD  CONSTRAINT [FK_NominaDetalle_Periodo] FOREIGN KEY([PeriodoId]) REFERENCES [dbo].[Periodo] ([Id])

ALTER TABLE [dbo].[NominaDetalle]  WITH CHECK ADD  CONSTRAINT [FK_NominaDetalle_Trabajador] FOREIGN KEY([TrabajadorId]) REFERENCES [dbo].[Trabajador] ([Id])

ALTER TABLE [dbo].[NominaDetalle]  WITH CHECK ADD  CONSTRAINT [FK_NominaDetalle_Incidencia] FOREIGN KEY([IncidenciaId]) REFERENCES [dbo].[Incidencias] ([Id])

ALTER TABLE [dbo].[NominaDetalle]  WITH CHECK ADD  CONSTRAINT [FK_NominaDetalle_TipoIncapacidad] FOREIGN KEY([TipoIncapacidadId]) REFERENCES [dbo].[TipoIncapacidad] ([Id])

ALTER TABLE [dbo].[InicioNomina]  WITH CHECK ADD  CONSTRAINT [FK_InicioNomina_Empresa] FOREIGN KEY([EmpresaId]) REFERENCES [dbo].[Empresa] ([Id])

ALTER TABLE [dbo].[InicioNomina]  WITH CHECK ADD  CONSTRAINT [FK_InicioNomina_EmpresaRegPat] FOREIGN KEY([EmpresaRegPatId]) REFERENCES [dbo].[EmpresaRegPat] ([Id])

ALTER TABLE [dbo].[InicioNomina]  WITH CHECK ADD  CONSTRAINT [FK_InicioNomina_SatPeriocidadPago] FOREIGN KEY([SatPeriocidadPagoId]) REFERENCES [dbo].[SatPeriocidadPago] ([Id])

-- CREATE TABLE Incidencias(
-- [Id] [int] NOT NULL,
-- [TipoPercepcion] [int] NOT NULL,
-- [TipoDeduccion] [int] NOT NULL,
-- [TipoNomina] [int] NOT NULL,
-- [Aplicacion] [int] NOT NULL,
-- [TipoAplicacionNomina] [int] NOT NULL,
-- [Operacion] [int] NULL,
-- [Descripcion] [varchar] (350) NOT NULL,
-- [Obligatorio] [bit] NOT NULL,
-- [Especie] [int] NOT NULL,
-- [Empresa] [int] NULL,
-- [Porcentaje] [decimal] (15, 3) NOT NULL,
-- [Monto] [decimal] (15, 3) NOT NULL,
-- [TipoPrevSoc] [bit] NOT NULL,
-- [Estatus] [varchar] (1) NOT NULL,)