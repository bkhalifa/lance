
/****** Object:  StoredProcedure [dbo].[OfferSearchEngine]    Script Date: 04/07/2023 00:29:48 ******/
DROP PROCEDURE [dbo].[OfferSearchEngine]
GO
/****** Object:  Table [dbo].[OffersSearch]    Script Date: 04/07/2023 00:29:48 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[OffersSearch]') AND type in (N'U'))
DROP TABLE [dbo].[OffersSearch]
GO
/****** Object:  Table [config].[Seniorities]    Script Date: 04/07/2023 00:29:48 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[config].[Seniorities]') AND type in (N'U'))
DROP TABLE [config].[Seniorities]
GO
/****** Object:  Table [config].[Seniorities]    Script Date: 04/07/2023 00:29:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [config].[Seniorities](
	[Id] [smallint] IDENTITY(1,1) NOT NULL,
	[Code] [nvarchar](50) NULL,
	[Name] [nvarchar](50) NULL,
 CONSTRAINT [PK_Seniorities] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OffersSearch]    Script Date: 04/07/2023 00:29:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OffersSearch](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](100) NULL,
	[Description] [nvarchar](500) NULL,
	[CustomerName] [nvarchar](100) NULL,
	[AmountMin] [decimal](18, 0) NULL,
	[AmountMax] [decimal](18, 0) NULL,
	[AmountUnit] [varchar](5) NULL,
	[Duration] [int] NULL,
	[LocationCode] [nvarchar](100) NULL,
	[LocationName] [nvarchar](50) NULL,
	[ContractTypeCode] [nvarchar](50) NULL,
	[SeniorityCode] [nvarchar](50) NULL,
	[WorkTypeCode] [nvarchar](100) NULL,
	[SkillCodes] [nvarchar](500) NULL,
	[SkillNames] [nvarchar](500) NULL,
	[CreatedDate] [datetime] NULL,
	[PublicationDate] [datetime] NULL,
 CONSTRAINT [PK_OffersSearch] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [config].[Seniorities] ON 
GO
INSERT [config].[Seniorities] ([Id], [Code], [Name]) VALUES (1, N'junior', N'Junior')
GO
INSERT [config].[Seniorities] ([Id], [Code], [Name]) VALUES (2, N'senior', N'Senior')
GO
INSERT [config].[Seniorities] ([Id], [Code], [Name]) VALUES (3, N'intermediate', N'Intermediate')
GO
INSERT [config].[Seniorities] ([Id], [Code], [Name]) VALUES (4, N'trainee', N'Trainee')
GO
INSERT [config].[Seniorities] ([Id], [Code], [Name]) VALUES (5, N'expert', N'Expert')
GO
SET IDENTITY_INSERT [config].[Seniorities] OFF
GO
SET IDENTITY_INSERT [dbo].[OffersSearch] ON 
GO
INSERT [dbo].[OffersSearch] ([Id], [Title], [Description], [CustomerName], [AmountMin], [AmountMax], [AmountUnit], [Duration], [LocationCode], [LocationName], [ContractTypeCode], [SeniorityCode], [WorkTypeCode], [SkillCodes], [SkillNames], [CreatedDate], [PublicationDate]) VALUES (1585, N'Developpeur .net', N'Nous recherchons pour l’un de nos client un développeur. Net dans le cadre d’une mission longue.', N'RFB Innovation', CAST(400 AS Decimal(18, 0)), CAST(500 AS Decimal(18, 0)), N'1', 12, N'paris|paris|ile-de-france', N'Paris', N'freelance', N'junior', N'hybrid', N'net|angular', N'.Net|Angular', CAST(N'2022-09-14T14:00:00.000' AS DateTime), CAST(N'2022-09-14T14:00:00.000' AS DateTime))
GO
INSERT [dbo].[OffersSearch] ([Id], [Title], [Description], [CustomerName], [AmountMin], [AmountMax], [AmountUnit], [Duration], [LocationCode], [LocationName], [ContractTypeCode], [SeniorityCode], [WorkTypeCode], [SkillCodes], [SkillNames], [CreatedDate], [PublicationDate]) VALUES (1586, N'Chef de projet MOA Décisionnel', N'La prestation prendra place au sein du pôle Data Factory dont la mission d’assurer l’ensemble des activités IT des SI Décisionnels du Groupe.', N'Bam engineering', CAST(80000 AS Decimal(18, 0)), CAST(100000 AS Decimal(18, 0)), N'3', NULL, N'marseille|bouches-du-rhone|provence-alpes-cote-d-azur', N'Marseille', N'cdi', N'intermediate', N'remote', N'sql', N'Sql Server', CAST(N'2022-10-14T15:00:00.000' AS DateTime), CAST(N'2022-10-14T15:00:00.000' AS DateTime))
GO
INSERT [dbo].[OffersSearch] ([Id], [Title], [Description], [CustomerName], [AmountMin], [AmountMax], [AmountUnit], [Duration], [LocationCode], [LocationName], [ContractTypeCode], [SeniorityCode], [WorkTypeCode], [SkillCodes], [SkillNames], [CreatedDate], [PublicationDate]) VALUES (1592, N'Dévéloppeur Angular', N'Fyte Dev & Technology est spécialisé dans le sourcing, l''évaluation et le recrutement en intérim, CDD et CDI de profils techniques pour les métiers de l''IT. Les consultants Fyte Dev & Technology sont ultra-spécialisés par métiers et possèdent une approche qui concilie une connaissance approfondie des nouvelles technologies et des métiers de l''informatique, du développement et des systèmes d''information.', N'FYTE', CAST(20000 AS Decimal(18, 0)), CAST(40000 AS Decimal(18, 0)), N'3', 6, N'puteaux|bouches-du-rhone|ile-de-france', N'Puteaux', N'cdd', N'senior', N'site', N'java|c#|c++', N'Java|C#|C++', CAST(N'2022-10-14T10:00:00.000' AS DateTime), CAST(N'2022-10-14T10:00:00.000' AS DateTime))
GO
INSERT [dbo].[OffersSearch] ([Id], [Title], [Description], [CustomerName], [AmountMin], [AmountMax], [AmountUnit], [Duration], [LocationCode], [LocationName], [ContractTypeCode], [SeniorityCode], [WorkTypeCode], [SkillCodes], [SkillNames], [CreatedDate], [PublicationDate]) VALUES (1593, N'Developpeur .net', N'Nous recherchons pour l’un de nos client un développeur. Net dans le cadre d’une mission longue.', N'RFB Innovation', CAST(400 AS Decimal(18, 0)), CAST(500 AS Decimal(18, 0)), N'1', 12, N'paris|paris|ile-de-france', N'Paris', N'freelance', N'intermediate', N'hybrid', N'net|angular', N'.Net|Angular', CAST(N'2022-09-14T08:00:00.000' AS DateTime), CAST(N'2022-09-14T08:00:00.000' AS DateTime))
GO
INSERT [dbo].[OffersSearch] ([Id], [Title], [Description], [CustomerName], [AmountMin], [AmountMax], [AmountUnit], [Duration], [LocationCode], [LocationName], [ContractTypeCode], [SeniorityCode], [WorkTypeCode], [SkillCodes], [SkillNames], [CreatedDate], [PublicationDate]) VALUES (1594, N'Chef de projet MOA Décisionnel', N'La prestation prendra place au sein du pôle Data Factory dont la mission d’assurer l’ensemble des activités IT des SI Décisionnels du Groupe.', N'Bam engineering', CAST(80000 AS Decimal(18, 0)), CAST(100000 AS Decimal(18, 0)), N'3', NULL, N'marseille|bouches-du-rhone|provence-alpes-cote-d-azur', N'Marseille', N'cdi', N'senior', N'remote', N'sql', N'Sql Server', CAST(N'2022-10-14T09:00:00.000' AS DateTime), CAST(N'2022-10-14T09:00:00.000' AS DateTime))
GO
INSERT [dbo].[OffersSearch] ([Id], [Title], [Description], [CustomerName], [AmountMin], [AmountMax], [AmountUnit], [Duration], [LocationCode], [LocationName], [ContractTypeCode], [SeniorityCode], [WorkTypeCode], [SkillCodes], [SkillNames], [CreatedDate], [PublicationDate]) VALUES (1595, N'Dévéloppeur Angular', N'Fyte Dev & Technology est spécialisé dans le sourcing, l''évaluation et le recrutement en intérim, CDD et CDI de profils techniques pour les métiers de l''IT. Les consultants Fyte Dev & Technology sont ultra-spécialisés par métiers et possèdent une approche qui concilie une connaissance approfondie des nouvelles technologies et des métiers de l''informatique, du développement et des systèmes d''information.', N'FYTE', CAST(20000 AS Decimal(18, 0)), CAST(40000 AS Decimal(18, 0)), N'3', 6, N'puteaux|bouches-du-rhone|ile-de-france', N'Puteaux', N'cdd', N'junior', N'site', N'java|c#|c++', N'Java|C#|C++', CAST(N'2022-10-14T11:00:00.000' AS DateTime), CAST(N'2022-10-14T11:00:00.000' AS DateTime))
GO
INSERT [dbo].[OffersSearch] ([Id], [Title], [Description], [CustomerName], [AmountMin], [AmountMax], [AmountUnit], [Duration], [LocationCode], [LocationName], [ContractTypeCode], [SeniorityCode], [WorkTypeCode], [SkillCodes], [SkillNames], [CreatedDate], [PublicationDate]) VALUES (1596, N'Developpeur .net', N'Nous recherchons pour l’un de nos client un développeur. Net dans le cadre d’une mission longue.', N'RFB Innovation', CAST(400 AS Decimal(18, 0)), CAST(500 AS Decimal(18, 0)), N'1', 12, N'paris|paris|ile-de-france', N'Paris', N'freelance', N'senior', N'hybrid', N'net|angular', N'.Net|Angular', CAST(N'2022-09-14T13:00:00.000' AS DateTime), CAST(N'2022-09-14T13:00:00.000' AS DateTime))
GO
INSERT [dbo].[OffersSearch] ([Id], [Title], [Description], [CustomerName], [AmountMin], [AmountMax], [AmountUnit], [Duration], [LocationCode], [LocationName], [ContractTypeCode], [SeniorityCode], [WorkTypeCode], [SkillCodes], [SkillNames], [CreatedDate], [PublicationDate]) VALUES (1597, N'Chef de projet MOA Décisionnel', N'La prestation prendra place au sein du pôle Data Factory dont la mission d’assurer l’ensemble des activités IT des SI Décisionnels du Groupe.', N'Bam engineering', CAST(80000 AS Decimal(18, 0)), CAST(100000 AS Decimal(18, 0)), N'3', NULL, N'marseille|bouches-du-rhone|provence-alpes-cote-d-azur', N'Marseille', N'cdi', N'intermediate', N'remote', N'sql', N'Sql Server', CAST(N'2022-10-14T22:00:00.000' AS DateTime), CAST(N'2022-10-14T22:00:00.000' AS DateTime))
GO
INSERT [dbo].[OffersSearch] ([Id], [Title], [Description], [CustomerName], [AmountMin], [AmountMax], [AmountUnit], [Duration], [LocationCode], [LocationName], [ContractTypeCode], [SeniorityCode], [WorkTypeCode], [SkillCodes], [SkillNames], [CreatedDate], [PublicationDate]) VALUES (1598, N'Dévéloppeur Angular', N'Fyte Dev & Technology est spécialisé dans le sourcing, l''évaluation et le recrutement en intérim, CDD et CDI de profils techniques pour les métiers de l''IT. Les consultants Fyte Dev & Technology sont ultra-spécialisés par métiers et possèdent une approche qui concilie une connaissance approfondie des nouvelles technologies et des métiers de l''informatique, du développement et des systèmes d''information.', N'FYTE', CAST(20000 AS Decimal(18, 0)), CAST(40000 AS Decimal(18, 0)), N'3', 6, N'puteaux|bouches-du-rhone|ile-de-france', N'Puteaux', N'cdd', N'intermediate', N'site', N'java|c#|c++', N'Java|C#|C++', CAST(N'2022-10-14T11:00:00.000' AS DateTime), CAST(N'2022-10-14T11:00:00.000' AS DateTime))
GO
INSERT [dbo].[OffersSearch] ([Id], [Title], [Description], [CustomerName], [AmountMin], [AmountMax], [AmountUnit], [Duration], [LocationCode], [LocationName], [ContractTypeCode], [SeniorityCode], [WorkTypeCode], [SkillCodes], [SkillNames], [CreatedDate], [PublicationDate]) VALUES (1599, N'Developpeur .net', N'Nous recherchons pour l’un de nos client un développeur. Net dans le cadre d’une mission longue.', N'RFB Innovation', CAST(400 AS Decimal(18, 0)), CAST(500 AS Decimal(18, 0)), N'1', 12, N'paris|paris|ile-de-france', N'Paris', N'freelance', N'senior', N'hybrid', N'net|angular', N'.Net|Angular', CAST(N'2022-09-14T20:00:00.000' AS DateTime), CAST(N'2022-09-14T20:00:00.000' AS DateTime))
GO
INSERT [dbo].[OffersSearch] ([Id], [Title], [Description], [CustomerName], [AmountMin], [AmountMax], [AmountUnit], [Duration], [LocationCode], [LocationName], [ContractTypeCode], [SeniorityCode], [WorkTypeCode], [SkillCodes], [SkillNames], [CreatedDate], [PublicationDate]) VALUES (1600, N'Developpeur .net', N'Nous recherchons pour l’un de nos client un développeur. Net dans le cadre d’une mission longue.', N'RFB Innovation', CAST(400 AS Decimal(18, 0)), CAST(500 AS Decimal(18, 0)), N'1', 12, N'paris|paris|ile-de-france', N'Paris', N'freelance', N'junior', N'hybrid', N'net|angular', N'.Net|Angular', CAST(N'2022-09-14T21:00:00.000' AS DateTime), CAST(N'2022-09-14T21:00:00.000' AS DateTime))
GO
INSERT [dbo].[OffersSearch] ([Id], [Title], [Description], [CustomerName], [AmountMin], [AmountMax], [AmountUnit], [Duration], [LocationCode], [LocationName], [ContractTypeCode], [SeniorityCode], [WorkTypeCode], [SkillCodes], [SkillNames], [CreatedDate], [PublicationDate]) VALUES (1601, N'Chef de projet MOA Décisionnel', N'La prestation prendra place au sein du pôle Data Factory dont la mission d’assurer l’ensemble des activités IT des SI Décisionnels du Groupe.', N'Bam engineering', CAST(80000 AS Decimal(18, 0)), CAST(100000 AS Decimal(18, 0)), N'3', NULL, N'marseille|bouches-du-rhone|provence-alpes-cote-d-azur', N'Marseille', N'cdi', N'senior', N'remote', N'sql', N'Sql Server', CAST(N'2022-10-14T00:00:00.000' AS DateTime), CAST(N'2022-10-14T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[OffersSearch] ([Id], [Title], [Description], [CustomerName], [AmountMin], [AmountMax], [AmountUnit], [Duration], [LocationCode], [LocationName], [ContractTypeCode], [SeniorityCode], [WorkTypeCode], [SkillCodes], [SkillNames], [CreatedDate], [PublicationDate]) VALUES (1602, N'Dévéloppeur Angular', N'Fyte Dev & Technology est spécialisé dans le sourcing, l''évaluation et le recrutement en intérim, CDD et CDI de profils techniques pour les métiers de l''IT. Les consultants Fyte Dev & Technology sont ultra-spécialisés par métiers et possèdent une approche qui concilie une connaissance approfondie des nouvelles technologies et des métiers de l''informatique, du développement et des systèmes d''information.', N'FYTE', CAST(20000 AS Decimal(18, 0)), CAST(40000 AS Decimal(18, 0)), N'3', 6, N'puteaux|bouches-du-rhone|ile-de-france', N'Puteaux', N'cdd', N'senior', N'site', N'java|c#|c++', N'Java|C#|C++', CAST(N'2022-10-14T00:00:00.000' AS DateTime), CAST(N'2022-10-14T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[OffersSearch] ([Id], [Title], [Description], [CustomerName], [AmountMin], [AmountMax], [AmountUnit], [Duration], [LocationCode], [LocationName], [ContractTypeCode], [SeniorityCode], [WorkTypeCode], [SkillCodes], [SkillNames], [CreatedDate], [PublicationDate]) VALUES (1603, N'Developpeur .net', N'Nous recherchons pour l’un de nos client un développeur. Net dans le cadre d’une mission longue.', N'RFB Innovation', CAST(400 AS Decimal(18, 0)), CAST(500 AS Decimal(18, 0)), N'1', 12, N'paris|paris|ile-de-france', N'Paris', N'freelance', N'junior', N'hybrid', N'net|angular', N'.Net|Angular', CAST(N'2022-09-14T00:00:00.000' AS DateTime), CAST(N'2022-09-14T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[OffersSearch] ([Id], [Title], [Description], [CustomerName], [AmountMin], [AmountMax], [AmountUnit], [Duration], [LocationCode], [LocationName], [ContractTypeCode], [SeniorityCode], [WorkTypeCode], [SkillCodes], [SkillNames], [CreatedDate], [PublicationDate]) VALUES (1604, N'Chef de projet MOA Décisionnel', N'La prestation prendra place au sein du pôle Data Factory dont la mission d’assurer l’ensemble des activités IT des SI Décisionnels du Groupe.', N'Bam engineering', CAST(80000 AS Decimal(18, 0)), CAST(100000 AS Decimal(18, 0)), N'3', NULL, N'marseille|bouches-du-rhone|provence-alpes-cote-d-azur', N'Marseille', N'cdi', N'junior', N'remote', N'sql', N'Sql Server', CAST(N'2022-10-14T00:00:00.000' AS DateTime), CAST(N'2022-10-14T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[OffersSearch] ([Id], [Title], [Description], [CustomerName], [AmountMin], [AmountMax], [AmountUnit], [Duration], [LocationCode], [LocationName], [ContractTypeCode], [SeniorityCode], [WorkTypeCode], [SkillCodes], [SkillNames], [CreatedDate], [PublicationDate]) VALUES (1605, N'Dévéloppeur Angular', N'Fyte Dev & Technology est spécialisé dans le sourcing, l''évaluation et le recrutement en intérim, CDD et CDI de profils techniques pour les métiers de l''IT. Les consultants Fyte Dev & Technology sont ultra-spécialisés par métiers et possèdent une approche qui concilie une connaissance approfondie des nouvelles technologies et des métiers de l''informatique, du développement et des systèmes d''information.', N'FYTE', CAST(20000 AS Decimal(18, 0)), CAST(40000 AS Decimal(18, 0)), N'3', 6, N'puteaux|bouches-du-rhone|ile-de-france', N'Puteaux', N'cdd', N'junior', N'site', N'java|c#|c++', N'Java|C#|C++', CAST(N'2022-10-14T00:00:00.000' AS DateTime), CAST(N'2022-10-14T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[OffersSearch] ([Id], [Title], [Description], [CustomerName], [AmountMin], [AmountMax], [AmountUnit], [Duration], [LocationCode], [LocationName], [ContractTypeCode], [SeniorityCode], [WorkTypeCode], [SkillCodes], [SkillNames], [CreatedDate], [PublicationDate]) VALUES (1606, N'Developpeur .net', N'Nous recherchons pour l’un de nos client un développeur. Net dans le cadre d’une mission longue.', N'RFB Innovation', CAST(400 AS Decimal(18, 0)), CAST(500 AS Decimal(18, 0)), N'1', 12, N'paris|paris|ile-de-france', N'Paris', N'freelance', N'senior', N'hybrid', N'net|angular', N'.Net|Angular', CAST(N'2022-09-14T00:00:00.000' AS DateTime), CAST(N'2022-09-14T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[OffersSearch] ([Id], [Title], [Description], [CustomerName], [AmountMin], [AmountMax], [AmountUnit], [Duration], [LocationCode], [LocationName], [ContractTypeCode], [SeniorityCode], [WorkTypeCode], [SkillCodes], [SkillNames], [CreatedDate], [PublicationDate]) VALUES (1607, N'Chef de projet MOA Décisionnel', N'La prestation prendra place au sein du pôle Data Factory dont la mission d’assurer l’ensemble des activités IT des SI Décisionnels du Groupe.', N'Bam engineering', CAST(80000 AS Decimal(18, 0)), CAST(100000 AS Decimal(18, 0)), N'3', NULL, N'marseille|bouches-du-rhone|provence-alpes-cote-d-azur', N'Marseille', N'cdi', N'intermediate', N'remote', N'sql', N'Sql Server', CAST(N'2022-10-14T00:00:00.000' AS DateTime), CAST(N'2022-10-14T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[OffersSearch] ([Id], [Title], [Description], [CustomerName], [AmountMin], [AmountMax], [AmountUnit], [Duration], [LocationCode], [LocationName], [ContractTypeCode], [SeniorityCode], [WorkTypeCode], [SkillCodes], [SkillNames], [CreatedDate], [PublicationDate]) VALUES (1608, N'Dévéloppeur Angular', N'Fyte Dev & Technology est spécialisé dans le sourcing, l''évaluation et le recrutement en intérim, CDD et CDI de profils techniques pour les métiers de l''IT. Les consultants Fyte Dev & Technology sont ultra-spécialisés par métiers et possèdent une approche qui concilie une connaissance approfondie des nouvelles technologies et des métiers de l''informatique, du développement et des systèmes d''information.', N'FYTE', CAST(20000 AS Decimal(18, 0)), CAST(40000 AS Decimal(18, 0)), N'3', 6, N'puteaux|bouches-du-rhone|ile-de-france', N'Puteaux', N'cdd', N'senior', N'site', N'java|c#|c++', N'Java|C#|C++', CAST(N'2022-10-14T00:00:00.000' AS DateTime), CAST(N'2022-10-14T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[OffersSearch] ([Id], [Title], [Description], [CustomerName], [AmountMin], [AmountMax], [AmountUnit], [Duration], [LocationCode], [LocationName], [ContractTypeCode], [SeniorityCode], [WorkTypeCode], [SkillCodes], [SkillNames], [CreatedDate], [PublicationDate]) VALUES (1609, N'Developpeur .net', N'Nous recherchons pour l’un de nos client un développeur. Net dans le cadre d’une mission longue.', N'RFB Innovation', CAST(400 AS Decimal(18, 0)), CAST(500 AS Decimal(18, 0)), N'1', 12, N'paris|paris|ile-de-france', N'Paris', N'freelance', N'junior', N'hybrid', N'net|angular', N'.Net|Angular', CAST(N'2022-09-14T00:00:00.000' AS DateTime), CAST(N'2022-09-14T00:00:00.000' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[OffersSearch] OFF
GO
/****** Object:  StoredProcedure [dbo].[OfferSearchEngine]    Script Date: 04/07/2023 00:29:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Bessem Zbidi
-- Create date: 01/09/2022
-- Description:	Search Job offers 
-- =============================================
CREATE  PROCEDURE [dbo].[OfferSearchEngine]
	@SearchText VARCHAR(250)= null,  -- Gloabl filter	
	@LocationCodes VARCHAR(250)= null,
	@ContractTypeCodes VARCHAR(250) = null,
	@SkillCodes VARCHAR(500) = null,
	@SeniorityCodes VARCHAR(500) = null,
	@WorkTypeCodes VARCHAR(250) = null,
	@DailyRateMin DECIMAL(18,0)= null,
	@SalaryMin DECIMAL(18,0)= null,
	@PageIndex INT = 1,
	@PageSize INT= 10,
	@OrderBy  INT = 1

AS
BEGIN
    SET NOCOUNT ON;
	
	CREATE TABLE #tmpContractTypes (code VARCHAR(100))
	INSERT INTO #tmpContractTypes 
	SELECT VALUE FROM string_split(@ContractTypeCodes,'|')

	CREATE TABLE #tmpWorkTypeCodes (code VARCHAR(100))
	INSERT INTO #tmpWorkTypeCodes 
	SELECT VALUE FROM string_split(@WorkTypeCodes,'|')

	CREATE TABLE #tmpSkillCodes (code VARCHAR(100))
	INSERT INTO #tmpSkillCodes 
	SELECT VALUE FROM string_split(@SkillCodes,'|')

	CREATE TABLE #tmpWSeniorityCodes (code VARCHAR(100))
	INSERT INTO #tmpWSeniorityCodes 
	SELECT VALUE FROM string_split(@SeniorityCodes,'|')

	;WITH CTE_Results
		AS (
			SELECT ROW_NUMBER() OVER (ORDER BY
				CASE WHEN @OrderBy = 1 THEN PublicationDate END DESC, --Date desc
				CASE WHEN @OrderBy = 2 THEN PublicationDate END ASC, --Date asc
				CASE WHEN @OrderBy = 3 THEN ID END DESC) AS RowNumber,  --Date Relevant
			    Id,
				CustomerName,
				Title,
				Description,
				LocationName,
				AmountMin,
				AmountMax,
				AmountUnit,
				WorkTypeCode,
				SkillNames,
				ContractTypeCode,
				SeniorityCode,
				PublicationDate,
				Duration,
				CreatedDate

			FROM dbo.OffersSearch os OUTER APPLY string_split(@SearchText,' ') a	
								     OUTER APPLY string_split(@SkillCodes,'|') b
									 OUTER APPLY string_split(@LocationCodes,'|') c
			WHERE		   
			(@SearchText IS NULL 			
				OR Title LIKE '%' + a.value + '%'
				OR CustomerName LIKE '%' + a.value + '%'
				)	
			AND (@LocationCodes IS NULL OR c.value IN (SELECT value FROM string_split(os.LocationCode,'|')))  
			AND (@ContractTypeCodes IS NULL OR ContractTypeCode IN (SELECT code FROM #tmpContractTypes))    			
			AND (@WorkTypeCodes IS NULL OR WorkTypeCode IN (SELECT code FROM #tmpWorkTypeCodes))
			AND (@WorkTypeCodes IS NULL OR WorkTypeCode IN (SELECT code FROM #tmpWorkTypeCodes))
			AND (@SkillCodes IS NULL OR b.value in (SELECT value FROM string_split(os.SkillCodes,'|')))	
		    AND (
				    (@DailyRateMin IS NULL AND @SalaryMin IS NULL) 
				 OR (os.ContractTypeCode ='freelance' AND @DailyRateMin <=os.AmountMax)
				 OR (os.ContractTypeCode ='cdi' AND @SalaryMin <= os.AmountMax)
				 )				
		)
		,CTE_RowCounts AS
	    (
			SELECT COUNT(*) as [RowCount] FROM CTE_Results
		)
		
		SELECT *			
		FROM CTE_Results, CTE_RowCounts
		ORDER BY RowNumber ASC OFFSET (@PageIndex-1)*@PageSize ROWS FETCH NEXT @PageSize ROWS ONLY
END



GO

CREATE TABLE [dbo].[OfferProfileFavorite](
	[ProfileId] [bigint] NOT NULL,
	[OfferId] [bigint] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
 CONSTRAINT [PK_OfferUserFavorite] PRIMARY KEY CLUSTERED 
(
	[ProfileId] ASC,
	[OfferId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO



