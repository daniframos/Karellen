USE [KARELLEN]
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 26/10/2016 09:55:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__MigrationHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ContextKey] [nvarchar](300) NOT NULL,
	[Model] [varbinary](max) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC,
	[ContextKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
/****** Object:  Table [dbo].[TBGrupo]    Script Date: 26/10/2016 09:55:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TBGrupo](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_dbo.TBGrupo] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
/****** Object:  Table [dbo].[TBLog]    Script Date: 26/10/2016 09:55:53 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
/****** Object:  Table [dbo].[TBLoginExterno]    Script Date: 26/10/2016 09:55:53 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
/****** Object:  Table [dbo].[TBOcorrencia]    Script Date: 26/10/2016 09:55:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TBOcorrencia](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Titulo] [nvarchar](max) NULL,
	[DataAcontecimento] [datetime] NOT NULL,
	[DataCriacao] [datetime] NOT NULL,
	[DataResolucao] [datetime] NULL,
	[Excluida] [bit] NOT NULL,
	[SexoVitima] [int] NOT NULL,
	[Detalhes] [nvarchar](max) NULL,
	[HaBoletimDeOcorrencia] [bit] NULL,
	[Latitude] [nvarchar](max) NULL,
	[Longitude] [nvarchar](max) NULL,
	[UsuarioId] [int] NULL,
 CONSTRAINT [PK_dbo.TBOcorrencia] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
/****** Object:  Table [dbo].[TBTipoOcorrencia]    Script Date: 26/10/2016 09:55:54 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
/****** Object:  Table [dbo].[TBUsuario]    Script Date: 26/10/2016 09:55:55 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
/****** Object:  Table [dbo].[TBUsuarioGrupo]    Script Date: 26/10/2016 09:55:55 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
INSERT [dbo].[__MigrationHistory] ([MigrationId], [ContextKey], [Model], [ProductVersion]) VALUES (N'201610191258229_Initial', N'Karellen.Data.Migrations.Configuration', 0x1F8B0800000000000400ED1DDB6EDCB8F5BD40FF41D053BBC87A6CA7D9668DF12E9CB19D181BC781C709FA16D0123D262A51B312E58E51F4CBFAD04FEA2F94D485E2459448493376D2C02F36C573E5E1E1E1D139F27FFFFD9FF9AF9B38F21E609AA1041FFB077BFBBE0771908408AF8EFD9CDCFDF8DAFFF5973FFE617E16C61BEF733DEF259B47217176ECDF13B23E9ACDB2E01EC620DB8B519026597247F682249E8130991DEEEFFF3C3B3898418AC2A7B83C6F7E9D63826258FC41FF5C2438806B9283E83209619455E3F4C9B2C0EA7D0031CCD62080C7FE6F20855104F1DE2920608F4212B82189EF9D4408506E9630BAF33D80714200A1BC1E7DCAE092A4095E2DD7740044378F6B48E7DD812883950C47CD745B71F60F9938B306B04615E41949624784072F2BFDCC54F0415AF6B9FEA806CFA8A6C92393BAD0E2B1FF36CDD7545F2AA5A34594B259AA86197C0842B857C0BDF0A4A72FB84950CB613F2FBC451E913C85C718E62405D10BEF637E1BA1E037F87893FC1DE2639C4791C82065913E9306E8D0C73459C3943C5EC3BB8AED8BD0F76632DC4C05E460024C29D305262F0F7DEF03250E6E23C8D75F907F499214BE8518A680C0F0232004A698E180850635EA0AAD0F490C6B6AD4E0E8FEF1BD4BB0790FF18ADC1FFB87AF7EF2BD73B481613D5271F00923BADD28104973D8C2A142F5037840AB826185FEA72C07294A32DFBB86513121BB47EB7243946BF7A599729E26F17512D5D6C09F7C5926791A303992D6C737205D412233359F3526D66978159601A657417E37BE81C6F76A7F12DB53882E93DB14F6503ED8B723DD4D89FAF094FDD64188FEBA0D19CF6280A2DD6B16E27BF00E64F71308DC4D69516CB0E9C918DD54E150463AA9DA0B199C54EDC36C597A9FAC106E67A97874B6619B911310196B7BAEB1D73AC995C9AB2049531A99D120A795D31AAF34AF61B4E5B1E6EBDBE68C72F8A2E003BCBE08FE74AEBFE0820E3FC03049D5F56A85A0689DE6577A1F72C628CC99DDF0E1EB6DF82949D25D1317D4D67DCC3A4650D339027583757A8B413BACD9AA03F65703FC3DB032D1BA41248F92AD1FC34CEB2701BBCB06F45A8C09A7481FC01B14BBEF0E86719122108069705DC32C89F2566C3D11D42688726A7035DC9B84EE058007C4449BE4332228E6988A8DC986DD05820444F730DBFABABE036FA8B494E953286E554513DD38DE534326F9368234ED30C1ABDD5032B96E5B4F7D83D6495F4024CFF922AABF71DBC6495A10679EE91AC9751D3303A23895D1AE486FD019234B3EE09C91113CDD59D3F0A09F3AAD008C71F7E34926E3149AB498B9E4ECCE701EABCB3138DC11914CBF7FD4D8A77FA70DBD625859E48246017BA7498C304AA41BC6F7D0C7486BBD831327005DD995A94E1B989EACA8D05BA7F4264DFE4189ED245C1C1DD52D619601E10C7E4BA334F7FC58B5957AD280D3885D136B78DE1AA91321D29D8888D9A751A7DE78B432A0BDC8CE23B06ADE530D76710CDD443E8E0A17C2347AA4CA107D90ACC74B18DFC2B492E51264411E2196FDF90CA29C8EEC6B8A9700CE21635F987FA0EBB0D4568706DB4EC901FA9483181DE99369F53C4F49F219A2A0B899DA29F63AC96F3598030B989B6B803398D39B2907D303751D6C515C7B1E1A5A2FAD80629806A801FA4B37D022589FAC52B8026103F2AA1BE41DDD1F010A051A3F7503D0DB579A046C4F7188BFF64040EA569770C52EBD1F93F4324905DDBDEE91E821427CEECF36B67F926594BDC2865BB2AE3C5525D33CC3A16793B76A224F39957B490D1BADA929537776ECFFA0C9D4839F5F591AFCFC5224A33EF0D538EA0A9F426A5AD03B09CAD7EB0BEA638A57186A2C4599904768E8055316FB806841435DBA2511267A9C86E8E65E83C8420005D632CA63BC712AEA9353B88698056816EB6343DE985B665C70628AE6FA14359F0956D76D8CE65B84C9622CAE148DD9A86EDEDE302D6EFE0D193389A737D05E417660A5BD6B66C343CFF57C17D6DA967E311950E71BB55EC7B6BFB7A79FBEDDC89DEC5237FD41C6D521E40ECCAA430B5F83EF53DE679BD6DA5481D32C7355B165EFDC4CEFCB7BCDF20735E430085BDE6458F11D550F8F5EEA78B829CAD3C26C7A17AF22EDACBA23A93230C44B48947281E6EA24EB4453810CDE14136808B8067A5094D501D511DC86480E8D7AB049895D0D95B89F7B106929700D997A36F6CB69904E03158C42D193F6865498DAF52655DD9E96012A97415F266DC75BC6A402CAC678D4935B568085723A92A9BA862C6326C7A849104CB39D0E65F5C74902E20EA40394D6FA32445757EFA16D7D6C5BACBDF529BD35ADA85552BA42BACE1D9B934760BD76BF1D4A309C35E3F6519D2BE3270C7F369F9525E1D5C07C66A81D9F5F82F51AE195504B5E8D78CBB2907CF1E3D2BDBA3A2E71CC82ACA5C89A73CB299124052BA83CA5A429A7E728CD084B1CDD0296905A84B1364D3B4F0D1EBC26271D99FA8AD59EBD9ECE7E970F6EB9A6BE3A63F550AB42704E6563C50A859850B51A1DCE63E5FC200269CB4B8D4512E53136478D66E832F32CC297233A86F94C615C0B0A351D69373659E356EBD1B1119D57C4705E5AAC8911F2A957C58441A82E16D114C3D81157533F2CA262A318B861AAEA814534D59083644D75AF24191B76C153D7EE8A48EAB16763FD4A5C36C11E90E26DF78DD00D6ED2B5526829AABCA740D48C53AA9E14317616909AF109F75DD9CC8DD7E027B38AEE58CDD924CC21B2854174016FC739D6458522867ACC1E4B4BCDA088B0E5B11B6E5E3DA862E50FDCF00915842A46E191832BE685859237E6A32E0EB9292D943D7233EE202B2F2E94C4E4A3F6980CD583225AC3147B1A4D75A1E4D3F8A803A6A67C50768F7CF89B7465EA657A0277A6646EDC5D5A1F0293DAE514BCA8F9EEE4BC196359C2263B3A3D6FF784CB57A4BDA6894A860523BB3A7458399704BD76DBDC45A596BCB18B21B728BCAAC352C3F06AD81E17AFB41231F141B783493F8FDC0E8FBA8C4A3E3AEA5187034DAAA5920E35E9893B46953B71DC1EDB8976769F188EEC6DEF65396FD492FE10F26376590E01A0359BD191A86E6B70D4926ABA8AACB67881ACFD059640D99929E34B342BA63ADFAB99D852937DFABA6A393F750AB72A9EFB53727CF32ADFD6FF11092D01574EF13D76EF42214BBE2D1F3302E3D25696BF478B08152EAA9E700930BA8319292BB9FCC3FD8343E51B14CFE77B10B32C0BA3967CA5F6510879C57650C58C984A7BEB941D6B52C55A54FC00D2E01EA4FAB7183A913A7FD3E0FF4473ACDD7DC85702701FE2E23B010D66DBB2EE327D27E3FD530C367F1ED7E83F99EC654AAF873FF73E7D0754C39AB50798F3D7D727DD6E88AC59797C1BF464B8B556B962E36B75151738849B63FF9F05D49177F1B72F1CF0857795D203EBC8DBF7FE3595DB33D6F17DAD9E4FEEF31DB5558DBDBC2165954CD4CB3B0A97D6CBDB86CDAA2143E9EDBD456482BEDE62814776F48E5AC1CEAE5D4546AB3627A5837714735A97EE286CDB732F238EA2AEF4D5B36FF5B455A008EBE0A2DB5C57D325DABF759C3A2BBF0DDFDE34328EDC7842B3E2C84DA734248EC2A6341D8E3EBB461F316A63618ED1EF3944C5F2DD21C6E9044D86A3C4D41B0947A1139B05B7119A9B3350767BD29C459A34C8E664DC1C610536CA073E8B2879642B16AF99DD715B547B61EC88EEAF319D06BBEEA9FA2A1A09DC9BA8F4B075977D4CA6EAE151AD5B83ACAAF32DEA96DBA0BEE1A6A7093A9C9C2DF4EBF3338EA6F0D45EC6E2C5955AF6DDDFA5B425BF2245441A1376CD4D432DC854153DB9FD74BD78748CF39EC07EDADE313EAB68E7296D68875EC8D98A76EB87DA3B09F5060975155BDA04CD5D82E5DB5D7AA5BD652B5D06F6376F9C5A08BB3A08DBD13B3518F2E0BAA7BDB09DD4C016C49E0EC4765A837B142D5A14DB29BA37329AFA188DDAEB452AFB84763BB3B38776ABDB654BA52286D41E62DB37A9F75E9ACCEF19364BEA36A91682DB77447634563EF31648E7F57756DBE8EE46DE92D8D7E46828B3D2E355AD4BADB7B5B14D5BF283A985AE5B287B856E2FE39A60A5A716DCA19D532FE1A2C185F0DF82687C93A1558382FDEF200C0329ACE0732EF05D5207380A47F514259178090908D90BDC94A03B1010FA388059567CFFADFA2CD3597C0BC30B7C9593754EA8C830BE8DA48F29B228A98B7ED1B32AF33CBF5A179FDF9C4204CA2662B9FB2BFC264751C8F93E6FC9641A50B0F0AB7A01C3D692B01731AB478EE943822D1155EAE351E30D8CD71145965DE12578804378FB94C1F7700582C7BA12CF8CA47F2164B5CF4F1158A520CE2A1C0D3CFD93DA70186F7EF91FF51EE215346B0000, N'6.1.3-40302')
SET IDENTITY_INSERT [dbo].[TBGrupo] ON 

INSERT [dbo].[TBGrupo] ([Id], [Nome]) VALUES (1, N'Administrador')
SET IDENTITY_INSERT [dbo].[TBGrupo] OFF
SET IDENTITY_INSERT [dbo].[TBLog] ON 

INSERT [dbo].[TBLog] ([Id], [Ip], [Local], [UserAgent], [Browser], [Data], [SessaoId], [EntidadeNome], [EntidadeId], [Acao]) VALUES (1, N'127.0.0.1', N'http://localhost:62651/ocorrencia/nova', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/54.0.2840.59 Safari/537.36', N'Chrome', CAST(N'2016-10-17T20:31:39.590' AS DateTime), N'28033be5-3b48-483d-95b5-ffd8062436d1', NULL, NULL, NULL)
INSERT [dbo].[TBLog] ([Id], [Ip], [Local], [UserAgent], [Browser], [Data], [SessaoId], [EntidadeNome], [EntidadeId], [Acao]) VALUES (2, N'127.0.0.1', N'http://localhost:62651/ocorrencia/nova', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/54.0.2840.59 Safari/537.36', N'Chrome', CAST(N'2016-10-17T20:31:47.900' AS DateTime), N'28033be5-3b48-483d-95b5-ffd8062436d1', NULL, NULL, NULL)
INSERT [dbo].[TBLog] ([Id], [Ip], [Local], [UserAgent], [Browser], [Data], [SessaoId], [EntidadeNome], [EntidadeId], [Acao]) VALUES (3, N'::1', N'http://localhost:62651/ocorrencia/nova', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/54.0.2840.59 Safari/537.36', N'Chrome', CAST(N'2016-10-17T20:43:21.463' AS DateTime), N'14e05ca0-a0f5-4083-9eaf-8ef5fa047de2', NULL, NULL, NULL)
INSERT [dbo].[TBLog] ([Id], [Ip], [Local], [UserAgent], [Browser], [Data], [SessaoId], [EntidadeNome], [EntidadeId], [Acao]) VALUES (4, N'::1', N'http://localhost:62651/ocorrencia/nova', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/54.0.2840.59 Safari/537.36', N'Chrome', CAST(N'2016-10-17T20:43:32.423' AS DateTime), N'14e05ca0-a0f5-4083-9eaf-8ef5fa047de2', N'Ocorrencia', N'1', N'SalvarNovaOcorrencia')
INSERT [dbo].[TBLog] ([Id], [Ip], [Local], [UserAgent], [Browser], [Data], [SessaoId], [EntidadeNome], [EntidadeId], [Acao]) VALUES (5, N'::1', N'http://localhost:62651/ocorrencia/nova', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/54.0.2840.59 Safari/537.36', N'Chrome', CAST(N'2016-10-17T21:00:04.520' AS DateTime), N'b6e69a7a-1498-48d0-a3bd-6b477e8aa6f7', NULL, NULL, NULL)
INSERT [dbo].[TBLog] ([Id], [Ip], [Local], [UserAgent], [Browser], [Data], [SessaoId], [EntidadeNome], [EntidadeId], [Acao]) VALUES (6, N'::1', N'http://localhost:62651/ocorrencia/nova', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/54.0.2840.59 Safari/537.36', N'Chrome', CAST(N'2016-10-17T21:00:26.927' AS DateTime), N'b6e69a7a-1498-48d0-a3bd-6b477e8aa6f7', N'Ocorrencia', N'2', N'SalvarNovaOcorrencia')
INSERT [dbo].[TBLog] ([Id], [Ip], [Local], [UserAgent], [Browser], [Data], [SessaoId], [EntidadeNome], [EntidadeId], [Acao]) VALUES (7, N'::1', N'http://localhost:62651/ocorrencia/nova', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/54.0.2840.59 Safari/537.36', N'Chrome', CAST(N'2016-10-17T21:00:54.377' AS DateTime), N'14899e3c-1b30-48df-8f6e-f22be73a84f7', NULL, NULL, NULL)
INSERT [dbo].[TBLog] ([Id], [Ip], [Local], [UserAgent], [Browser], [Data], [SessaoId], [EntidadeNome], [EntidadeId], [Acao]) VALUES (8, N'::1', N'http://localhost:62651/ocorrencia/nova', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/54.0.2840.59 Safari/537.36', N'Chrome', CAST(N'2016-10-17T21:01:02.283' AS DateTime), N'14899e3c-1b30-48df-8f6e-f22be73a84f7', N'Ocorrencia', N'3', N'SalvarNovaOcorrencia')
INSERT [dbo].[TBLog] ([Id], [Ip], [Local], [UserAgent], [Browser], [Data], [SessaoId], [EntidadeNome], [EntidadeId], [Acao]) VALUES (9, N'::1', N'http://localhost:62651/ocorrencia/nova', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/54.0.2840.59 Safari/537.36', N'Chrome', CAST(N'2016-10-17T21:04:19.740' AS DateTime), N'97034b41-2623-4eee-a501-793e72f4c930', N'Ocorrencia', N'4', N'SalvarNovaOcorrencia')
INSERT [dbo].[TBLog] ([Id], [Ip], [Local], [UserAgent], [Browser], [Data], [SessaoId], [EntidadeNome], [EntidadeId], [Acao]) VALUES (10, N'::1', N'http://localhost:62651/ocorrencia/nova', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/54.0.2840.59 Safari/537.36', N'Chrome', CAST(N'2016-10-17T21:12:17.880' AS DateTime), N'7732e92c-603d-436b-a6d5-32e4fb6b008c', N'Ocorrencia', N'5', N'SalvarNovaOcorrencia')
INSERT [dbo].[TBLog] ([Id], [Ip], [Local], [UserAgent], [Browser], [Data], [SessaoId], [EntidadeNome], [EntidadeId], [Acao]) VALUES (11, N'::1', N'http://localhost:62651/ocorrencia/nova', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/54.0.2840.59 Safari/537.36', N'Chrome', CAST(N'2016-10-17T21:13:01.697' AS DateTime), N'73724cd0-56d7-4fce-9486-942ff09872ed', N'Ocorrencia', N'6', N'SalvarNovaOcorrencia')
INSERT [dbo].[TBLog] ([Id], [Ip], [Local], [UserAgent], [Browser], [Data], [SessaoId], [EntidadeNome], [EntidadeId], [Acao]) VALUES (12, N'::1', N'http://localhost:62651/ocorrencia/nova', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/54.0.2840.59 Safari/537.36', N'Chrome', CAST(N'2016-10-18T10:31:17.770' AS DateTime), N'74be5082-b19e-460f-9647-3ddae6052460', N'Ocorrencia', N'7', N'SalvarNovaOcorrencia')
INSERT [dbo].[TBLog] ([Id], [Ip], [Local], [UserAgent], [Browser], [Data], [SessaoId], [EntidadeNome], [EntidadeId], [Acao]) VALUES (13, N'::1', N'http://localhost:62651/ocorrencia/nova', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/54.0.2840.59 Safari/537.36', N'Chrome', CAST(N'2016-10-18T12:21:39.150' AS DateTime), N'6b7b6a5c-4910-43c2-a2e2-5281f40b0af6', N'Ocorrencia', N'8', N'SalvarNovaOcorrencia')
INSERT [dbo].[TBLog] ([Id], [Ip], [Local], [UserAgent], [Browser], [Data], [SessaoId], [EntidadeNome], [EntidadeId], [Acao]) VALUES (14, N'::1', N'http://localhost:62651/ocorrencia/nova', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/54.0.2840.59 Safari/537.36', N'Chrome', CAST(N'2016-10-18T15:42:44.190' AS DateTime), N'c5b15721-4588-4a5a-8ad3-a8788ba13c61', N'Ocorrencia', N'9', N'SalvarNovaOcorrencia')
INSERT [dbo].[TBLog] ([Id], [Ip], [Local], [UserAgent], [Browser], [Data], [SessaoId], [EntidadeNome], [EntidadeId], [Acao]) VALUES (15, N'::1', N'http://localhost:62651/ocorrencia/nova', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/54.0.2840.59 Safari/537.36', N'Chrome', CAST(N'2016-10-18T15:43:12.283' AS DateTime), N'884cdb32-d421-4040-800d-85be181ba076', NULL, NULL, NULL)
INSERT [dbo].[TBLog] ([Id], [Ip], [Local], [UserAgent], [Browser], [Data], [SessaoId], [EntidadeNome], [EntidadeId], [Acao]) VALUES (16, N'::1', N'http://localhost:62651/ocorrencia/nova', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/54.0.2840.59 Safari/537.36', N'Chrome', CAST(N'2016-10-18T15:43:21.933' AS DateTime), N'884cdb32-d421-4040-800d-85be181ba076', N'Ocorrencia', N'10', N'SalvarNovaOcorrencia')
INSERT [dbo].[TBLog] ([Id], [Ip], [Local], [UserAgent], [Browser], [Data], [SessaoId], [EntidadeNome], [EntidadeId], [Acao]) VALUES (17, N'::1', N'http://localhost:62651/ocorrencia/nova', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/54.0.2840.59 Safari/537.36', N'Chrome', CAST(N'2016-10-18T15:43:44.737' AS DateTime), N'858b3ea7-5b82-4b77-b1f3-4c6b6137c903', N'Ocorrencia', N'11', N'SalvarNovaOcorrencia')
INSERT [dbo].[TBLog] ([Id], [Ip], [Local], [UserAgent], [Browser], [Data], [SessaoId], [EntidadeNome], [EntidadeId], [Acao]) VALUES (18, N'::1', N'http://localhost:62651/ocorrencia/nova', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/54.0.2840.59 Safari/537.36', N'Chrome', CAST(N'2016-10-18T15:56:28.940' AS DateTime), N'b9a92933-602f-4639-9420-3bef893738fa', N'Ocorrencia', N'12', N'SalvarNovaOcorrencia')
INSERT [dbo].[TBLog] ([Id], [Ip], [Local], [UserAgent], [Browser], [Data], [SessaoId], [EntidadeNome], [EntidadeId], [Acao]) VALUES (19, N'::1', N'http://localhost:62651/ocorrencia/nova', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/54.0.2840.59 Safari/537.36', N'Chrome', CAST(N'2016-10-18T16:00:04.087' AS DateTime), N'c52e3d27-2c44-4194-8e68-f423552865ed', N'Ocorrencia', N'13', N'SalvarNovaOcorrencia')
INSERT [dbo].[TBLog] ([Id], [Ip], [Local], [UserAgent], [Browser], [Data], [SessaoId], [EntidadeNome], [EntidadeId], [Acao]) VALUES (20, N'::1', N'http://localhost:62651/ocorrencia/nova', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/54.0.2840.59 Safari/537.36', N'Chrome', CAST(N'2016-10-18T17:33:15.930' AS DateTime), N'16430f42-7e27-4d91-ba76-4e28fe176e16', NULL, NULL, NULL)
INSERT [dbo].[TBLog] ([Id], [Ip], [Local], [UserAgent], [Browser], [Data], [SessaoId], [EntidadeNome], [EntidadeId], [Acao]) VALUES (21, N'::1', N'http://localhost:62651/ocorrencia/nova', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/54.0.2840.59 Safari/537.36', N'Chrome', CAST(N'2016-10-18T17:33:28.873' AS DateTime), N'6367f7b1-fbd1-4b03-987a-1c1b1539cbc9', N'Ocorrencia', N'15', N'SalvarNovaOcorrencia')
INSERT [dbo].[TBLog] ([Id], [Ip], [Local], [UserAgent], [Browser], [Data], [SessaoId], [EntidadeNome], [EntidadeId], [Acao]) VALUES (22, N'::1', N'http://localhost:62651/ocorrencia/nova', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/54.0.2840.59 Safari/537.36', N'Chrome', CAST(N'2016-10-18T17:59:04.807' AS DateTime), N'469f0126-953c-42d4-acb2-93e49d46c4f8', NULL, NULL, NULL)
INSERT [dbo].[TBLog] ([Id], [Ip], [Local], [UserAgent], [Browser], [Data], [SessaoId], [EntidadeNome], [EntidadeId], [Acao]) VALUES (23, N'::1', N'http://localhost:62651/ocorrencia/editar/11', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/54.0.2840.59 Safari/537.36', N'Chrome', CAST(N'2016-10-19T10:28:38.863' AS DateTime), N'a7135a73-879b-432b-ac49-5d1fcf9f2147', NULL, NULL, NULL)
INSERT [dbo].[TBLog] ([Id], [Ip], [Local], [UserAgent], [Browser], [Data], [SessaoId], [EntidadeNome], [EntidadeId], [Acao]) VALUES (24, N'::1', N'http://localhost:62651/ocorrencia/editar/10', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/54.0.2840.59 Safari/537.36', N'Chrome', CAST(N'2016-10-19T10:37:51.440' AS DateTime), N'c55b0fd6-7a89-4ae3-a6f4-626db101375a', NULL, NULL, NULL)
INSERT [dbo].[TBLog] ([Id], [Ip], [Local], [UserAgent], [Browser], [Data], [SessaoId], [EntidadeNome], [EntidadeId], [Acao]) VALUES (25, N'::1', N'http://localhost:62651/ocorrencia/editar/11', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/54.0.2840.59 Safari/537.36', N'Chrome', CAST(N'2016-10-19T10:41:45.030' AS DateTime), N'8d47f9ad-4fa3-4048-8b1b-a7059a8fa6c9', NULL, NULL, NULL)
INSERT [dbo].[TBLog] ([Id], [Ip], [Local], [UserAgent], [Browser], [Data], [SessaoId], [EntidadeNome], [EntidadeId], [Acao]) VALUES (26, N'::1', N'http://localhost:62651/ocorrencia/editar/11', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/54.0.2840.59 Safari/537.36', N'Chrome', CAST(N'2016-10-19T11:07:17.937' AS DateTime), N'40320fd8-1c33-4b5a-8a4d-e5f17b2cf91c', NULL, NULL, NULL)
INSERT [dbo].[TBLog] ([Id], [Ip], [Local], [UserAgent], [Browser], [Data], [SessaoId], [EntidadeNome], [EntidadeId], [Acao]) VALUES (27, N'::1', N'http://localhost:62651/ocorrencia/editar/11', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/54.0.2840.59 Safari/537.36', N'Chrome', CAST(N'2016-10-19T11:14:08.080' AS DateTime), N'a24cb462-eade-400c-87c3-03cf3163cc76', NULL, NULL, NULL)
INSERT [dbo].[TBLog] ([Id], [Ip], [Local], [UserAgent], [Browser], [Data], [SessaoId], [EntidadeNome], [EntidadeId], [Acao]) VALUES (28, N'::1', N'http://localhost:62651/ocorrencia/editar/9', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/54.0.2840.59 Safari/537.36', N'Chrome', CAST(N'2016-10-19T11:19:03.617' AS DateTime), N'8f73d70b-b35d-4a20-a059-261729ce6267', NULL, NULL, NULL)
INSERT [dbo].[TBLog] ([Id], [Ip], [Local], [UserAgent], [Browser], [Data], [SessaoId], [EntidadeNome], [EntidadeId], [Acao]) VALUES (29, N'::1', N'http://localhost:62651/ocorrencia/editar/15', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/54.0.2840.59 Safari/537.36', N'Chrome', CAST(N'2016-10-19T11:25:29.003' AS DateTime), N'd5855788-8a0c-40a1-8718-cef0714efe99', N'Ocorrencia', N'18', N'AtualizarOcorrencia')
INSERT [dbo].[TBLog] ([Id], [Ip], [Local], [UserAgent], [Browser], [Data], [SessaoId], [EntidadeNome], [EntidadeId], [Acao]) VALUES (30, N'::1', N'http://localhost:62651/ocorrencia/editar/12', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/54.0.2840.59 Safari/537.36', N'Chrome', CAST(N'2016-10-19T11:27:29.010' AS DateTime), N'eb823681-637d-4668-b421-5d382e0e9666', N'Ocorrencia', N'19', N'AtualizarOcorrencia')
INSERT [dbo].[TBLog] ([Id], [Ip], [Local], [UserAgent], [Browser], [Data], [SessaoId], [EntidadeNome], [EntidadeId], [Acao]) VALUES (31, N'::1', N'http://localhost:62651/ocorrencia/editar/13', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/54.0.2840.59 Safari/537.36', N'Chrome', CAST(N'2016-10-19T11:28:21.560' AS DateTime), N'3dc774e1-2613-406d-98c6-c83ed4f7bd4d', N'Ocorrencia', N'20', N'AtualizarOcorrencia')
INSERT [dbo].[TBLog] ([Id], [Ip], [Local], [UserAgent], [Browser], [Data], [SessaoId], [EntidadeNome], [EntidadeId], [Acao]) VALUES (32, N'::1', N'http://localhost:62651/ocorrencia/editar/20', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/54.0.2840.59 Safari/537.36', N'Chrome', CAST(N'2016-10-19T11:28:46.497' AS DateTime), N'd8c4d3bb-2e96-4cd6-9ff0-f031c0bd45f9', N'Ocorrencia', N'21', N'AtualizarOcorrencia')
INSERT [dbo].[TBLog] ([Id], [Ip], [Local], [UserAgent], [Browser], [Data], [SessaoId], [EntidadeNome], [EntidadeId], [Acao]) VALUES (33, N'::1', N'http://localhost:62651/ocorrencia/editar/21', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/54.0.2840.59 Safari/537.36', N'Chrome', CAST(N'2016-10-19T11:29:47.130' AS DateTime), N'd300b591-ebf1-499b-8c44-10196eeb501a', N'Ocorrencia', N'22', N'AtualizarOcorrencia')
INSERT [dbo].[TBLog] ([Id], [Ip], [Local], [UserAgent], [Browser], [Data], [SessaoId], [EntidadeNome], [EntidadeId], [Acao]) VALUES (34, N'::1', N'http://localhost:62651/ocorrencia/nova', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/54.0.2840.59 Safari/537.36', N'Chrome', CAST(N'2016-10-19T11:39:04.133' AS DateTime), N'c03080c1-53e8-4fc4-ab80-b1beee98634e', NULL, NULL, NULL)
INSERT [dbo].[TBLog] ([Id], [Ip], [Local], [UserAgent], [Browser], [Data], [SessaoId], [EntidadeNome], [EntidadeId], [Acao]) VALUES (35, N'::1', N'http://localhost:62651/ocorrencia/nova', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/54.0.2840.59 Safari/537.36', N'Chrome', CAST(N'2016-10-19T11:49:07.707' AS DateTime), N'c03080c1-53e8-4fc4-ab80-b1beee98634e', NULL, NULL, NULL)
INSERT [dbo].[TBLog] ([Id], [Ip], [Local], [UserAgent], [Browser], [Data], [SessaoId], [EntidadeNome], [EntidadeId], [Acao]) VALUES (36, N'::1', N'http://localhost:62651/ocorrencia/nova', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/54.0.2840.59 Safari/537.36', N'Chrome', CAST(N'2016-10-19T11:49:28.787' AS DateTime), N'c03080c1-53e8-4fc4-ab80-b1beee98634e', N'Ocorrencia', N'23', N'SalvarNovaOcorrencia')
INSERT [dbo].[TBLog] ([Id], [Ip], [Local], [UserAgent], [Browser], [Data], [SessaoId], [EntidadeNome], [EntidadeId], [Acao]) VALUES (37, N'::1', N'http://localhost:62651/ocorrencia/editar/23', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/54.0.2840.59 Safari/537.36', N'Chrome', CAST(N'2016-10-19T11:49:56.163' AS DateTime), N'29667f8c-e2f6-435a-b55e-f9323f8efb7e', N'Ocorrencia', N'24', N'AtualizarOcorrencia')
INSERT [dbo].[TBLog] ([Id], [Ip], [Local], [UserAgent], [Browser], [Data], [SessaoId], [EntidadeNome], [EntidadeId], [Acao]) VALUES (38, N'::1', N'http://localhost:62651/ocorrencia/editar/22', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/54.0.2840.59 Safari/537.36', N'Chrome', CAST(N'2016-10-19T11:51:11.340' AS DateTime), N'aa513728-3ab8-4b2f-bbdd-8f5a9d79b8ef', N'Ocorrencia', N'25', N'AtualizarOcorrencia')
INSERT [dbo].[TBLog] ([Id], [Ip], [Local], [UserAgent], [Browser], [Data], [SessaoId], [EntidadeNome], [EntidadeId], [Acao]) VALUES (39, N'::1', N'http://localhost:62651/ocorrencia/nova', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/54.0.2840.59 Safari/537.36', N'Chrome', CAST(N'2016-10-19T12:19:22.787' AS DateTime), N'73746c27-746e-444c-a8bf-3a1843fadda0', N'Ocorrencia', N'26', N'SalvarNovaOcorrencia')
INSERT [dbo].[TBLog] ([Id], [Ip], [Local], [UserAgent], [Browser], [Data], [SessaoId], [EntidadeNome], [EntidadeId], [Acao]) VALUES (40, N'179.185.92.9', N'http://karellendesenv.azurewebsites.net/ocorrencia/nova', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/54.0.2840.59 Safari/537.36', N'Chrome', CAST(N'2016-10-19T16:52:31.913' AS DateTime), N'2511f283-cf23-4f6e-a304-301fa0809c3f', NULL, NULL, NULL)
INSERT [dbo].[TBLog] ([Id], [Ip], [Local], [UserAgent], [Browser], [Data], [SessaoId], [EntidadeNome], [EntidadeId], [Acao]) VALUES (41, N'186.215.83.51', N'http://karellendesenv.azurewebsites.net/ocorrencia/nova', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/54.0.2840.59 Safari/537.36', N'Chrome', CAST(N'2016-10-19T17:12:47.693' AS DateTime), N'44941d63-3a94-48c2-ab1c-df64052edf74', NULL, NULL, NULL)
INSERT [dbo].[TBLog] ([Id], [Ip], [Local], [UserAgent], [Browser], [Data], [SessaoId], [EntidadeNome], [EntidadeId], [Acao]) VALUES (42, N'186.215.83.51', N'http://karellendesenv.azurewebsites.net/ocorrencia/nova', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/54.0.2840.59 Safari/537.36', N'Chrome', CAST(N'2016-10-19T17:13:00.763' AS DateTime), N'44941d63-3a94-48c2-ab1c-df64052edf74', NULL, NULL, NULL)
INSERT [dbo].[TBLog] ([Id], [Ip], [Local], [UserAgent], [Browser], [Data], [SessaoId], [EntidadeNome], [EntidadeId], [Acao]) VALUES (43, N'186.215.83.51', N'http://karellendesenv.azurewebsites.net/ocorrencia/nova', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/54.0.2840.59 Safari/537.36', N'Chrome', CAST(N'2016-10-19T17:14:04.753' AS DateTime), N'b48661dc-e54f-42a0-bb52-71b331105de6', N'Ocorrencia', N'27', N'SalvarNovaOcorrencia')
INSERT [dbo].[TBLog] ([Id], [Ip], [Local], [UserAgent], [Browser], [Data], [SessaoId], [EntidadeNome], [EntidadeId], [Acao]) VALUES (44, N'179.179.56.240', N'http://karellendesenv.azurewebsites.net/ocorrencia/nova', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/53.0.2785.143 Safari/537.36', N'Chrome', CAST(N'2016-10-25T16:57:32.737' AS DateTime), N'a9efcda7-d372-4025-884e-fd9b5c203421', NULL, NULL, NULL)
INSERT [dbo].[TBLog] ([Id], [Ip], [Local], [UserAgent], [Browser], [Data], [SessaoId], [EntidadeNome], [EntidadeId], [Acao]) VALUES (45, N'179.179.56.240', N'http://karellendesenv.azurewebsites.net/ocorrencia/nova', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/53.0.2785.143 Safari/537.36', N'Chrome', CAST(N'2016-10-25T16:57:53.393' AS DateTime), N'a9efcda7-d372-4025-884e-fd9b5c203421', NULL, NULL, NULL)
INSERT [dbo].[TBLog] ([Id], [Ip], [Local], [UserAgent], [Browser], [Data], [SessaoId], [EntidadeNome], [EntidadeId], [Acao]) VALUES (46, N'179.179.56.240', N'http://karellendesenv.azurewebsites.net/ocorrencia/nova', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/53.0.2785.143 Safari/537.36', N'Chrome', CAST(N'2016-10-25T16:58:00.607' AS DateTime), N'a9efcda7-d372-4025-884e-fd9b5c203421', NULL, NULL, NULL)
INSERT [dbo].[TBLog] ([Id], [Ip], [Local], [UserAgent], [Browser], [Data], [SessaoId], [EntidadeNome], [EntidadeId], [Acao]) VALUES (47, N'179.179.56.240', N'http://karellendesenv.azurewebsites.net/ocorrencia/nova', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/53.0.2785.143 Safari/537.36', N'Chrome', CAST(N'2016-10-25T16:58:05.807' AS DateTime), N'a9efcda7-d372-4025-884e-fd9b5c203421', NULL, NULL, NULL)
INSERT [dbo].[TBLog] ([Id], [Ip], [Local], [UserAgent], [Browser], [Data], [SessaoId], [EntidadeNome], [EntidadeId], [Acao]) VALUES (48, N'179.179.56.240', N'http://karellendesenv.azurewebsites.net/ocorrencia/nova', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/53.0.2785.143 Safari/537.36', N'Chrome', CAST(N'2016-10-25T16:59:31.233' AS DateTime), N'a9efcda7-d372-4025-884e-fd9b5c203421', NULL, NULL, NULL)
INSERT [dbo].[TBLog] ([Id], [Ip], [Local], [UserAgent], [Browser], [Data], [SessaoId], [EntidadeNome], [EntidadeId], [Acao]) VALUES (49, N'179.179.56.240', N'http://karellendesenv.azurewebsites.net/ocorrencia/nova', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/53.0.2785.143 Safari/537.36', N'Chrome', CAST(N'2016-10-25T18:55:23.153' AS DateTime), N'2c1ae732-d9f2-426e-9ce1-9a11d77b49e1', NULL, NULL, NULL)
INSERT [dbo].[TBLog] ([Id], [Ip], [Local], [UserAgent], [Browser], [Data], [SessaoId], [EntidadeNome], [EntidadeId], [Acao]) VALUES (50, N'179.179.56.240', N'http://karellendesenv.azurewebsites.net/ocorrencia/nova', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/53.0.2785.143 Safari/537.36', N'Chrome', CAST(N'2016-10-25T19:19:15.387' AS DateTime), N'2c1ae732-d9f2-426e-9ce1-9a11d77b49e1', N'Ocorrencia', N'28', N'SalvarNovaOcorrencia')
INSERT [dbo].[TBLog] ([Id], [Ip], [Local], [UserAgent], [Browser], [Data], [SessaoId], [EntidadeNome], [EntidadeId], [Acao]) VALUES (51, N'179.179.56.240', N'http://karellendesenv.azurewebsites.net/ocorrencia/nova', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/53.0.2785.143 Safari/537.36', N'Chrome', CAST(N'2016-10-25T19:22:02.963' AS DateTime), N'6ecc7713-9df6-4cf4-98c1-1d41f07e4e4f', NULL, NULL, NULL)
INSERT [dbo].[TBLog] ([Id], [Ip], [Local], [UserAgent], [Browser], [Data], [SessaoId], [EntidadeNome], [EntidadeId], [Acao]) VALUES (52, N'179.179.56.240', N'http://karellendesenv.azurewebsites.net/ocorrencia/nova', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/53.0.2785.143 Safari/537.36', N'Chrome', CAST(N'2016-10-25T19:22:13.403' AS DateTime), N'6ecc7713-9df6-4cf4-98c1-1d41f07e4e4f', NULL, NULL, NULL)
INSERT [dbo].[TBLog] ([Id], [Ip], [Local], [UserAgent], [Browser], [Data], [SessaoId], [EntidadeNome], [EntidadeId], [Acao]) VALUES (53, N'179.179.56.240', N'http://karellendesenv.azurewebsites.net/ocorrencia/nova', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/53.0.2785.143 Safari/537.36', N'Chrome', CAST(N'2016-10-25T19:22:30.097' AS DateTime), N'6ecc7713-9df6-4cf4-98c1-1d41f07e4e4f', NULL, NULL, NULL)
INSERT [dbo].[TBLog] ([Id], [Ip], [Local], [UserAgent], [Browser], [Data], [SessaoId], [EntidadeNome], [EntidadeId], [Acao]) VALUES (54, N'179.179.56.240', N'http://karellendesenv.azurewebsites.net/ocorrencia/nova', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/53.0.2785.143 Safari/537.36', N'Chrome', CAST(N'2016-10-25T19:23:02.457' AS DateTime), N'6ecc7713-9df6-4cf4-98c1-1d41f07e4e4f', N'Ocorrencia', N'29', N'SalvarNovaOcorrencia')
INSERT [dbo].[TBLog] ([Id], [Ip], [Local], [UserAgent], [Browser], [Data], [SessaoId], [EntidadeNome], [EntidadeId], [Acao]) VALUES (55, N'179.179.56.240', N'http://karellendesenv.azurewebsites.net/ocorrencia/nova', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/53.0.2785.143 Safari/537.36', N'Chrome', CAST(N'2016-10-25T19:23:23.563' AS DateTime), N'913f8805-b481-4e06-938e-152a24938b12', NULL, NULL, NULL)
INSERT [dbo].[TBLog] ([Id], [Ip], [Local], [UserAgent], [Browser], [Data], [SessaoId], [EntidadeNome], [EntidadeId], [Acao]) VALUES (56, N'179.179.56.240', N'http://karellendesenv.azurewebsites.net/ocorrencia/nova', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/53.0.2785.143 Safari/537.36', N'Chrome', CAST(N'2016-10-25T19:23:32.257' AS DateTime), N'913f8805-b481-4e06-938e-152a24938b12', NULL, NULL, NULL)
INSERT [dbo].[TBLog] ([Id], [Ip], [Local], [UserAgent], [Browser], [Data], [SessaoId], [EntidadeNome], [EntidadeId], [Acao]) VALUES (57, N'179.179.56.240', N'http://karellendesenv.azurewebsites.net/ocorrencia/nova', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/53.0.2785.143 Safari/537.36', N'Chrome', CAST(N'2016-10-25T19:23:36.357' AS DateTime), N'913f8805-b481-4e06-938e-152a24938b12', NULL, NULL, NULL)
INSERT [dbo].[TBLog] ([Id], [Ip], [Local], [UserAgent], [Browser], [Data], [SessaoId], [EntidadeNome], [EntidadeId], [Acao]) VALUES (58, N'179.179.56.240', N'http://karellendesenv.azurewebsites.net/ocorrencia/nova', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/53.0.2785.143 Safari/537.36', N'Chrome', CAST(N'2016-10-25T19:23:47.713' AS DateTime), N'913f8805-b481-4e06-938e-152a24938b12', NULL, NULL, NULL)
INSERT [dbo].[TBLog] ([Id], [Ip], [Local], [UserAgent], [Browser], [Data], [SessaoId], [EntidadeNome], [EntidadeId], [Acao]) VALUES (59, N'179.179.56.240', N'http://karellendesenv.azurewebsites.net/ocorrencia/nova', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/53.0.2785.143 Safari/537.36', N'Chrome', CAST(N'2016-10-25T19:23:57.873' AS DateTime), N'913f8805-b481-4e06-938e-152a24938b12', NULL, NULL, NULL)
INSERT [dbo].[TBLog] ([Id], [Ip], [Local], [UserAgent], [Browser], [Data], [SessaoId], [EntidadeNome], [EntidadeId], [Acao]) VALUES (60, N'179.179.56.240', N'http://karellendesenv.azurewebsites.net/ocorrencia/nova', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/53.0.2785.143 Safari/537.36', N'Chrome', CAST(N'2016-10-25T19:24:01.403' AS DateTime), N'913f8805-b481-4e06-938e-152a24938b12', NULL, NULL, NULL)
INSERT [dbo].[TBLog] ([Id], [Ip], [Local], [UserAgent], [Browser], [Data], [SessaoId], [EntidadeNome], [EntidadeId], [Acao]) VALUES (61, N'179.179.56.240', N'http://karellendesenv.azurewebsites.net/ocorrencia/nova', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/53.0.2785.143 Safari/537.36', N'Chrome', CAST(N'2016-10-25T19:24:22.780' AS DateTime), N'913f8805-b481-4e06-938e-152a24938b12', N'Ocorrencia', N'30', N'SalvarNovaOcorrencia')
INSERT [dbo].[TBLog] ([Id], [Ip], [Local], [UserAgent], [Browser], [Data], [SessaoId], [EntidadeNome], [EntidadeId], [Acao]) VALUES (62, N'179.179.56.240', N'http://karellendesenv.azurewebsites.net/ocorrencia/nova', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/53.0.2785.143 Safari/537.36', N'Chrome', CAST(N'2016-10-25T19:24:57.897' AS DateTime), N'33847fe8-8798-4463-a6c4-f9508985badf', NULL, NULL, NULL)
INSERT [dbo].[TBLog] ([Id], [Ip], [Local], [UserAgent], [Browser], [Data], [SessaoId], [EntidadeNome], [EntidadeId], [Acao]) VALUES (63, N'179.179.56.240', N'http://karellendesenv.azurewebsites.net/ocorrencia/nova', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/53.0.2785.143 Safari/537.36', N'Chrome', CAST(N'2016-10-25T19:25:10.413' AS DateTime), N'33847fe8-8798-4463-a6c4-f9508985badf', NULL, NULL, NULL)
INSERT [dbo].[TBLog] ([Id], [Ip], [Local], [UserAgent], [Browser], [Data], [SessaoId], [EntidadeNome], [EntidadeId], [Acao]) VALUES (64, N'179.179.56.240', N'http://karellendesenv.azurewebsites.net/ocorrencia/nova', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/53.0.2785.143 Safari/537.36', N'Chrome', CAST(N'2016-10-25T19:25:41.803' AS DateTime), N'33847fe8-8798-4463-a6c4-f9508985badf', NULL, NULL, NULL)
INSERT [dbo].[TBLog] ([Id], [Ip], [Local], [UserAgent], [Browser], [Data], [SessaoId], [EntidadeNome], [EntidadeId], [Acao]) VALUES (65, N'179.179.56.240', N'http://karellendesenv.azurewebsites.net/ocorrencia/nova', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/53.0.2785.143 Safari/537.36', N'Chrome', CAST(N'2016-10-25T19:25:50.540' AS DateTime), N'33847fe8-8798-4463-a6c4-f9508985badf', NULL, NULL, NULL)
INSERT [dbo].[TBLog] ([Id], [Ip], [Local], [UserAgent], [Browser], [Data], [SessaoId], [EntidadeNome], [EntidadeId], [Acao]) VALUES (66, N'179.179.56.240', N'http://karellendesenv.azurewebsites.net/ocorrencia/nova', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/53.0.2785.143 Safari/537.36', N'Chrome', CAST(N'2016-10-25T19:26:03.270' AS DateTime), N'33847fe8-8798-4463-a6c4-f9508985badf', NULL, NULL, NULL)
INSERT [dbo].[TBLog] ([Id], [Ip], [Local], [UserAgent], [Browser], [Data], [SessaoId], [EntidadeNome], [EntidadeId], [Acao]) VALUES (67, N'179.179.56.240', N'http://karellendesenv.azurewebsites.net/ocorrencia/nova', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/53.0.2785.143 Safari/537.36', N'Chrome', CAST(N'2016-10-25T19:26:25.063' AS DateTime), N'33847fe8-8798-4463-a6c4-f9508985badf', NULL, NULL, NULL)
INSERT [dbo].[TBLog] ([Id], [Ip], [Local], [UserAgent], [Browser], [Data], [SessaoId], [EntidadeNome], [EntidadeId], [Acao]) VALUES (68, N'179.179.56.240', N'http://karellendesenv.azurewebsites.net/ocorrencia/nova', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/53.0.2785.143 Safari/537.36', N'Chrome', CAST(N'2016-10-25T19:26:33.103' AS DateTime), N'33847fe8-8798-4463-a6c4-f9508985badf', NULL, NULL, NULL)
INSERT [dbo].[TBLog] ([Id], [Ip], [Local], [UserAgent], [Browser], [Data], [SessaoId], [EntidadeNome], [EntidadeId], [Acao]) VALUES (69, N'179.179.56.240', N'http://karellendesenv.azurewebsites.net/ocorrencia/nova', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/53.0.2785.143 Safari/537.36', N'Chrome', CAST(N'2016-10-25T20:20:51.370' AS DateTime), N'f2c56d1a-fac0-4350-8a2b-eb6dc02b6984', N'Ocorrencia', N'31', N'SalvarNovaOcorrencia')
INSERT [dbo].[TBLog] ([Id], [Ip], [Local], [UserAgent], [Browser], [Data], [SessaoId], [EntidadeNome], [EntidadeId], [Acao]) VALUES (70, N'179.179.56.240', N'http://karellendesenv.azurewebsites.net/ocorrencia/nova', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/53.0.2785.143 Safari/537.36', N'Chrome', CAST(N'2016-10-25T20:21:11.520' AS DateTime), N'260f770a-779b-43e1-854f-e8aa8c200a5f', NULL, NULL, NULL)
INSERT [dbo].[TBLog] ([Id], [Ip], [Local], [UserAgent], [Browser], [Data], [SessaoId], [EntidadeNome], [EntidadeId], [Acao]) VALUES (71, N'179.179.56.240', N'http://karellendesenv.azurewebsites.net/ocorrencia/nova', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/53.0.2785.143 Safari/537.36', N'Chrome', CAST(N'2016-10-25T20:21:20.837' AS DateTime), N'260f770a-779b-43e1-854f-e8aa8c200a5f', NULL, NULL, NULL)
INSERT [dbo].[TBLog] ([Id], [Ip], [Local], [UserAgent], [Browser], [Data], [SessaoId], [EntidadeNome], [EntidadeId], [Acao]) VALUES (72, N'179.179.56.240', N'http://karellendesenv.azurewebsites.net/ocorrencia/nova', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/53.0.2785.143 Safari/537.36', N'Chrome', CAST(N'2016-10-25T20:25:21.520' AS DateTime), N'260f770a-779b-43e1-854f-e8aa8c200a5f', NULL, NULL, NULL)
INSERT [dbo].[TBLog] ([Id], [Ip], [Local], [UserAgent], [Browser], [Data], [SessaoId], [EntidadeNome], [EntidadeId], [Acao]) VALUES (73, N'179.179.56.240', N'http://karellendesenv.azurewebsites.net/ocorrencia/nova', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/53.0.2785.143 Safari/537.36', N'Chrome', CAST(N'2016-10-25T20:31:31.457' AS DateTime), N'75d32909-5554-464b-9320-fcf38e053482', NULL, NULL, NULL)
INSERT [dbo].[TBLog] ([Id], [Ip], [Local], [UserAgent], [Browser], [Data], [SessaoId], [EntidadeNome], [EntidadeId], [Acao]) VALUES (74, N'179.179.56.240', N'http://karellendesenv.azurewebsites.net/ocorrencia/nova', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/53.0.2785.143 Safari/537.36', N'Chrome', CAST(N'2016-10-25T20:31:35.840' AS DateTime), N'75d32909-5554-464b-9320-fcf38e053482', NULL, NULL, NULL)
INSERT [dbo].[TBLog] ([Id], [Ip], [Local], [UserAgent], [Browser], [Data], [SessaoId], [EntidadeNome], [EntidadeId], [Acao]) VALUES (75, N'179.179.56.240', N'http://karellendesenv.azurewebsites.net/ocorrencia/nova', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/53.0.2785.143 Safari/537.36', N'Chrome', CAST(N'2016-10-25T20:31:38.503' AS DateTime), N'75d32909-5554-464b-9320-fcf38e053482', NULL, NULL, NULL)
INSERT [dbo].[TBLog] ([Id], [Ip], [Local], [UserAgent], [Browser], [Data], [SessaoId], [EntidadeNome], [EntidadeId], [Acao]) VALUES (76, N'179.179.56.240', N'http://karellendesenv.azurewebsites.net/ocorrencia/nova', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/53.0.2785.143 Safari/537.36', N'Chrome', CAST(N'2016-10-25T20:40:44.040' AS DateTime), N'75d32909-5554-464b-9320-fcf38e053482', NULL, NULL, NULL)
INSERT [dbo].[TBLog] ([Id], [Ip], [Local], [UserAgent], [Browser], [Data], [SessaoId], [EntidadeNome], [EntidadeId], [Acao]) VALUES (77, N'179.179.56.240', N'http://karellendesenv.azurewebsites.net/ocorrencia/nova', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/53.0.2785.143 Safari/537.36', N'Chrome', CAST(N'2016-10-25T20:41:47.357' AS DateTime), N'75d32909-5554-464b-9320-fcf38e053482', NULL, NULL, NULL)
INSERT [dbo].[TBLog] ([Id], [Ip], [Local], [UserAgent], [Browser], [Data], [SessaoId], [EntidadeNome], [EntidadeId], [Acao]) VALUES (78, N'179.179.56.240', N'http://karellendesenv.azurewebsites.net/ocorrencia/nova', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/53.0.2785.143 Safari/537.36', N'Chrome', CAST(N'2016-10-25T20:41:50.007' AS DateTime), N'75d32909-5554-464b-9320-fcf38e053482', NULL, NULL, NULL)
INSERT [dbo].[TBLog] ([Id], [Ip], [Local], [UserAgent], [Browser], [Data], [SessaoId], [EntidadeNome], [EntidadeId], [Acao]) VALUES (79, N'179.179.56.240', N'http://karellendesenv.azurewebsites.net/ocorrencia/nova', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/53.0.2785.143 Safari/537.36', N'Chrome', CAST(N'2016-10-25T20:41:52.540' AS DateTime), N'75d32909-5554-464b-9320-fcf38e053482', NULL, NULL, NULL)
INSERT [dbo].[TBLog] ([Id], [Ip], [Local], [UserAgent], [Browser], [Data], [SessaoId], [EntidadeNome], [EntidadeId], [Acao]) VALUES (80, N'179.179.56.240', N'http://karellendesenv.azurewebsites.net/ocorrencia/nova', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/53.0.2785.143 Safari/537.36', N'Chrome', CAST(N'2016-10-25T20:41:54.463' AS DateTime), N'75d32909-5554-464b-9320-fcf38e053482', NULL, NULL, NULL)
INSERT [dbo].[TBLog] ([Id], [Ip], [Local], [UserAgent], [Browser], [Data], [SessaoId], [EntidadeNome], [EntidadeId], [Acao]) VALUES (81, N'189.92.246.127', N'http://karellendesenv.azurewebsites.net/ocorrencia/nova', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/54.0.2840.71 Safari/537.36', N'Chrome', CAST(N'2016-10-25T23:46:30.593' AS DateTime), N'0b3e5443-74f0-4c69-9cca-1f380b0e5270', NULL, NULL, NULL)
INSERT [dbo].[TBLog] ([Id], [Ip], [Local], [UserAgent], [Browser], [Data], [SessaoId], [EntidadeNome], [EntidadeId], [Acao]) VALUES (82, N'189.92.246.127', N'http://karellendesenv.azurewebsites.net/ocorrencia/nova', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/54.0.2840.71 Safari/537.36', N'Chrome', CAST(N'2016-10-25T23:46:48.807' AS DateTime), N'0b3e5443-74f0-4c69-9cca-1f380b0e5270', NULL, NULL, NULL)
INSERT [dbo].[TBLog] ([Id], [Ip], [Local], [UserAgent], [Browser], [Data], [SessaoId], [EntidadeNome], [EntidadeId], [Acao]) VALUES (83, N'189.92.246.127', N'http://karellendesenv.azurewebsites.net/ocorrencia/nova', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/54.0.2840.71 Safari/537.36', N'Chrome', CAST(N'2016-10-25T23:46:57.390' AS DateTime), N'0b3e5443-74f0-4c69-9cca-1f380b0e5270', NULL, NULL, NULL)
INSERT [dbo].[TBLog] ([Id], [Ip], [Local], [UserAgent], [Browser], [Data], [SessaoId], [EntidadeNome], [EntidadeId], [Acao]) VALUES (84, N'189.92.246.127', N'http://karellendesenv.azurewebsites.net/ocorrencia/nova', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/54.0.2840.71 Safari/537.36', N'Chrome', CAST(N'2016-10-25T23:47:17.797' AS DateTime), N'0b3e5443-74f0-4c69-9cca-1f380b0e5270', N'Ocorrencia', N'32', N'SalvarNovaOcorrencia')
SET IDENTITY_INSERT [dbo].[TBLog] OFF
INSERT [dbo].[TBLoginExterno] ([LoginProvedor], [KeyProvedor], [UsuarioId]) VALUES (N'Facebook', N'127583407694958', 1)
INSERT [dbo].[TBLoginExterno] ([LoginProvedor], [KeyProvedor], [UsuarioId]) VALUES (N'Google', N'110801123493378357317', 1)
INSERT [dbo].[TBLoginExterno] ([LoginProvedor], [KeyProvedor], [UsuarioId]) VALUES (N'Facebook', N'1381602101864980', 2)
INSERT [dbo].[TBLoginExterno] ([LoginProvedor], [KeyProvedor], [UsuarioId]) VALUES (N'Google', N'101249500457078977946', 3)
SET IDENTITY_INSERT [dbo].[TBOcorrencia] ON 

INSERT [dbo].[TBOcorrencia] ([Id], [Titulo], [DataAcontecimento], [DataCriacao], [DataResolucao], [Excluida], [SexoVitima], [Detalhes], [HaBoletimDeOcorrencia], [Latitude], [Longitude], [UsuarioId]) VALUES (1, N'Ocorrencia', CAST(N'2016-09-25T20:31:00.000' AS DateTime), CAST(N'2016-10-17T20:44:03.563' AS DateTime), CAST(N'2016-10-18T12:12:45.940' AS DateTime), 0, 1, N'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.', 1, N'-15.64091119417735', N'-47.79386032372713', 1)
INSERT [dbo].[TBOcorrencia] ([Id], [Titulo], [DataAcontecimento], [DataCriacao], [DataResolucao], [Excluida], [SexoVitima], [Detalhes], [HaBoletimDeOcorrencia], [Latitude], [Longitude], [UsuarioId]) VALUES (2, N'Ocorrência de Exemplo II', CAST(N'2016-01-29T20:59:00.000' AS DateTime), CAST(N'2016-10-17T21:00:26.943' AS DateTime), NULL, 0, 0, N'All the tools your team needs in one place. Slack: Where work happens.
ads via Carbon', 0, N'-15.642264622818841', N'-47.818415109068155', NULL)
INSERT [dbo].[TBOcorrencia] ([Id], [Titulo], [DataAcontecimento], [DataCriacao], [DataResolucao], [Excluida], [SexoVitima], [Detalhes], [HaBoletimDeOcorrencia], [Latitude], [Longitude], [UsuarioId]) VALUES (5, N'Pertinho', CAST(N'2016-09-25T20:31:00.000' AS DateTime), CAST(N'2016-10-17T21:12:17.893' AS DateTime), CAST(N'2016-10-18T10:30:00.770' AS DateTime), 0, 0, N'asdasdas asdas das das das das da sda sd as', 1, N'-15.64089053107527', N'-47.80526138842106', 1)
INSERT [dbo].[TBOcorrencia] ([Id], [Titulo], [DataAcontecimento], [DataCriacao], [DataResolucao], [Excluida], [SexoVitima], [Detalhes], [HaBoletimDeOcorrencia], [Latitude], [Longitude], [UsuarioId]) VALUES (6, N'12 adas das dasd', CAST(N'2016-10-07T21:12:00.000' AS DateTime), CAST(N'2016-10-17T21:13:01.700' AS DateTime), NULL, 0, 1, N'I am trying to set the maxClusterRadius based on the zoomlevel of the map, but can''t figure out how to do this, as the function that I added to maxClusterRadius is only called once when the markerClusterGroup is created. Is there a way to do that?

Thanks in advance', 0, N'-15.644113949772313', N'-47.802829295396805', NULL)
INSERT [dbo].[TBOcorrencia] ([Id], [Titulo], [DataAcontecimento], [DataCriacao], [DataResolucao], [Excluida], [SexoVitima], [Detalhes], [HaBoletimDeOcorrencia], [Latitude], [Longitude], [UsuarioId]) VALUES (7, N'Ocorrência de exemplo II', CAST(N'2016-01-01T00:00:00.000' AS DateTime), CAST(N'2016-10-18T10:31:17.933' AS DateTime), NULL, 0, 1, N'For performance reasons, the Tooltip and Popover data-apis are opt-in, meaning you must initialize them yourself.

One way to initialize all tooltips on a page would be to select them by their data-toggle attribute:', 1, N'-15.643618042508686', N'-47.78446152806281', NULL)
INSERT [dbo].[TBOcorrencia] ([Id], [Titulo], [DataAcontecimento], [DataCriacao], [DataResolucao], [Excluida], [SexoVitima], [Detalhes], [HaBoletimDeOcorrencia], [Latitude], [Longitude], [UsuarioId]) VALUES (8, N'Pertinho da aula', CAST(N'2016-01-01T12:21:00.000' AS DateTime), CAST(N'2016-10-18T12:21:39.347' AS DateTime), NULL, 0, 0, N'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequ.', 0, N'-15.649899445694144', N'-47.77347519993782', NULL)
INSERT [dbo].[TBOcorrencia] ([Id], [Titulo], [DataAcontecimento], [DataCriacao], [DataResolucao], [Excluida], [SexoVitima], [Detalhes], [HaBoletimDeOcorrencia], [Latitude], [Longitude], [UsuarioId]) VALUES (18, N'Ocorrencia', CAST(N'2016-10-01T17:33:00.000' AS DateTime), CAST(N'2016-10-18T17:33:28.880' AS DateTime), NULL, 0, 0, N'To aguardando aqui Sent on:10/4Seguinte: Queria pedir tua opiniãoSent on:3:28 pmVai ter um hackaton na stefaniniTo pensando em envia', 1, N'-15.63956808820345', N'-47.80208498239517', NULL)
INSERT [dbo].[TBOcorrencia] ([Id], [Titulo], [DataAcontecimento], [DataCriacao], [DataResolucao], [Excluida], [SexoVitima], [Detalhes], [HaBoletimDeOcorrencia], [Latitude], [Longitude], [UsuarioId]) VALUES (19, N'Mais uma', CAST(N'2016-10-01T15:55:00.000' AS DateTime), CAST(N'2016-10-18T15:56:28.943' AS DateTime), NULL, 0, 0, N'The theme is in a way the the height is small therefore the scroll bar disappears. If you have to have a scroll bar try this by adding it under the style type="text/css" tag :', 1, N'-15.633410351066972', N'-47.82465912401676', NULL)
INSERT [dbo].[TBOcorrencia] ([Id], [Titulo], [DataAcontecimento], [DataCriacao], [DataResolucao], [Excluida], [SexoVitima], [Detalhes], [HaBoletimDeOcorrencia], [Latitude], [Longitude], [UsuarioId]) VALUES (24, N'Leaflet 1.0.0', CAST(N'2016-10-19T11:49:00.000' AS DateTime), CAST(N'2016-10-19T11:49:28.813' AS DateTime), CAST(N'2016-10-19T11:50:13.720' AS DateTime), 0, 1, N'dds support for drawing and editing vectors and markers on Leaflet maps. Check out the demo.

Supports Leaflet 0.7.x and 1.0.0+ branches.

Full Demo for Leaflet 1.0.0+:

Full Demo for Leaflet 0.7.0+:

Upgrading from Leaflet.draw 0.1

Leaflet.draw 0.2.0 changes a LOT of things from 0.1. Please see BREAKING CHANGES for how to upgrade.', 1, N'-15.645519013825156', N'-47.78411686420441', 1)
INSERT [dbo].[TBOcorrencia] ([Id], [Titulo], [DataAcontecimento], [DataCriacao], [DataResolucao], [Excluida], [SexoVitima], [Detalhes], [HaBoletimDeOcorrencia], [Latitude], [Longitude], [UsuarioId]) VALUES (25, N'Sobradinho Mil Tretas', CAST(N'2016-10-01T15:59:00.000' AS DateTime), CAST(N'2016-10-18T16:00:04.333' AS DateTime), NULL, 1, 0, N'Like stated above, L.EditToolbar.Edit and L.EditToolbar.Delete expose interesting methods and events like editstart and editstop. What''s not mentioned is that these two classes themselves are derived from L.Handler.', 0, N'-15.64816381409883', N'-47.79098331928253', 1)
INSERT [dbo].[TBOcorrencia] ([Id], [Titulo], [DataAcontecimento], [DataCriacao], [DataResolucao], [Excluida], [SexoVitima], [Detalhes], [HaBoletimDeOcorrencia], [Latitude], [Longitude], [UsuarioId]) VALUES (26, N'Pertinho X', CAST(N'2016-10-01T12:18:00.000' AS DateTime), CAST(N'2016-10-19T12:19:22.807' AS DateTime), CAST(N'2016-10-19T12:19:49.817' AS DateTime), 0, 0, N'You can add a simple marker to your map with L.marker. In the example below, we added a marker to the map just by knowing its coordinates. This technique is great for when you have only a few markers to add.', 0, N'-15.665478145842503', N'-47.80427433550358', 1)
INSERT [dbo].[TBOcorrencia] ([Id], [Titulo], [DataAcontecimento], [DataCriacao], [DataResolucao], [Excluida], [SexoVitima], [Detalhes], [HaBoletimDeOcorrencia], [Latitude], [Longitude], [UsuarioId]) VALUES (27, N'Assaltado no DNOCS', CAST(N'2016-01-12T15:13:00.000' AS DateTime), CAST(N'2016-10-19T17:14:05.207' AS DateTime), NULL, 0, 0, N'KARELLEN

Feito por cidadãos. Para cidadãos.
Ir para o mapa
', 1, N'-15.662626960582163', N'-47.800233252346516', NULL)
INSERT [dbo].[TBOcorrencia] ([Id], [Titulo], [DataAcontecimento], [DataCriacao], [DataResolucao], [Excluida], [SexoVitima], [Detalhes], [HaBoletimDeOcorrencia], [Latitude], [Longitude], [UsuarioId]) VALUES (28, N'teste', CAST(N'2016-12-10T16:54:00.000' AS DateTime), CAST(N'2016-10-25T19:19:15.717' AS DateTime), CAST(N'2016-10-25T19:21:04.763' AS DateTime), 0, 0, N'teste', 1, N'-15.647339196148616', N'-47.80221348220948', 3)
INSERT [dbo].[TBOcorrencia] ([Id], [Titulo], [DataAcontecimento], [DataCriacao], [DataResolucao], [Excluida], [SexoVitima], [Detalhes], [HaBoletimDeOcorrencia], [Latitude], [Longitude], [UsuarioId]) VALUES (29, N'teste 2', CAST(N'2016-01-10T13:22:00.000' AS DateTime), CAST(N'2016-10-25T19:23:02.473' AS DateTime), NULL, 0, 0, N'test e2 ', 1, N'-15.647835094392153', N'-47.80599003250245', NULL)
INSERT [dbo].[TBOcorrencia] ([Id], [Titulo], [DataAcontecimento], [DataCriacao], [DataResolucao], [Excluida], [SexoVitima], [Detalhes], [HaBoletimDeOcorrencia], [Latitude], [Longitude], [UsuarioId]) VALUES (30, N'teste 3', CAST(N'2016-06-09T17:24:00.000' AS DateTime), CAST(N'2016-10-25T19:24:22.797' AS DateTime), CAST(N'2016-10-25T19:24:37.280' AS DateTime), 0, 0, N'teste 3', 1, N'-15.648000393539508', N'-47.811826519318856', 3)
INSERT [dbo].[TBOcorrencia] ([Id], [Titulo], [DataAcontecimento], [DataCriacao], [DataResolucao], [Excluida], [SexoVitima], [Detalhes], [HaBoletimDeOcorrencia], [Latitude], [Longitude], [UsuarioId]) VALUES (31, N'data e horas 1', CAST(N'2016-12-10T18:30:00.000' AS DateTime), CAST(N'2016-10-25T20:20:51.450' AS DateTime), NULL, 0, 0, N'data e horas 1', 1, N'-15.64700859665171', N'-47.804445080109865', NULL)
INSERT [dbo].[TBOcorrencia] ([Id], [Titulo], [DataAcontecimento], [DataCriacao], [DataResolucao], [Excluida], [SexoVitima], [Detalhes], [HaBoletimDeOcorrencia], [Latitude], [Longitude], [UsuarioId]) VALUES (32, N'dsexesxws', CAST(N'2016-01-01T21:46:00.000' AS DateTime), CAST(N'2016-10-25T23:47:17.813' AS DateTime), NULL, 0, 0, N'edxedxedxedx', 1, N'-15.645519013825156', N'-47.784403860569', 1)
SET IDENTITY_INSERT [dbo].[TBOcorrencia] OFF
INSERT [dbo].[TBTipoOcorrencia] ([OcorrenciaId], [Tipo]) VALUES (1, 0)
INSERT [dbo].[TBTipoOcorrencia] ([OcorrenciaId], [Tipo]) VALUES (1, 1)
INSERT [dbo].[TBTipoOcorrencia] ([OcorrenciaId], [Tipo]) VALUES (2, 0)
INSERT [dbo].[TBTipoOcorrencia] ([OcorrenciaId], [Tipo]) VALUES (2, 1)
INSERT [dbo].[TBTipoOcorrencia] ([OcorrenciaId], [Tipo]) VALUES (2, 3)
INSERT [dbo].[TBTipoOcorrencia] ([OcorrenciaId], [Tipo]) VALUES (2, 4)
INSERT [dbo].[TBTipoOcorrencia] ([OcorrenciaId], [Tipo]) VALUES (5, 0)
INSERT [dbo].[TBTipoOcorrencia] ([OcorrenciaId], [Tipo]) VALUES (6, 0)
INSERT [dbo].[TBTipoOcorrencia] ([OcorrenciaId], [Tipo]) VALUES (7, 0)
INSERT [dbo].[TBTipoOcorrencia] ([OcorrenciaId], [Tipo]) VALUES (7, 1)
INSERT [dbo].[TBTipoOcorrencia] ([OcorrenciaId], [Tipo]) VALUES (7, 2)
INSERT [dbo].[TBTipoOcorrencia] ([OcorrenciaId], [Tipo]) VALUES (7, 3)
INSERT [dbo].[TBTipoOcorrencia] ([OcorrenciaId], [Tipo]) VALUES (7, 4)
INSERT [dbo].[TBTipoOcorrencia] ([OcorrenciaId], [Tipo]) VALUES (8, 0)
INSERT [dbo].[TBTipoOcorrencia] ([OcorrenciaId], [Tipo]) VALUES (18, 0)
INSERT [dbo].[TBTipoOcorrencia] ([OcorrenciaId], [Tipo]) VALUES (18, 1)
INSERT [dbo].[TBTipoOcorrencia] ([OcorrenciaId], [Tipo]) VALUES (18, 2)
INSERT [dbo].[TBTipoOcorrencia] ([OcorrenciaId], [Tipo]) VALUES (19, 0)
INSERT [dbo].[TBTipoOcorrencia] ([OcorrenciaId], [Tipo]) VALUES (19, 1)
INSERT [dbo].[TBTipoOcorrencia] ([OcorrenciaId], [Tipo]) VALUES (19, 2)
INSERT [dbo].[TBTipoOcorrencia] ([OcorrenciaId], [Tipo]) VALUES (19, 3)
INSERT [dbo].[TBTipoOcorrencia] ([OcorrenciaId], [Tipo]) VALUES (24, 0)
INSERT [dbo].[TBTipoOcorrencia] ([OcorrenciaId], [Tipo]) VALUES (24, 1)
INSERT [dbo].[TBTipoOcorrencia] ([OcorrenciaId], [Tipo]) VALUES (24, 2)
INSERT [dbo].[TBTipoOcorrencia] ([OcorrenciaId], [Tipo]) VALUES (25, 0)
INSERT [dbo].[TBTipoOcorrencia] ([OcorrenciaId], [Tipo]) VALUES (25, 1)
INSERT [dbo].[TBTipoOcorrencia] ([OcorrenciaId], [Tipo]) VALUES (25, 2)
INSERT [dbo].[TBTipoOcorrencia] ([OcorrenciaId], [Tipo]) VALUES (25, 6)
INSERT [dbo].[TBTipoOcorrencia] ([OcorrenciaId], [Tipo]) VALUES (25, 7)
INSERT [dbo].[TBTipoOcorrencia] ([OcorrenciaId], [Tipo]) VALUES (26, 0)
INSERT [dbo].[TBTipoOcorrencia] ([OcorrenciaId], [Tipo]) VALUES (26, 1)
INSERT [dbo].[TBTipoOcorrencia] ([OcorrenciaId], [Tipo]) VALUES (27, 0)
INSERT [dbo].[TBTipoOcorrencia] ([OcorrenciaId], [Tipo]) VALUES (27, 1)
INSERT [dbo].[TBTipoOcorrencia] ([OcorrenciaId], [Tipo]) VALUES (28, 2)
INSERT [dbo].[TBTipoOcorrencia] ([OcorrenciaId], [Tipo]) VALUES (29, 2)
INSERT [dbo].[TBTipoOcorrencia] ([OcorrenciaId], [Tipo]) VALUES (29, 3)
INSERT [dbo].[TBTipoOcorrencia] ([OcorrenciaId], [Tipo]) VALUES (30, 3)
INSERT [dbo].[TBTipoOcorrencia] ([OcorrenciaId], [Tipo]) VALUES (31, 1)
INSERT [dbo].[TBTipoOcorrencia] ([OcorrenciaId], [Tipo]) VALUES (32, 0)
SET IDENTITY_INSERT [dbo].[TBUsuario] ON 

INSERT [dbo].[TBUsuario] ([Id], [Nome], [Sobrenome], [Username], [Email], [Senha], [Cidade]) VALUES (1, N'Daniel', N'Ramos', N'DR636123330573468383', N'ramos.danielferreira@gmail.com', NULL, NULL)
INSERT [dbo].[TBUsuario] ([Id], [Nome], [Sobrenome], [Username], [Email], [Senha], [Cidade]) VALUES (2, N'Lucas', N'Coelho', N'LC636129740080209542', N'llucas__@hotmail.com', NULL, NULL)
INSERT [dbo].[TBUsuario] ([Id], [Nome], [Sobrenome], [Username], [Email], [Senha], [Cidade]) VALUES (3, N'lucas', N'araújo coelho', N'LA636130114099119372', N'lgatomsn@gmail.com', NULL, NULL)
SET IDENTITY_INSERT [dbo].[TBUsuario] OFF
INSERT [dbo].[TBUsuarioGrupo] ([GrupoId], [UsuarioId]) VALUES (1, 1)
/****** Object:  Index [IX_UsuarioId]    Script Date: 26/10/2016 09:55:59 ******/
CREATE NONCLUSTERED INDEX [IX_UsuarioId] ON [dbo].[TBLoginExterno]
(
	[UsuarioId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
/****** Object:  Index [IX_UsuarioId]    Script Date: 26/10/2016 09:55:59 ******/
CREATE NONCLUSTERED INDEX [IX_UsuarioId] ON [dbo].[TBOcorrencia]
(
	[UsuarioId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
/****** Object:  Index [IX_OcorrenciaId]    Script Date: 26/10/2016 09:55:59 ******/
CREATE NONCLUSTERED INDEX [IX_OcorrenciaId] ON [dbo].[TBTipoOcorrencia]
(
	[OcorrenciaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
/****** Object:  Index [IX_GrupoId]    Script Date: 26/10/2016 09:55:59 ******/
CREATE NONCLUSTERED INDEX [IX_GrupoId] ON [dbo].[TBUsuarioGrupo]
(
	[GrupoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
/****** Object:  Index [IX_UsuarioId]    Script Date: 26/10/2016 09:55:59 ******/
CREATE NONCLUSTERED INDEX [IX_UsuarioId] ON [dbo].[TBUsuarioGrupo]
(
	[UsuarioId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
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
GO
USE [master]
GO
ALTER DATABASE [KARELLEN] SET  READ_WRITE 
GO
