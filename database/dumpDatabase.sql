USE [AvaliacaoIELDb]
GO
/****** Object:  Table [dbo].[Departamento]    Script Date: 10/04/2022 19:15:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Departamento](
	[Codigo] [int] NOT NULL,
	[NomeDepartamento] [varchar](50) NOT NULL,
	[NomeResponsavel] [varchar](80) NOT NULL,
	[LoginResponsavel] [varchar](30) NOT NULL,
	[EmailResponsavel] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Departamento] PRIMARY KEY CLUSTERED 
(
	[Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Funcionario]    Script Date: 10/04/2022 19:15:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Funcionario](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](250) NOT NULL,
	[Cpf] [char](11) NOT NULL,
	[Email] [varchar](250) NOT NULL,
	[Telefone] [char](11) NOT NULL,
	[Habilitado] [bit] NOT NULL,
	[Ingles] [bit] NOT NULL,
	[Espanhol] [bit] NOT NULL,
	[Frances] [bit] NOT NULL,
	[Categoria] [char](1) NULL,
	[CargoId] [int] NOT NULL,
	[Salario] [money] NOT NULL,
	[Logradouro] [varchar](50) NULL,
	[Numero] [varchar](10) NULL,
	[Complemento] [varchar](100) NULL,
	[Bairro] [varchar](50) NULL,
	[Cep] [char](10) NULL,
	[Cidade] [varchar](80) NULL,
	[Estado] [char](2) NULL,
 CONSTRAINT [PK_Funcionario] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FuncionarioCargo]    Script Date: 10/04/2022 19:15:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FuncionarioCargo](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](40) NULL,
 CONSTRAINT [PK_FuncionarioCargo] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FuncionarioEscala]    Script Date: 10/04/2022 19:15:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FuncionarioEscala](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FuncionarioId] [int] NOT NULL,
	[DiaDaSemana] [int] NOT NULL,
	[HoraInicio] [time](7) NOT NULL,
	[HoraTermino] [time](7) NOT NULL,
	[TempoDescanso] [int] NOT NULL,
 CONSTRAINT [PK_FuncionarioEscala] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Departamento] ([Codigo], [NomeDepartamento], [NomeResponsavel], [LoginResponsavel], [EmailResponsavel]) VALUES (1, N'TI', N'SAULO', N'SAULOMB', N'SAULOMB@GMAIL.COM')
GO
INSERT [dbo].[Departamento] ([Codigo], [NomeDepartamento], [NomeResponsavel], [LoginResponsavel], [EmailResponsavel]) VALUES (2, N'INF', N'PEDRO AUGUSTO', N'PEDRO.MENDONCA', N'PEDRO.MENDONCA@GMAIL.COM')
GO
SET IDENTITY_INSERT [dbo].[Funcionario] ON 
GO
INSERT [dbo].[Funcionario] ([Id], [Nome], [Cpf], [Email], [Telefone], [Habilitado], [Ingles], [Espanhol], [Frances], [Categoria], [CargoId], [Salario], [Logradouro], [Numero], [Complemento], [Bairro], [Cep], [Cidade], [Estado]) VALUES (1, N'SAULO MENDONCA BEZERRA', N'79214940568', N'SAULOMB@GMAIL.COM', N'71999186706', 1, 1, 0, 0, N'B', 1, 2000.0000, N'RUA PURUS', N'19', N'CD JARDIM ATALAIA', N'STIEP', N'41770110  ', N'SALVADOR', N'BA')
GO
INSERT [dbo].[Funcionario] ([Id], [Nome], [Cpf], [Email], [Telefone], [Habilitado], [Ingles], [Espanhol], [Frances], [Categoria], [CargoId], [Salario], [Logradouro], [Numero], [Complemento], [Bairro], [Cep], [Cidade], [Estado]) VALUES (6, N'JULIANA MENDONÇA', N'79214940568', N'PEDRO.AMMENDONCA@GMAIL.COM', N'71999186706', 1, 0, 0, 0, N'A', 1, 45000.0000, N'Rua Purus', N'19', N'Atalaia', N'Stiep', N'41770110  ', N'Angical', N'BA')
GO
SET IDENTITY_INSERT [dbo].[Funcionario] OFF
GO
SET IDENTITY_INSERT [dbo].[FuncionarioCargo] ON 
GO
INSERT [dbo].[FuncionarioCargo] ([Id], [Nome]) VALUES (1, N'ANALISTA DE SISTEMAS')
GO
INSERT [dbo].[FuncionarioCargo] ([Id], [Nome]) VALUES (2, N'PROGRAMADOR')
GO
INSERT [dbo].[FuncionarioCargo] ([Id], [Nome]) VALUES (3, N'ADMINISTRADOR')
GO
INSERT [dbo].[FuncionarioCargo] ([Id], [Nome]) VALUES (4, N'ADVOGADO')
GO
INSERT [dbo].[FuncionarioCargo] ([Id], [Nome]) VALUES (5, N'MÉDICO')
GO
INSERT [dbo].[FuncionarioCargo] ([Id], [Nome]) VALUES (6, N'PROFESSOR')
GO
SET IDENTITY_INSERT [dbo].[FuncionarioCargo] OFF
GO
SET IDENTITY_INSERT [dbo].[FuncionarioEscala] ON 
GO
INSERT [dbo].[FuncionarioEscala] ([Id], [FuncionarioId], [DiaDaSemana], [HoraInicio], [HoraTermino], [TempoDescanso]) VALUES (3, 1, 3, CAST(N'08:00:00' AS Time), CAST(N'15:00:00' AS Time), 1)
GO
INSERT [dbo].[FuncionarioEscala] ([Id], [FuncionarioId], [DiaDaSemana], [HoraInicio], [HoraTermino], [TempoDescanso]) VALUES (4, 1, 4, CAST(N'08:00:00' AS Time), CAST(N'17:00:00' AS Time), 1)
GO
INSERT [dbo].[FuncionarioEscala] ([Id], [FuncionarioId], [DiaDaSemana], [HoraInicio], [HoraTermino], [TempoDescanso]) VALUES (5, 1, 6, CAST(N'08:00:00' AS Time), CAST(N'19:00:00' AS Time), 2)
GO
INSERT [dbo].[FuncionarioEscala] ([Id], [FuncionarioId], [DiaDaSemana], [HoraInicio], [HoraTermino], [TempoDescanso]) VALUES (6, 1, 2, CAST(N'06:00:00' AS Time), CAST(N'15:00:00' AS Time), 1)
GO
INSERT [dbo].[FuncionarioEscala] ([Id], [FuncionarioId], [DiaDaSemana], [HoraInicio], [HoraTermino], [TempoDescanso]) VALUES (13, 6, 2, CAST(N'09:00:00' AS Time), CAST(N'20:00:00' AS Time), 2)
GO
INSERT [dbo].[FuncionarioEscala] ([Id], [FuncionarioId], [DiaDaSemana], [HoraInicio], [HoraTermino], [TempoDescanso]) VALUES (14, 6, 3, CAST(N'10:00:00' AS Time), CAST(N'22:00:00' AS Time), 2)
GO
SET IDENTITY_INSERT [dbo].[FuncionarioEscala] OFF
GO
ALTER TABLE [dbo].[Funcionario] ADD  CONSTRAINT [DF_Funcionario_Ingles]  DEFAULT ((0)) FOR [Ingles]
GO
ALTER TABLE [dbo].[Funcionario] ADD  CONSTRAINT [DF_Funcionario_Espanhol]  DEFAULT ((0)) FOR [Espanhol]
GO
ALTER TABLE [dbo].[Funcionario] ADD  CONSTRAINT [DF_Funcionario_Frances]  DEFAULT ((0)) FOR [Frances]
GO
ALTER TABLE [dbo].[Funcionario]  WITH CHECK ADD  CONSTRAINT [FK_Funcionario_FuncionarioCargo_CargoId] FOREIGN KEY([CargoId])
REFERENCES [dbo].[FuncionarioCargo] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Funcionario] CHECK CONSTRAINT [FK_Funcionario_FuncionarioCargo_CargoId]
GO
ALTER TABLE [dbo].[FuncionarioEscala]  WITH CHECK ADD  CONSTRAINT [FK_FuncionarioEscala_Funcionario_FuncionarioId] FOREIGN KEY([FuncionarioId])
REFERENCES [dbo].[Funcionario] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[FuncionarioEscala] CHECK CONSTRAINT [FK_FuncionarioEscala_Funcionario_FuncionarioId]
GO
