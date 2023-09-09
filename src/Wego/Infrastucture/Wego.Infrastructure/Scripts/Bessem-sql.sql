
delete
  FROM [config].[skills]
  where code in('full-stack','back-end','front-end')

/****** Object:  StoredProcedure [dbo].[OfferSearchEngine]    Script Date: 09/09/2023 16:21:37 ******/
DROP PROCEDURE [dbo].[OfferSearchEngine]
GO
/****** Object:  Index [AK_Unique_Code]    Script Date: 09/09/2023 16:21:37 ******/
ALTER TABLE OFFERS DROP CONSTRAINT FK_Offers_Categories
ALTER TABLE [config].[Categories] DROP CONSTRAINT [AK_Unique_Code]
GO
/****** Object:  Table [dbo].[OffersSearch]    Script Date: 09/09/2023 16:21:37 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[OffersSearch]') AND type in (N'U'))
DROP TABLE [dbo].[OffersSearch]
GO
/****** Object:  Table [config].[Categories]    Script Date: 09/09/2023 16:21:37 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[config].[Categories]') AND type in (N'U'))
DROP TABLE [config].[Categories]
GO
/****** Object:  Table [config].[Categories]    Script Date: 09/09/2023 16:21:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [config].[Categories](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [nvarchar](100) NULL,
	[Name] [nvarchar](100) NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OffersSearch]    Script Date: 09/09/2023 16:21:37 ******/
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
	[CategoryCode] [nvarchar](100) NULL,
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
SET IDENTITY_INSERT [config].[Categories] ON 
GO
INSERT [config].[Categories] ([Id], [Code], [Name]) VALUES (1, N'3d-animation-designer', N'3D Animation Designer')
GO
INSERT [config].[Categories] ([Id], [Code], [Name]) VALUES (2, N'accountant', N'Accountant')
GO
INSERT [config].[Categories] ([Id], [Code], [Name]) VALUES (3, N'account-manager', N'Account Manager')
GO
INSERT [config].[Categories] ([Id], [Code], [Name]) VALUES (4, N'administrative-assistant', N'Administrative Assistant')
GO
INSERT [config].[Categories] ([Id], [Code], [Name]) VALUES (5, N'architect', N'Architect')
GO
INSERT [config].[Categories] ([Id], [Code], [Name]) VALUES (6, N'audience-development', N'Audience Development')
GO
INSERT [config].[Categories] ([Id], [Code], [Name]) VALUES (7, N'automated-qa-engineer', N'Automated QA Engineer')
GO
INSERT [config].[Categories] ([Id], [Code], [Name]) VALUES (8, N'backend-developer', N'Backend Developer')
GO
INSERT [config].[Categories] ([Id], [Code], [Name]) VALUES (9, N'big-data-data-scientist', N'Big Data/Data Scientist')
GO
INSERT [config].[Categories] ([Id], [Code], [Name]) VALUES (10, N'business-analyst', N'Business Analyst')
GO
INSERT [config].[Categories] ([Id], [Code], [Name]) VALUES (11, N'business-development', N'Business Development')
GO
INSERT [config].[Categories] ([Id], [Code], [Name]) VALUES (12, N'community-manager', N'Community Manager')
GO
INSERT [config].[Categories] ([Id], [Code], [Name]) VALUES (13, N'copy-editor', N'Copy Editor')
GO
INSERT [config].[Categories] ([Id], [Code], [Name]) VALUES (14, N'cto', N'CTO')
GO
INSERT [config].[Categories] ([Id], [Code], [Name]) VALUES (15, N'customer-service', N'Customer Service')
GO
INSERT [config].[Categories] ([Id], [Code], [Name]) VALUES (16, N'data', N'Data')
GO
INSERT [config].[Categories] ([Id], [Code], [Name]) VALUES (17, N'data-analyst', N'Data Analyst')
GO
INSERT [config].[Categories] ([Id], [Code], [Name]) VALUES (18, N'database-administrator', N'Database Administrator')
GO
INSERT [config].[Categories] ([Id], [Code], [Name]) VALUES (19, N'database-developer', N'Database Developer')
GO
INSERT [config].[Categories] ([Id], [Code], [Name]) VALUES (20, N'data-engineer', N'Data Engineer')
GO
INSERT [config].[Categories] ([Id], [Code], [Name]) VALUES (21, N'design', N'Design')
GO
INSERT [config].[Categories] ([Id], [Code], [Name]) VALUES (22, N'dev-management', N'Dev Management')
GO
INSERT [config].[Categories] ([Id], [Code], [Name]) VALUES (23, N'devops', N'DevOps')
GO
INSERT [config].[Categories] ([Id], [Code], [Name]) VALUES (24, N'editor', N'Editor')
GO
INSERT [config].[Categories] ([Id], [Code], [Name]) VALUES (25, N'engineering-manager', N'Engineering Manager')
GO
INSERT [config].[Categories] ([Id], [Code], [Name]) VALUES (26, N'executive', N'Executive')
GO
INSERT [config].[Categories] ([Id], [Code], [Name]) VALUES (27, N'executive-assistant', N'Executive Assistant')
GO
INSERT [config].[Categories] ([Id], [Code], [Name]) VALUES (28, N'field-engineer', N'Field Engineer')
GO
INSERT [config].[Categories] ([Id], [Code], [Name]) VALUES (29, N'finance', N'Finance')
GO
INSERT [config].[Categories] ([Id], [Code], [Name]) VALUES (30, N'frontend-developer', N'Frontend Developer')
GO
INSERT [config].[Categories] ([Id], [Code], [Name]) VALUES (31, N'fullstack-developer', N'Fullstack Developer')
GO
INSERT [config].[Categories] ([Id], [Code], [Name]) VALUES (32, N'game-designer', N'Game Designer')
GO
INSERT [config].[Categories] ([Id], [Code], [Name]) VALUES (33, N'game-developer', N'Game Developer')
GO
INSERT [config].[Categories] ([Id], [Code], [Name]) VALUES (34, N'gis', N'GIS')
GO
INSERT [config].[Categories] ([Id], [Code], [Name]) VALUES (35, N'graphic-designer', N'Graphic Designer')
GO
INSERT [config].[Categories] ([Id], [Code], [Name]) VALUES (36, N'hr-professional', N'HR Professional')
GO
INSERT [config].[Categories] ([Id], [Code], [Name]) VALUES (37, N'illustrator', N'Illustrator')
GO
INSERT [config].[Categories] ([Id], [Code], [Name]) VALUES (38, N'information-security-cryptology', N'Information Security / Cryptology')
GO
INSERT [config].[Categories] ([Id], [Code], [Name]) VALUES (39, N'infrastructure-and-networking', N'Infrastructure and Networking')
GO
INSERT [config].[Categories] ([Id], [Code], [Name]) VALUES (40, N'instructional-designer', N'Instructional Designer')
GO
INSERT [config].[Categories] ([Id], [Code], [Name]) VALUES (41, N'journalist', N'Journalist')
GO
INSERT [config].[Categories] ([Id], [Code], [Name]) VALUES (42, N'lead-engineer', N'Lead Engineer')
GO
INSERT [config].[Categories] ([Id], [Code], [Name]) VALUES (43, N'legal-professional', N'Legal Professional')
GO
INSERT [config].[Categories] ([Id], [Code], [Name]) VALUES (44, N'management-operations', N'Management and Operations')
GO
INSERT [config].[Categories] ([Id], [Code], [Name]) VALUES (45, N'marketer', N'Marketer')
GO
INSERT [config].[Categories] ([Id], [Code], [Name]) VALUES (46, N'marketing-pr-leader', N'Marketing & PR Leader')
GO
INSERT [config].[Categories] ([Id], [Code], [Name]) VALUES (47, N'mechanical-engineer', N'Mechanical Engineer')
GO
INSERT [config].[Categories] ([Id], [Code], [Name]) VALUES (48, N'media-publishing', N'Media and Publishing')
GO
INSERT [config].[Categories] ([Id], [Code], [Name]) VALUES (49, N'mobile-developer', N'Mobile Developer')
GO
INSERT [config].[Categories] ([Id], [Code], [Name]) VALUES (50, N'operations-management', N'Operations Management')
GO
INSERT [config].[Categories] ([Id], [Code], [Name]) VALUES (51, N'product-management', N'Product Management')
GO
INSERT [config].[Categories] ([Id], [Code], [Name]) VALUES (52, N'product-manager', N'Product Manager')
GO
INSERT [config].[Categories] ([Id], [Code], [Name]) VALUES (53, N'program-manager', N'Program Manager')
GO
INSERT [config].[Categories] ([Id], [Code], [Name]) VALUES (54, N'public-relations-leader', N'Public Relations Leader')
GO
INSERT [config].[Categories] ([Id], [Code], [Name]) VALUES (55, N'qa-analyst', N'QA Analyst')
GO
INSERT [config].[Categories] ([Id], [Code], [Name]) VALUES (56, N'sales', N'Sales')
GO
INSERT [config].[Categories] ([Id], [Code], [Name]) VALUES (57, N'sales-and-marketing', N'Sales and Marketing')
GO
INSERT [config].[Categories] ([Id], [Code], [Name]) VALUES (58, N'sales-operations', N'Sales Operations')
GO
INSERT [config].[Categories] ([Id], [Code], [Name]) VALUES (59, N'science-and-education', N'Science and Education')
GO
INSERT [config].[Categories] ([Id], [Code], [Name]) VALUES (60, N'scientist', N'Scientist')
GO
INSERT [config].[Categories] ([Id], [Code], [Name]) VALUES (61, N'scrum-master', N'Scrum Master')
GO
INSERT [config].[Categories] ([Id], [Code], [Name]) VALUES (62, N'social-media', N'Social Media')
GO
INSERT [config].[Categories] ([Id], [Code], [Name]) VALUES (63, N'social-media-editor', N'Social Media Editor')
GO
INSERT [config].[Categories] ([Id], [Code], [Name]) VALUES (64, N'social-media-expert', N'Social Media Expert')
GO
INSERT [config].[Categories] ([Id], [Code], [Name]) VALUES (65, N'software-engineering', N'Software Engineering')
GO
INSERT [config].[Categories] ([Id], [Code], [Name]) VALUES (66, N'software-tester', N'Software Tester')
GO
INSERT [config].[Categories] ([Id], [Code], [Name]) VALUES (67, N'content-publishing-manager', N'Content Publishing Manager')
GO
INSERT [config].[Categories] ([Id], [Code], [Name]) VALUES (68, N'manager-training', N'Manager Training')
GO
INSERT [config].[Categories] ([Id], [Code], [Name]) VALUES (69, N'sysadmin', N'SysAdmin')
GO
INSERT [config].[Categories] ([Id], [Code], [Name]) VALUES (70, N'talent-manager', N'Talent Manager')
GO
INSERT [config].[Categories] ([Id], [Code], [Name]) VALUES (71, N'teacher', N'Teacher')
GO
INSERT [config].[Categories] ([Id], [Code], [Name]) VALUES (72, N'project-manager', N'Project Manager')
GO
INSERT [config].[Categories] ([Id], [Code], [Name]) VALUES (73, N'testing', N'Testing')
GO
INSERT [config].[Categories] ([Id], [Code], [Name]) VALUES (74, N'training', N'Training')
GO
INSERT [config].[Categories] ([Id], [Code], [Name]) VALUES (75, N'ux-ui', N'UX/UI')
GO
INSERT [config].[Categories] ([Id], [Code], [Name]) VALUES (76, N'video-producer', N'Video Producer')
GO
INSERT [config].[Categories] ([Id], [Code], [Name]) VALUES (77, N'virtual-assistant', N'Virtual Assistant')
GO
INSERT [config].[Categories] ([Id], [Code], [Name]) VALUES (78, N'web-designer', N'Web Designer')
GO
INSERT [config].[Categories] ([Id], [Code], [Name]) VALUES (79, N'writer', N'Writer')
GO
SET IDENTITY_INSERT [config].[Categories] OFF
GO
SET IDENTITY_INSERT [dbo].[OffersSearch] ON 
GO
INSERT [dbo].[OffersSearch] ([Id], [Title], [Description], [CustomerName], [AmountMin], [AmountMax], [AmountUnit], [Duration], [LocationCode], [LocationName], [ContractTypeCode], [SeniorityCode], [WorkTypeCode], [CategoryCode], [SkillCodes], [SkillNames], [CreatedDate], [PublicationDate]) VALUES (1585, N'Developpeur .net', N'Nous recherchons pour l’un de nos client un développeur. Net dans le cadre d’une mission longue.', N'RFB Innovation', CAST(400 AS Decimal(18, 0)), CAST(500 AS Decimal(18, 0)), N'1', 12, N'paris|paris|ile-de-france', N'Paris', N'freelance', N'junior', N'hybrid', N'fullstack-developer', N'net|angular', N'.Net|Angular', CAST(N'2022-09-14T14:00:00.000' AS DateTime), CAST(N'2022-09-14T14:00:00.000' AS DateTime))
GO
INSERT [dbo].[OffersSearch] ([Id], [Title], [Description], [CustomerName], [AmountMin], [AmountMax], [AmountUnit], [Duration], [LocationCode], [LocationName], [ContractTypeCode], [SeniorityCode], [WorkTypeCode], [CategoryCode], [SkillCodes], [SkillNames], [CreatedDate], [PublicationDate]) VALUES (1586, N'Chef de projet MOA Décisionnel', N'La prestation prendra place au sein du pôle Data Factory dont la mission d’assurer l’ensemble des activités IT des SI Décisionnels du Groupe.', N'Bam engineering', CAST(80000 AS Decimal(18, 0)), CAST(100000 AS Decimal(18, 0)), N'3', NULL, N'marseille|bouches-du-rhone|provence-alpes-cote-d-azur', N'Marseille', N'cdi', N'intermediate', N'remote', N'backend-developer', N'sql', N'Sql Server', CAST(N'2022-10-14T15:00:00.000' AS DateTime), CAST(N'2022-10-14T15:00:00.000' AS DateTime))
GO
INSERT [dbo].[OffersSearch] ([Id], [Title], [Description], [CustomerName], [AmountMin], [AmountMax], [AmountUnit], [Duration], [LocationCode], [LocationName], [ContractTypeCode], [SeniorityCode], [WorkTypeCode], [CategoryCode], [SkillCodes], [SkillNames], [CreatedDate], [PublicationDate]) VALUES (1592, N'Dévéloppeur Angular', N'Fyte Dev & Technology est spécialisé dans le sourcing, l''évaluation et le recrutement en intérim, CDD et CDI de profils techniques pour les métiers de l''IT. Les consultants Fyte Dev & Technology sont ultra-spécialisés par métiers et possèdent une approche qui concilie une connaissance approfondie des nouvelles technologies et des métiers de l''informatique, du développement et des systèmes d''information.', N'FYTE', CAST(20000 AS Decimal(18, 0)), CAST(40000 AS Decimal(18, 0)), N'3', 6, N'puteaux|bouches-du-rhone|ile-de-france', N'Puteaux', N'cdd', N'senior', N'site', N'frontend-developer', N'java|c#|c++', N'Java|C#|C++', CAST(N'2022-10-14T10:00:00.000' AS DateTime), CAST(N'2022-10-14T10:00:00.000' AS DateTime))
GO
INSERT [dbo].[OffersSearch] ([Id], [Title], [Description], [CustomerName], [AmountMin], [AmountMax], [AmountUnit], [Duration], [LocationCode], [LocationName], [ContractTypeCode], [SeniorityCode], [WorkTypeCode], [CategoryCode], [SkillCodes], [SkillNames], [CreatedDate], [PublicationDate]) VALUES (1593, N'Developpeur .net', N'Nous recherchons pour l’un de nos client un développeur. Net dans le cadre d’une mission longue.', N'RFB Innovation', CAST(400 AS Decimal(18, 0)), CAST(500 AS Decimal(18, 0)), N'1', 12, N'paris|paris|ile-de-france', N'Paris', N'freelance', N'intermediate', N'hybrid', N'frontend-developer', N'net|angular', N'.Net|Angular', CAST(N'2022-09-14T08:00:00.000' AS DateTime), CAST(N'2022-09-14T08:00:00.000' AS DateTime))
GO
INSERT [dbo].[OffersSearch] ([Id], [Title], [Description], [CustomerName], [AmountMin], [AmountMax], [AmountUnit], [Duration], [LocationCode], [LocationName], [ContractTypeCode], [SeniorityCode], [WorkTypeCode], [CategoryCode], [SkillCodes], [SkillNames], [CreatedDate], [PublicationDate]) VALUES (1594, N'Chef de projet MOA Décisionnel', N'La prestation prendra place au sein du pôle Data Factory dont la mission d’assurer l’ensemble des activités IT des SI Décisionnels du Groupe.', N'Bam engineering', CAST(80000 AS Decimal(18, 0)), CAST(100000 AS Decimal(18, 0)), N'3', NULL, N'marseille|bouches-du-rhone|provence-alpes-cote-d-azur', N'Marseille', N'cdi', N'senior', N'remote', N'fullstack-developer', N'sql', N'Sql Server', CAST(N'2022-10-14T09:00:00.000' AS DateTime), CAST(N'2022-10-14T09:00:00.000' AS DateTime))
GO
INSERT [dbo].[OffersSearch] ([Id], [Title], [Description], [CustomerName], [AmountMin], [AmountMax], [AmountUnit], [Duration], [LocationCode], [LocationName], [ContractTypeCode], [SeniorityCode], [WorkTypeCode], [CategoryCode], [SkillCodes], [SkillNames], [CreatedDate], [PublicationDate]) VALUES (1595, N'Dévéloppeur Angular', N'Fyte Dev & Technology est spécialisé dans le sourcing, l''évaluation et le recrutement en intérim, CDD et CDI de profils techniques pour les métiers de l''IT. Les consultants Fyte Dev & Technology sont ultra-spécialisés par métiers et possèdent une approche qui concilie une connaissance approfondie des nouvelles technologies et des métiers de l''informatique, du développement et des systèmes d''information.', N'FYTE', CAST(20000 AS Decimal(18, 0)), CAST(40000 AS Decimal(18, 0)), N'3', 6, N'puteaux|bouches-du-rhone|ile-de-france', N'Puteaux', N'cdd', N'junior', N'site', N'frontend-developer', N'java|c#|c++', N'Java|C#|C++', CAST(N'2022-10-14T11:00:00.000' AS DateTime), CAST(N'2022-10-14T11:00:00.000' AS DateTime))
GO
INSERT [dbo].[OffersSearch] ([Id], [Title], [Description], [CustomerName], [AmountMin], [AmountMax], [AmountUnit], [Duration], [LocationCode], [LocationName], [ContractTypeCode], [SeniorityCode], [WorkTypeCode], [CategoryCode], [SkillCodes], [SkillNames], [CreatedDate], [PublicationDate]) VALUES (1596, N'Developpeur .net', N'Nous recherchons pour l’un de nos client un développeur. Net dans le cadre d’une mission longue.', N'RFB Innovation', CAST(400 AS Decimal(18, 0)), CAST(500 AS Decimal(18, 0)), N'1', 12, N'paris|paris|ile-de-france', N'Paris', N'freelance', N'senior', N'hybrid', N'fullstack-developer', N'net|angular', N'.Net|Angular', CAST(N'2022-09-14T13:00:00.000' AS DateTime), CAST(N'2022-09-14T13:00:00.000' AS DateTime))
GO
INSERT [dbo].[OffersSearch] ([Id], [Title], [Description], [CustomerName], [AmountMin], [AmountMax], [AmountUnit], [Duration], [LocationCode], [LocationName], [ContractTypeCode], [SeniorityCode], [WorkTypeCode], [CategoryCode], [SkillCodes], [SkillNames], [CreatedDate], [PublicationDate]) VALUES (1597, N'Chef de projet MOA Décisionnel', N'La prestation prendra place au sein du pôle Data Factory dont la mission d’assurer l’ensemble des activités IT des SI Décisionnels du Groupe.', N'Bam engineering', CAST(80000 AS Decimal(18, 0)), CAST(100000 AS Decimal(18, 0)), N'3', NULL, N'marseille|bouches-du-rhone|provence-alpes-cote-d-azur', N'Marseille', N'cdi', N'intermediate', N'remote', N'backend-developer', N'sql', N'Sql Server', CAST(N'2022-10-14T22:00:00.000' AS DateTime), CAST(N'2022-10-14T22:00:00.000' AS DateTime))
GO
INSERT [dbo].[OffersSearch] ([Id], [Title], [Description], [CustomerName], [AmountMin], [AmountMax], [AmountUnit], [Duration], [LocationCode], [LocationName], [ContractTypeCode], [SeniorityCode], [WorkTypeCode], [CategoryCode], [SkillCodes], [SkillNames], [CreatedDate], [PublicationDate]) VALUES (1598, N'Dévéloppeur Angular', N'Fyte Dev & Technology est spécialisé dans le sourcing, l''évaluation et le recrutement en intérim, CDD et CDI de profils techniques pour les métiers de l''IT. Les consultants Fyte Dev & Technology sont ultra-spécialisés par métiers et possèdent une approche qui concilie une connaissance approfondie des nouvelles technologies et des métiers de l''informatique, du développement et des systèmes d''information.', N'FYTE', CAST(20000 AS Decimal(18, 0)), CAST(40000 AS Decimal(18, 0)), N'3', 6, N'puteaux|bouches-du-rhone|ile-de-france', N'Puteaux', N'cdd', N'intermediate', N'site', N'fullstack-developer', N'java|c#|c++', N'Java|C#|C++', CAST(N'2022-10-14T11:00:00.000' AS DateTime), CAST(N'2022-10-14T11:00:00.000' AS DateTime))
GO
INSERT [dbo].[OffersSearch] ([Id], [Title], [Description], [CustomerName], [AmountMin], [AmountMax], [AmountUnit], [Duration], [LocationCode], [LocationName], [ContractTypeCode], [SeniorityCode], [WorkTypeCode], [CategoryCode], [SkillCodes], [SkillNames], [CreatedDate], [PublicationDate]) VALUES (1599, N'Developpeur .net', N'Nous recherchons pour l’un de nos client un développeur. Net dans le cadre d’une mission longue.', N'RFB Innovation', CAST(400 AS Decimal(18, 0)), CAST(500 AS Decimal(18, 0)), N'1', 12, N'paris|paris|ile-de-france', N'Paris', N'freelance', N'senior', N'hybrid', N'backend-developer', N'net|angular', N'.Net|Angular', CAST(N'2022-09-14T20:00:00.000' AS DateTime), CAST(N'2022-09-14T20:00:00.000' AS DateTime))
GO
INSERT [dbo].[OffersSearch] ([Id], [Title], [Description], [CustomerName], [AmountMin], [AmountMax], [AmountUnit], [Duration], [LocationCode], [LocationName], [ContractTypeCode], [SeniorityCode], [WorkTypeCode], [CategoryCode], [SkillCodes], [SkillNames], [CreatedDate], [PublicationDate]) VALUES (1600, N'Developpeur .net', N'Nous recherchons pour l’un de nos client un développeur. Net dans le cadre d’une mission longue.', N'RFB Innovation', CAST(400 AS Decimal(18, 0)), CAST(500 AS Decimal(18, 0)), N'1', 12, N'paris|paris|ile-de-france', N'Paris', N'freelance', N'junior', N'hybrid', N'backend-developer', N'net|angular', N'.Net|Angular', CAST(N'2022-09-14T21:00:00.000' AS DateTime), CAST(N'2022-09-14T21:00:00.000' AS DateTime))
GO
INSERT [dbo].[OffersSearch] ([Id], [Title], [Description], [CustomerName], [AmountMin], [AmountMax], [AmountUnit], [Duration], [LocationCode], [LocationName], [ContractTypeCode], [SeniorityCode], [WorkTypeCode], [CategoryCode], [SkillCodes], [SkillNames], [CreatedDate], [PublicationDate]) VALUES (1601, N'Chef de projet MOA Décisionnel', N'La prestation prendra place au sein du pôle Data Factory dont la mission d’assurer l’ensemble des activités IT des SI Décisionnels du Groupe.', N'Bam engineering', CAST(80000 AS Decimal(18, 0)), CAST(100000 AS Decimal(18, 0)), N'3', NULL, N'marseille|bouches-du-rhone|provence-alpes-cote-d-azur', N'Marseille', N'cdi', N'senior', N'remote', N'fullstack-developer', N'sql', N'Sql Server', CAST(N'2022-10-14T00:00:00.000' AS DateTime), CAST(N'2022-10-14T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[OffersSearch] ([Id], [Title], [Description], [CustomerName], [AmountMin], [AmountMax], [AmountUnit], [Duration], [LocationCode], [LocationName], [ContractTypeCode], [SeniorityCode], [WorkTypeCode], [CategoryCode], [SkillCodes], [SkillNames], [CreatedDate], [PublicationDate]) VALUES (1602, N'Dévéloppeur Angular', N'Fyte Dev & Technology est spécialisé dans le sourcing, l''évaluation et le recrutement en intérim, CDD et CDI de profils techniques pour les métiers de l''IT. Les consultants Fyte Dev & Technology sont ultra-spécialisés par métiers et possèdent une approche qui concilie une connaissance approfondie des nouvelles technologies et des métiers de l''informatique, du développement et des systèmes d''information.', N'FYTE', CAST(20000 AS Decimal(18, 0)), CAST(40000 AS Decimal(18, 0)), N'3', 6, N'puteaux|bouches-du-rhone|ile-de-france', N'Puteaux', N'cdd', N'senior', N'site', N'frontend-developer', N'java|c#|c++', N'Java|C#|C++', CAST(N'2022-10-14T00:00:00.000' AS DateTime), CAST(N'2022-10-14T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[OffersSearch] ([Id], [Title], [Description], [CustomerName], [AmountMin], [AmountMax], [AmountUnit], [Duration], [LocationCode], [LocationName], [ContractTypeCode], [SeniorityCode], [WorkTypeCode], [CategoryCode], [SkillCodes], [SkillNames], [CreatedDate], [PublicationDate]) VALUES (1603, N'Developpeur .net', N'Nous recherchons pour l’un de nos client un développeur. Net dans le cadre d’une mission longue.', N'RFB Innovation', CAST(400 AS Decimal(18, 0)), CAST(500 AS Decimal(18, 0)), N'1', 12, N'paris|paris|ile-de-france', N'Paris', N'freelance', N'junior', N'hybrid', N'backend-developer', N'net|angular', N'.Net|Angular', CAST(N'2022-09-14T00:00:00.000' AS DateTime), CAST(N'2022-09-14T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[OffersSearch] ([Id], [Title], [Description], [CustomerName], [AmountMin], [AmountMax], [AmountUnit], [Duration], [LocationCode], [LocationName], [ContractTypeCode], [SeniorityCode], [WorkTypeCode], [CategoryCode], [SkillCodes], [SkillNames], [CreatedDate], [PublicationDate]) VALUES (1604, N'Chef de projet MOA Décisionnel', N'La prestation prendra place au sein du pôle Data Factory dont la mission d’assurer l’ensemble des activités IT des SI Décisionnels du Groupe.', N'Bam engineering', CAST(80000 AS Decimal(18, 0)), CAST(100000 AS Decimal(18, 0)), N'3', NULL, N'marseille|bouches-du-rhone|provence-alpes-cote-d-azur', N'Marseille', N'cdi', N'junior', N'remote', N'fullstack-developer', N'sql', N'Sql Server', CAST(N'2022-10-14T00:00:00.000' AS DateTime), CAST(N'2022-10-14T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[OffersSearch] ([Id], [Title], [Description], [CustomerName], [AmountMin], [AmountMax], [AmountUnit], [Duration], [LocationCode], [LocationName], [ContractTypeCode], [SeniorityCode], [WorkTypeCode], [CategoryCode], [SkillCodes], [SkillNames], [CreatedDate], [PublicationDate]) VALUES (1605, N'Dévéloppeur Angular', N'Fyte Dev & Technology est spécialisé dans le sourcing, l''évaluation et le recrutement en intérim, CDD et CDI de profils techniques pour les métiers de l''IT. Les consultants Fyte Dev & Technology sont ultra-spécialisés par métiers et possèdent une approche qui concilie une connaissance approfondie des nouvelles technologies et des métiers de l''informatique, du développement et des systèmes d''information.', N'FYTE', CAST(20000 AS Decimal(18, 0)), CAST(40000 AS Decimal(18, 0)), N'3', 6, N'puteaux|bouches-du-rhone|ile-de-france', N'Puteaux', N'cdd', N'junior', N'site', N'backend-developer', N'java|c#|c++', N'Java|C#|C++', CAST(N'2022-10-14T00:00:00.000' AS DateTime), CAST(N'2022-10-14T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[OffersSearch] ([Id], [Title], [Description], [CustomerName], [AmountMin], [AmountMax], [AmountUnit], [Duration], [LocationCode], [LocationName], [ContractTypeCode], [SeniorityCode], [WorkTypeCode], [CategoryCode], [SkillCodes], [SkillNames], [CreatedDate], [PublicationDate]) VALUES (1606, N'Developpeur .net', N'Nous recherchons pour l’un de nos client un développeur. Net dans le cadre d’une mission longue.', N'RFB Innovation', CAST(400 AS Decimal(18, 0)), CAST(500 AS Decimal(18, 0)), N'1', 12, N'paris|paris|ile-de-france', N'Paris', N'freelance', N'senior', N'hybrid', N'frontend-developer', N'net|angular', N'.Net|Angular', CAST(N'2022-09-14T00:00:00.000' AS DateTime), CAST(N'2022-09-14T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[OffersSearch] ([Id], [Title], [Description], [CustomerName], [AmountMin], [AmountMax], [AmountUnit], [Duration], [LocationCode], [LocationName], [ContractTypeCode], [SeniorityCode], [WorkTypeCode], [CategoryCode], [SkillCodes], [SkillNames], [CreatedDate], [PublicationDate]) VALUES (1607, N'Chef de projet MOA Décisionnel', N'La prestation prendra place au sein du pôle Data Factory dont la mission d’assurer l’ensemble des activités IT des SI Décisionnels du Groupe.', N'Bam engineering', CAST(80000 AS Decimal(18, 0)), CAST(100000 AS Decimal(18, 0)), N'3', NULL, N'marseille|bouches-du-rhone|provence-alpes-cote-d-azur', N'Marseille', N'cdi', N'intermediate', N'remote', N'fullstack-developer', N'sql', N'Sql Server', CAST(N'2022-10-14T00:00:00.000' AS DateTime), CAST(N'2022-10-14T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[OffersSearch] ([Id], [Title], [Description], [CustomerName], [AmountMin], [AmountMax], [AmountUnit], [Duration], [LocationCode], [LocationName], [ContractTypeCode], [SeniorityCode], [WorkTypeCode], [CategoryCode], [SkillCodes], [SkillNames], [CreatedDate], [PublicationDate]) VALUES (1608, N'Dévéloppeur Angular', N'Fyte Dev & Technology est spécialisé dans le sourcing, l''évaluation et le recrutement en intérim, CDD et CDI de profils techniques pour les métiers de l''IT. Les consultants Fyte Dev & Technology sont ultra-spécialisés par métiers et possèdent une approche qui concilie une connaissance approfondie des nouvelles technologies et des métiers de l''informatique, du développement et des systèmes d''information.', N'FYTE', CAST(20000 AS Decimal(18, 0)), CAST(40000 AS Decimal(18, 0)), N'3', 6, N'puteaux|bouches-du-rhone|ile-de-france', N'Puteaux', N'cdd', N'senior', N'site', N'backend-developer', N'java|c#|c++', N'Java|C#|C++', CAST(N'2022-10-14T00:00:00.000' AS DateTime), CAST(N'2022-10-14T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[OffersSearch] ([Id], [Title], [Description], [CustomerName], [AmountMin], [AmountMax], [AmountUnit], [Duration], [LocationCode], [LocationName], [ContractTypeCode], [SeniorityCode], [WorkTypeCode], [CategoryCode], [SkillCodes], [SkillNames], [CreatedDate], [PublicationDate]) VALUES (1609, N'Developpeur .net', N'Nous recherchons pour l’un de nos client un développeur. Net dans le cadre d’une mission longue.', N'RFB Innovation', CAST(400 AS Decimal(18, 0)), CAST(500 AS Decimal(18, 0)), N'1', 12, N'paris|paris|ile-de-france', N'Paris', N'freelance', N'junior', N'hybrid', N'fullstack-developer', N'net|angular', N'.Net|Angular', CAST(N'2022-09-14T00:00:00.000' AS DateTime), CAST(N'2022-09-14T00:00:00.000' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[OffersSearch] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [AK_Unique_Code]    Script Date: 09/09/2023 16:21:37 ******/
ALTER TABLE [config].[Categories] ADD  CONSTRAINT [AK_Unique_Code] UNIQUE NONCLUSTERED 
(
	[Code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[OfferSearchEngine]    Script Date: 09/09/2023 16:21:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Bessem Zbidi
-- Create date: 01/09/2022
-- Description:	Search Job offers 
-- =============================================
CREATE   PROCEDURE [dbo].[OfferSearchEngine]
	@SearchText VARCHAR(250)= null,  -- Gloabl filter	
	@LocationCodes VARCHAR(250)= null,
	@ContractTypeCodes VARCHAR(250) = null,
	@SkillCodes VARCHAR(500) = null,
	@SeniorityCodes VARCHAR(500) = null,
	@CategoryCodes VARCHAR(500) = null,
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

	CREATE TABLE #tmpSeniorityCodes (code VARCHAR(100))
	INSERT INTO #tmpSeniorityCodes 
	SELECT VALUE FROM string_split(@SeniorityCodes,'|')

	CREATE TABLE #tmpCategoryCodes (code VARCHAR(100))
	INSERT INTO #tmpCategoryCodes 
	SELECT VALUE FROM string_split(@CategoryCodes,'|')

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
			--(@SearchText IS NULL 			
			--	OR Title LIKE '%' + a.value + '%'
			--	OR CustomerName LIKE '%' + a.value + '%'
			--	)	
			(@LocationCodes IS NULL OR c.value IN (SELECT value FROM string_split(os.LocationCode,'|')))  
			AND (@ContractTypeCodes IS NULL OR ContractTypeCode IN (SELECT code FROM #tmpContractTypes))    			
			AND (@WorkTypeCodes IS NULL OR WorkTypeCode IN (SELECT code FROM #tmpWorkTypeCodes))
			AND (@WorkTypeCodes IS NULL OR WorkTypeCode IN (SELECT code FROM #tmpWorkTypeCodes))
			AND (@SeniorityCodes IS NULL OR SeniorityCode IN (SELECT Code FROM #tmpSeniorityCodes))
			AND (@CategoryCodes IS NULL OR CategoryCode IN (SELECT Code FROM #tmpCategoryCodes))
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
