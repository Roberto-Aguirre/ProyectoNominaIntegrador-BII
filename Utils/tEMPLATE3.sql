

CREATE TABLE [dbo].[NominaDetalle](                                     
[Id] [int] IDENTITY(1,1) NOT NULL,
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
 PRIMARY KEY (Id)
)


ALTER TABLE [dbo].[NominaDetalle]  WITH CHECK ADD  CONSTRAINT [FK_NominaDetalle_Empresa] FOREIGN KEY([EmpresaId]) REFERENCES [dbo].[Empresa] ([Id])
GO
ALTER TABLE [dbo].[NominaDetalle]  WITH CHECK ADD  CONSTRAINT [FK_NominaDetalle_Periodos] FOREIGN KEY([PeriodoId]) REFERENCES [dbo].[Periodo] ([Id])
GO
ALTER TABLE [dbo].[NominaDetalle]  WITH CHECK ADD  CONSTRAINT [FK_NominaDetalle_Trabajadores] FOREIGN KEY([TrabajadorId]) REFERENCES [dbo].[Trabajador] ([Id])

ALTER TABLE [dbo].[NominaDetalle]  WITH CHECK ADD  CONSTRAINT [FK_NominaDetalle_Incidencia] FOREIGN KEY([Incidencias]) REFERENCES [dbo].[Incidencias] ([Id])

CREATE TABLE Incidencias(
[Id] [int] IDENTITY(1,1) NOT NULL,
[TipoPercepcion] [int] NOT NULL,
[TipoDeduccion] [int] NOT NULL,
[TipoNominaId] [int] NOT NULL,
[AplicacionId] [int] NOT NULL,
[TipoAplicacionNominaId] [int] NOT NULL,
[Operacion] [int] NULL,
[Descripcion] [varchar] (350) NOT NULL,
[Obligatorio] [bit] NOT NULL,
[Especie] [int] NOT NULL,
[EmpresaId] [int] NULL,
[Porcentaje] [decimal] (15, 3) NOT NULL,
[Monto] [decimal] (15, 3) NOT NULL,
[TipoPrevSoc] [bit] NOT NULL,
[Estatus] [varchar] (1) NOT NULL
PRIMARY KEY (Id)
)

ALTER TABLE [dbo].[Incidencias]  WITH CHECK ADD  CONSTRAINT [FK_Incidencia_TipoNomina] FOREIGN KEY([TipoNominaId]) REFERENCES [dbo].[TipoNomina] ([Id])

ALTER TABLE [dbo].[Incidencias]  WITH CHECK ADD  CONSTRAINT [FK_Incidencia_Aplicacion] FOREIGN KEY([AplicacionId]) REFERENCES [dbo].[TipoNomina] ([Id])

ALTER TABLE [dbo].[Incidencias]  WITH CHECK ADD  CONSTRAINT [FK_Incidencia_TipoAplicacionNomina] FOREIGN KEY([TipoAplicacionNominaId]) REFERENCES [dbo].[TipoNominaSAT] ([Id])


CREATE TABLE [dbo].[TipoNomina](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](100) NOT NULL,
 PRIMARY KEY (Id)
)

CREATE TABLE [dbo].[AplicacionNomina](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](100) NOT NULL,
 PRIMARY KEY (Id)
)

CREATE TABLE [dbo].[TipoNominaSAT](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](100) NOT NULL,
 PRIMARY KEY (Id)
)

