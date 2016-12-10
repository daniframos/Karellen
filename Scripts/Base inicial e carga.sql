GO
/****** Object:  Database [KARELLEN]    Script Date: 10/12/2016 17:59:23 ******/
CREATE DATABASE KARELLEN;
GO
USE KARELLEN;
CREATE TABLE [dbo].[TBGrupo](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_dbo.TBGrupo] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TBLog]    Script Date: 10/12/2016 17:59:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TBLog](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Ip] [nvarchar](max) NULL,
	[Local] [nvarchar](max) NULL,
	[UserAgent] [nvarchar](max) NULL,
	[Browser] [nvarchar](max) NULL,
	[Data] [datetime] NOT NULL,
	[SessaoId] [uniqueidentifier] NOT NULL,
	[EntidadeNome] [nvarchar](max) NULL,
	[EntidadeId] [nvarchar](max) NULL,
	[Acao] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.TBLog] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TBLoginExterno]    Script Date: 10/12/2016 17:59:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TBLoginExterno](
	[LoginProvedor] [nvarchar](128) NOT NULL,
	[KeyProvedor] [nvarchar](128) NOT NULL,
	[UsuarioId] [int] NOT NULL,
 CONSTRAINT [PK_dbo.TBLoginExterno] PRIMARY KEY CLUSTERED 
(
	[LoginProvedor] ASC,
	[KeyProvedor] ASC,
	[UsuarioId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TBOcorrencia]    Script Date: 10/12/2016 17:59:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TBOcorrencia](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Titulo] [nvarchar](max) NOT NULL,
	[DataAcontecimento] [datetime] NOT NULL,
	[DataCriacao] [datetime] NOT NULL,
	[DataResolucao] [datetime] NULL,
	[Resolucao] [nvarchar](max) NULL,
	[Excluida] [bit] NOT NULL,
	[SexoVitima] [int] NOT NULL,
	[Detalhes] [nvarchar](max) NULL,
	[HaBoletimDeOcorrencia] [bit] NULL,
	[Latitude] [nvarchar](max) NOT NULL,
	[Longitude] [nvarchar](max) NOT NULL,
	[UsuarioId] [int] NULL,
 CONSTRAINT [PK_dbo.TBOcorrencia] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TBTipoOcorrencia]    Script Date: 10/12/2016 17:59:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TBTipoOcorrencia](
	[OcorrenciaId] [int] NOT NULL,
	[Tipo] [int] NOT NULL,
 CONSTRAINT [PK_dbo.TBTipoOcorrencia] PRIMARY KEY CLUSTERED 
(
	[OcorrenciaId] ASC,
	[Tipo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TBUsuario]    Script Date: 10/12/2016 17:59:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TBUsuario](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [nvarchar](50) NOT NULL,
	[Sobrenome] [nvarchar](100) NULL,
	[Username] [nvarchar](max) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[Senha] [nvarchar](max) NULL,
	[Cidade] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.TBUsuario] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TBUsuarioGrupo]    Script Date: 10/12/2016 17:59:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TBUsuarioGrupo](
	[GrupoId] [int] NOT NULL,
	[UsuarioId] [int] NOT NULL,
 CONSTRAINT [PK_dbo.TBUsuarioGrupo] PRIMARY KEY CLUSTERED 
(
	[GrupoId] ASC,
	[UsuarioId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Index [IX_UsuarioId]    Script Date: 10/12/2016 17:59:24 ******/
CREATE NONCLUSTERED INDEX [IX_UsuarioId] ON [dbo].[TBLoginExterno]
(
	[UsuarioId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_UsuarioId]    Script Date: 10/12/2016 17:59:24 ******/
CREATE NONCLUSTERED INDEX [IX_UsuarioId] ON [dbo].[TBOcorrencia]
(
	[UsuarioId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_OcorrenciaId]    Script Date: 10/12/2016 17:59:24 ******/
CREATE NONCLUSTERED INDEX [IX_OcorrenciaId] ON [dbo].[TBTipoOcorrencia]
(
	[OcorrenciaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_GrupoId]    Script Date: 10/12/2016 17:59:24 ******/
CREATE NONCLUSTERED INDEX [IX_GrupoId] ON [dbo].[TBUsuarioGrupo]
(
	[GrupoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_UsuarioId]    Script Date: 10/12/2016 17:59:24 ******/
CREATE NONCLUSTERED INDEX [IX_UsuarioId] ON [dbo].[TBUsuarioGrupo]
(
	[UsuarioId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[TBLoginExterno]  WITH CHECK ADD  CONSTRAINT [FK_dbo.TBLoginExterno_dbo.TBUsuario_UsuarioId] FOREIGN KEY([UsuarioId])
REFERENCES [dbo].[TBUsuario] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TBLoginExterno] CHECK CONSTRAINT [FK_dbo.TBLoginExterno_dbo.TBUsuario_UsuarioId]
GO
ALTER TABLE [dbo].[TBOcorrencia]  WITH CHECK ADD  CONSTRAINT [FK_dbo.TBOcorrencia_dbo.TBUsuario_UsuarioId] FOREIGN KEY([UsuarioId])
REFERENCES [dbo].[TBUsuario] ([Id])
GO
ALTER TABLE [dbo].[TBOcorrencia] CHECK CONSTRAINT [FK_dbo.TBOcorrencia_dbo.TBUsuario_UsuarioId]
GO
ALTER TABLE [dbo].[TBTipoOcorrencia]  WITH CHECK ADD  CONSTRAINT [FK_dbo.TBTipoOcorrencia_dbo.TBOcorrencia_OcorrenciaId] FOREIGN KEY([OcorrenciaId])
REFERENCES [dbo].[TBOcorrencia] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TBTipoOcorrencia] CHECK CONSTRAINT [FK_dbo.TBTipoOcorrencia_dbo.TBOcorrencia_OcorrenciaId]
GO
ALTER TABLE [dbo].[TBUsuarioGrupo]  WITH CHECK ADD  CONSTRAINT [FK_dbo.TBUsuarioGrupo_dbo.TBGrupo_GrupoId] FOREIGN KEY([GrupoId])
REFERENCES [dbo].[TBGrupo] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TBUsuarioGrupo] CHECK CONSTRAINT [FK_dbo.TBUsuarioGrupo_dbo.TBGrupo_GrupoId]
GO
ALTER TABLE [dbo].[TBUsuarioGrupo]  WITH CHECK ADD  CONSTRAINT [FK_dbo.TBUsuarioGrupo_dbo.TBUsuario_UsuarioId] FOREIGN KEY([UsuarioId])
REFERENCES [dbo].[TBUsuario] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TBUsuarioGrupo] CHECK CONSTRAINT [FK_dbo.TBUsuarioGrupo_dbo.TBUsuario_UsuarioId]