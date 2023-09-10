
/****** Object:  Index [AK_Unique_Code]    Script Date: 10/09/2023 17:52:25 ******/
ALTER TABLE [config].[Categories] DROP CONSTRAINT [AK_Unique_Code]
GO
/****** Object:  Table [config].[Categories]    Script Date: 10/09/2023 17:52:25 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[config].[Categories]') AND type in (N'U'))
DROP TABLE [config].[Categories]
GO
/****** Object:  Table [config].[Categories]    Script Date: 10/09/2023 17:52:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [config].[Categories](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [nvarchar](100) NULL,
	[Name] [nvarchar](100) NULL,
	[Audience] [smallint] NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [config].[Categories] ON 
GO
INSERT [config].[Categories] ([Id], [Code], [Name], [Audience]) VALUES (81, N'3d-animation-designer', N'3D Animation Designer', NULL)
GO
INSERT [config].[Categories] ([Id], [Code], [Name], [Audience]) VALUES (82, N'account-manager', N'Account Manager', NULL)
GO
INSERT [config].[Categories] ([Id], [Code], [Name], [Audience]) VALUES (83, N'administrative-assistant', N'Administrative Assistant', NULL)
GO
INSERT [config].[Categories] ([Id], [Code], [Name], [Audience]) VALUES (84, N'architect', N'Architect', NULL)
GO
INSERT [config].[Categories] ([Id], [Code], [Name], [Audience]) VALUES (85, N'audience-development', N'Audience Development', NULL)
GO
INSERT [config].[Categories] ([Id], [Code], [Name], [Audience]) VALUES (86, N'automated-qa-engineer', N'Automated QA Engineer', NULL)
GO
INSERT [config].[Categories] ([Id], [Code], [Name], [Audience]) VALUES (87, N'backend-developer', N'Backend Developer', 3)
GO
INSERT [config].[Categories] ([Id], [Code], [Name], [Audience]) VALUES (88, N'big-data-data-scientist', N'Big Data/Data Scientist', NULL)
GO
INSERT [config].[Categories] ([Id], [Code], [Name], [Audience]) VALUES (89, N'business-analyst', N'Business Analyst', 4)
GO
INSERT [config].[Categories] ([Id], [Code], [Name], [Audience]) VALUES (90, N'business-development', N'Business Development', NULL)
GO
INSERT [config].[Categories] ([Id], [Code], [Name], [Audience]) VALUES (91, N'community-manager', N'Community Manager', NULL)
GO
INSERT [config].[Categories] ([Id], [Code], [Name], [Audience]) VALUES (92, N'copy-editor', N'Copy Editor', NULL)
GO
INSERT [config].[Categories] ([Id], [Code], [Name], [Audience]) VALUES (93, N'cto', N'CTO', NULL)
GO
INSERT [config].[Categories] ([Id], [Code], [Name], [Audience]) VALUES (94, N'customer-service', N'Customer Service', NULL)
GO
INSERT [config].[Categories] ([Id], [Code], [Name], [Audience]) VALUES (95, N'data', N'Data', NULL)
GO
INSERT [config].[Categories] ([Id], [Code], [Name], [Audience]) VALUES (96, N'data-analyst', N'Data Analyst', NULL)
GO
INSERT [config].[Categories] ([Id], [Code], [Name], [Audience]) VALUES (97, N'database-administrator', N'Database Administrator', NULL)
GO
INSERT [config].[Categories] ([Id], [Code], [Name], [Audience]) VALUES (98, N'database-developer', N'Database Developer', 5)
GO
INSERT [config].[Categories] ([Id], [Code], [Name], [Audience]) VALUES (99, N'data-engineer', N'Data Engineer', 6)
GO
INSERT [config].[Categories] ([Id], [Code], [Name], [Audience]) VALUES (100, N'design', N'Design', NULL)
GO
INSERT [config].[Categories] ([Id], [Code], [Name], [Audience]) VALUES (101, N'dev-management', N'Dev Management', NULL)
GO
INSERT [config].[Categories] ([Id], [Code], [Name], [Audience]) VALUES (102, N'devops', N'DevOps', 7)
GO
INSERT [config].[Categories] ([Id], [Code], [Name], [Audience]) VALUES (103, N'editor', N'Editor', NULL)
GO
INSERT [config].[Categories] ([Id], [Code], [Name], [Audience]) VALUES (104, N'engineering-manager', N'Engineering Manager', NULL)
GO
INSERT [config].[Categories] ([Id], [Code], [Name], [Audience]) VALUES (105, N'executive', N'Executive', NULL)
GO
INSERT [config].[Categories] ([Id], [Code], [Name], [Audience]) VALUES (106, N'frontend-developer', N'Frontend Developer', 2)
GO
INSERT [config].[Categories] ([Id], [Code], [Name], [Audience]) VALUES (107, N'fullstack-developer', N'Fullstack Developer', 1)
GO
INSERT [config].[Categories] ([Id], [Code], [Name], [Audience]) VALUES (108, N'game-designer', N'Game Designer', NULL)
GO
INSERT [config].[Categories] ([Id], [Code], [Name], [Audience]) VALUES (109, N'game-developer', N'Game Developer', NULL)
GO
INSERT [config].[Categories] ([Id], [Code], [Name], [Audience]) VALUES (110, N'gis', N'GIS', NULL)
GO
INSERT [config].[Categories] ([Id], [Code], [Name], [Audience]) VALUES (111, N'graphic-designer', N'Graphic Designer', 8)
GO
INSERT [config].[Categories] ([Id], [Code], [Name], [Audience]) VALUES (112, N'hr-professional', N'HR Professional', NULL)
GO
INSERT [config].[Categories] ([Id], [Code], [Name], [Audience]) VALUES (113, N'illustrator', N'Illustrator', NULL)
GO
INSERT [config].[Categories] ([Id], [Code], [Name], [Audience]) VALUES (114, N'information-security-cryptology', N'Information Security / Cryptology', NULL)
GO
INSERT [config].[Categories] ([Id], [Code], [Name], [Audience]) VALUES (115, N'infrastructure-and-networking', N'Infrastructure and Networking', NULL)
GO
INSERT [config].[Categories] ([Id], [Code], [Name], [Audience]) VALUES (116, N'lead-engineer', N'Lead Engineer', NULL)
GO
INSERT [config].[Categories] ([Id], [Code], [Name], [Audience]) VALUES (117, N'legal-professional', N'Legal Professional', NULL)
GO
INSERT [config].[Categories] ([Id], [Code], [Name], [Audience]) VALUES (118, N'marketer', N'Marketer', NULL)
GO
INSERT [config].[Categories] ([Id], [Code], [Name], [Audience]) VALUES (119, N'marketing-pr-leader', N'Marketing & PR Leader', NULL)
GO
INSERT [config].[Categories] ([Id], [Code], [Name], [Audience]) VALUES (120, N'media-publishing', N'Media and Publishing', NULL)
GO
INSERT [config].[Categories] ([Id], [Code], [Name], [Audience]) VALUES (121, N'mobile-developer', N'Mobile Developer', NULL)
GO
INSERT [config].[Categories] ([Id], [Code], [Name], [Audience]) VALUES (122, N'operations-management', N'Operations Management', NULL)
GO
INSERT [config].[Categories] ([Id], [Code], [Name], [Audience]) VALUES (123, N'product-management', N'Product Management', NULL)
GO
INSERT [config].[Categories] ([Id], [Code], [Name], [Audience]) VALUES (124, N'product-manager', N'Product Manager', NULL)
GO
INSERT [config].[Categories] ([Id], [Code], [Name], [Audience]) VALUES (125, N'program-manager', N'Program Manager', NULL)
GO
INSERT [config].[Categories] ([Id], [Code], [Name], [Audience]) VALUES (126, N'public-relations-leader', N'Public Relations Leader', NULL)
GO
INSERT [config].[Categories] ([Id], [Code], [Name], [Audience]) VALUES (127, N'qa-analyst', N'QA Analyst', NULL)
GO
INSERT [config].[Categories] ([Id], [Code], [Name], [Audience]) VALUES (128, N'sales-and-marketing', N'Sales and Marketing', NULL)
GO
INSERT [config].[Categories] ([Id], [Code], [Name], [Audience]) VALUES (129, N'sales-operations', N'Sales Operations', NULL)
GO
INSERT [config].[Categories] ([Id], [Code], [Name], [Audience]) VALUES (130, N'science-and-education', N'Science and Education', NULL)
GO
INSERT [config].[Categories] ([Id], [Code], [Name], [Audience]) VALUES (131, N'scientist', N'Scientist', NULL)
GO
INSERT [config].[Categories] ([Id], [Code], [Name], [Audience]) VALUES (132, N'scrum-master', N'Scrum Master', NULL)
GO
INSERT [config].[Categories] ([Id], [Code], [Name], [Audience]) VALUES (133, N'social-media', N'Social Media', NULL)
GO
INSERT [config].[Categories] ([Id], [Code], [Name], [Audience]) VALUES (134, N'social-media-editor', N'Social Media Editor', NULL)
GO
INSERT [config].[Categories] ([Id], [Code], [Name], [Audience]) VALUES (135, N'social-media-expert', N'Social Media Expert', NULL)
GO
INSERT [config].[Categories] ([Id], [Code], [Name], [Audience]) VALUES (136, N'software-engineering', N'Software Engineering', 9)
GO
INSERT [config].[Categories] ([Id], [Code], [Name], [Audience]) VALUES (137, N'software-tester', N'Software Tester', 10)
GO
INSERT [config].[Categories] ([Id], [Code], [Name], [Audience]) VALUES (138, N'content-publishing-manager', N'Content Publishing Manager', NULL)
GO
INSERT [config].[Categories] ([Id], [Code], [Name], [Audience]) VALUES (139, N'manager-training', N'Manager Training', NULL)
GO
INSERT [config].[Categories] ([Id], [Code], [Name], [Audience]) VALUES (140, N'sysadmin', N'SysAdmin', NULL)
GO
INSERT [config].[Categories] ([Id], [Code], [Name], [Audience]) VALUES (141, N'talent-manager', N'Talent Manager', NULL)
GO
INSERT [config].[Categories] ([Id], [Code], [Name], [Audience]) VALUES (142, N'project-manager', N'Project Manager', NULL)
GO
INSERT [config].[Categories] ([Id], [Code], [Name], [Audience]) VALUES (143, N'testing', N'Testing', 11)
GO
INSERT [config].[Categories] ([Id], [Code], [Name], [Audience]) VALUES (144, N'training', N'Training', 12)
GO
INSERT [config].[Categories] ([Id], [Code], [Name], [Audience]) VALUES (145, N'ux-ui', N'UX/UI', NULL)
GO
INSERT [config].[Categories] ([Id], [Code], [Name], [Audience]) VALUES (146, N'virtual-assistant', N'Virtual Assistant', NULL)
GO
INSERT [config].[Categories] ([Id], [Code], [Name], [Audience]) VALUES (147, N'web-designer', N'Web Designer', NULL)
GO
INSERT [config].[Categories] ([Id], [Code], [Name], [Audience]) VALUES (148, N'writer', N'Writer', NULL)
GO
SET IDENTITY_INSERT [config].[Categories] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [AK_Unique_Code]    Script Date: 10/09/2023 17:52:26 ******/
ALTER TABLE [config].[Categories] ADD  CONSTRAINT [AK_Unique_Code] UNIQUE NONCLUSTERED 
(
	[Code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
