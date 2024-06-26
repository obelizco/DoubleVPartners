
CREATE TABLE [dbo].[Persona](
	[IdPersona] [uniqueidentifier] PRIMARY KEY,
	[Nombres] [nvarchar](100) NOT NULL,
	[Apellidos] [nvarchar](100) NOT NULL,
	[NumeroIdentificacion] [bigint] NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[TipoIdentificacion] [nvarchar](50) NOT NULL,
	[CreadoPor] [uniqueidentifier] NOT NULL,
	[FechaCreacion] [datetime] NOT NULL,
	[ModificadoPor] [uniqueidentifier] NULL,
	[FechaModificacion] [datetime] NULL
);
GO

CREATE TABLE [dbo].[Usuario](
	[IdUsuario] [uniqueidentifier] PRIMARY KEY,
	[Usuario] [nvarchar](50) NOT NULL,
	[Pass] [nvarchar](max) NOT NULL,
	[CreadoPor] [uniqueidentifier] NOT NULL,
	[FechaCreacion] [datetime] NOT NULL,
	[ModificadoPor] [uniqueidentifier] NULL,
	[FechaModificacion] [datetime] NULL
);

GO

CREATE procedure [dbo].[ConsultaPersonas]
as
SELECT [IdPersona]
      ,[Nombres]
      ,[Apellidos]
      ,[NumeroIdentificacion]
      ,[Email]
      ,[TipoIdentificacion]
	  ,[CreadoPor]
	  ,[FechaCreacion]
	  ,[ModificadoPor]
	  ,[FechaModificacion]
      
  FROM [dbo].[Persona];
GO
