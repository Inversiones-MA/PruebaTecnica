SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[FormatInt] 
(
	@Number int
)
RETURNS varchar(13)
AS
BEGIN
	DECLARE @Result VarChar(13)

	WHILE (@Number >= 1000)
	BEGIN
		IF (@Result IS NULL) SET @Result = RIGHT(CONVERT(VARCHAR, @Number), 3)
		ELSE SET @Result = RIGHT(CONVERT(VARCHAR, @Number), 3) + '.' + @Result
		
		SET @Number = @Number / 1000
	END

	IF (@Result IS NULL) SET @Result = CONVERT(VARCHAR, @Number)
	ELSE SET @Result = CONVERT(VARCHAR, @Number) + '.' + @Result

	RETURN @Result
END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE FUNCTION [dbo].[GetRunDigito]
(
	@RunCuerpo int
)
RETURNS char(1)
AS
BEGIN
	Declare @Cuerpo int
	Declare @Contador int
	Declare @Multiplo int

	SET @Cuerpo = @RunCuerpo
	SET @Contador = 0
	SET @Multiplo = 2

	While (@Cuerpo <> 0)
	Begin
		SET @Contador = @Contador + ((@Cuerpo % 10) * @Multiplo)
		SET @Cuerpo = @Cuerpo / 10
		SET @Multiplo = @Multiplo + 1

		IF (@Multiplo = 8) SET @Multiplo = 2
	End
	
	SET @Contador = 11 - (@Contador % 11)

	IF (@Contador = 10) Return 'K'
	IF (@Contador = 11) Return '0'
	Return Convert(Char, @Contador)
END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ciudad](
	[RegionCodigo] [smallint] NOT NULL,
	[Codigo] [smallint] NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Ciudad] PRIMARY KEY CLUSTERED 
(
	[RegionCodigo] ASC,
	[Codigo] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Comuna](
	[RegionCodigo] [smallint] NOT NULL,
	[CiudadCodigo] [smallint] NOT NULL,
	[Codigo] [smallint] NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[CodigoPostal] [int] NOT NULL,
	[CodigoLibroClaseElectronico] [int] NOT NULL,
 CONSTRAINT [PK_Comuna] PRIMARY KEY CLUSTERED 
(
	[RegionCodigo] ASC,
	[CiudadCodigo] ASC,
	[Codigo] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Persona](
	[Id] [uniqueidentifier] NOT NULL,
	[Run]  AS (CONVERT([varchar],([dbo].[FormatInt]([RunCuerpo])+'-')+[RunDigito],(0))),
	[RunCuerpo] [int] NOT NULL,
	[RunDigito] [char](1) NOT NULL,
	[Nombre]  AS (CONVERT([varchar](95),(((rtrim(ltrim([ApellidoPaterno]))+' ')+isnull(rtrim(ltrim([ApellidoMaterno])),''))+', ')+rtrim(ltrim([Nombres])),(0))),
	[Nombres] [varchar](45) NOT NULL,
	[ApellidoPaterno] [varchar](25) NOT NULL,
	[ApellidoMaterno] [varchar](25) NULL,
	[Email] [varchar](256) NULL,
	[SexoCodigo] [smallint] NOT NULL,
	[FechaNacimiento] [date] NULL,
	[RegionCodigo] [smallint] NULL,
	[CiudadCodigo] [smallint] NULL,
	[ComunaCodigo] [smallint] NULL,
	[Direccion] [text] NULL,
	[Telefono] [int] NULL,
	[Observaciones] [text] NULL,
 CONSTRAINT [PK_Persona] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Region](
	[Codigo] [smallint] NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[NombreOficial] [varchar](40) NOT NULL,
	[CodigoLibroClaseElectronico] [int] NOT NULL,
 CONSTRAINT [PK_Region] PRIMARY KEY CLUSTERED 
(
	[Codigo] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sexo](
	[Codigo] [smallint] NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Letra] [char](1) NOT NULL,
 CONSTRAINT [PK_Sexo] PRIMARY KEY CLUSTERED 
(
	[Codigo] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Persona] ADD  CONSTRAINT [DF_Persona_Id]  DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [dbo].[Ciudad]  WITH CHECK ADD  CONSTRAINT [FK_Ciudad_Region] FOREIGN KEY([RegionCodigo])
REFERENCES [dbo].[Region] ([Codigo])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Ciudad] CHECK CONSTRAINT [FK_Ciudad_Region]
GO
ALTER TABLE [dbo].[Comuna]  WITH CHECK ADD  CONSTRAINT [FK_Comuna_Ciudad] FOREIGN KEY([RegionCodigo], [CiudadCodigo])
REFERENCES [dbo].[Ciudad] ([RegionCodigo], [Codigo])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Comuna] CHECK CONSTRAINT [FK_Comuna_Ciudad]
GO
ALTER TABLE [dbo].[Persona]  WITH CHECK ADD  CONSTRAINT [FK_Persona_Comuna] FOREIGN KEY([RegionCodigo], [CiudadCodigo], [ComunaCodigo])
REFERENCES [dbo].[Comuna] ([RegionCodigo], [CiudadCodigo], [Codigo])
GO
ALTER TABLE [dbo].[Persona] CHECK CONSTRAINT [FK_Persona_Comuna]
GO
ALTER TABLE [dbo].[Persona]  WITH CHECK ADD  CONSTRAINT [FK_Persona_Sexo] FOREIGN KEY([SexoCodigo])
REFERENCES [dbo].[Sexo] ([Codigo])
GO
ALTER TABLE [dbo].[Persona] CHECK CONSTRAINT [FK_Persona_Sexo]
GO