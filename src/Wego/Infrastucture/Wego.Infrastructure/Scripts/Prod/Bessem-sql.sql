
/****** Object:  Table [chat].[Candidates]    Script Date: 04/09/2023 22:20:03 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[chat].[Candidates]') AND type in (N'U'))
DROP TABLE [chat].[Candidates]
GO

/****** Object:  Table [chat].[Candidates]    Script Date: 04/09/2023 22:20:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [chat].[Candidates](
	[ProfileId] [bigint] NOT NULL,
	[Name] [nvarchar](250) NOT NULL,
	[Email] [nvarchar](250) NOT NULL,
	[IsConnected] [bit] NOT NULL,
	[ConnectionId] [nvarchar](50) NULL,
	[CreationDate] [datetime] NULL,
	[UpdateDate] [datetime] NULL,
 CONSTRAINT [PK_Candidates_1] PRIMARY KEY CLUSTERED 
(
	[ProfileId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [config].[Skills]    Script Date: 04/09/2023 22:20:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
delete from [config].[Skills]
ALTER TABLE [config].[Skills]
ADD HasImage bit 
ALTER TABLE [config].[Skills] ADD  CONSTRAINT [DF_Skills_HasImage]  DEFAULT ((0)) FOR [HasImage]
SET IDENTITY_INSERT [config].[Skills] ON 
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1, N'.NET', N'net', 1)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (2, N'.NET CORE', N'net-core', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (3, N'.NET Framework', N'net-framework', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (4, N'3CX', N'3cx', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (5, N'3D', N'3d', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (6, N'3G', N'3g', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (7, N'4G', N'4g', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (8, N'5S', N'5s', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (9, N'ABAP', N'abap', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (10, N'Access Control List (ACL)', N'access-control-list-acl', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (11, N'Acronis', N'acronis', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (12, N'Active Directory', N'active-directory', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (13, N'Active Directory Domain Services (AD DS)', N'active-directory-domain-services-ad-ds', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (14, N'Address Resolution Protocol (ARP)', N'address-resolution-protocol-arp', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (15, N'ADFS', N'adfs', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (16, N'Administration linux', N'administration-linux', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (17, N'Administration réseaux', N'administration-reseaux', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (18, N'Administration système', N'administration-systeme', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (19, N'Administration systèmes et rèseaux', N'administration-systemes-et-reseaux', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (20, N'Administration Windows', N'administration-windows', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (21, N'ADO.NET', N'ado-net', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (22, N'Adobe', N'adobe', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (23, N'Adobe After Effects', N'adobe-after-effects', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (24, N'Adobe Campaign', N'adobe-campaign', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (25, N'Adobe Creative Suite', N'adobe-creative-suite', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (26, N'Adobe Flash', N'adobe-flash', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (27, N'Adobe Illustrator', N'adobe-illustrator', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (28, N'Adobe InDesign', N'adobe-indesign', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (29, N'Adobe Lightroom', N'adobe-lightroom', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (30, N'Adobe Photoshop', N'adobe-photoshop', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (31, N'Adobe Premiere Pro', N'adobe-premiere-pro', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (32, N'Adobe XD', N'adobe-xd', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (33, N'ADP', N'adp', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (34, N'Adressage IP', N'adressage-ip', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (35, N'ADSL', N'adsl', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (36, N'Advanced Design System (ADS)', N'advanced-design-system-ads', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (37, N'Agile Scrum', N'agile-scrum', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (38, N'AGL', N'agl', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (39, N'Airtable', N'airtable', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (40, N'AIX (Advanced Interactive eXecutive)', N'aix-advanced-interactive-executive', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (41, N'Ajax', N'ajax', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (42, N'Alfresco', N'alfresco', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (43, N'Algorithmique', N'algorithmique', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (44, N'ALM', N'alm', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (45, N'Alteryx', N'alteryx', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (46, N'Altiris', N'altiris', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (47, N'Amazon DynamoDB', N'amazon-dynamodb', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (48, N'Amazon Elastic Compute Cloud (EC2)', N'amazon-elastic-compute-cloud-ec2', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (49, N'Amazon S3', N'amazon-s3', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (50, N'AMDEC', N'amdec', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (51, N'AMOA', N'amoa', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (52, N'Anaconda', N'anaconda', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (53, N'Analyse', N'analyse', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (54, N'Analyse en Composantes Principales (ACP)', N'analyse-en-composantes-principales-acp', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (55, N'Analyse Factorielle des Correspondances (AFC)', N'analyse-factorielle-des-correspondances-afc', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (56, N'Android', N'android', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (57, N'Android studio', N'android-studio', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (58, N'Angular', N'angular', 1)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (59, N'Angular Material', N'angular-material', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (60, N'AngularJS', N'angularjs', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (61, N'Animation', N'animation', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (62, N'ANOVA', N'anova', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (63, N'Ansible', N'ansible', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (64, N'Ant Design', N'ant-design', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (65, N'Antivirus', N'antivirus', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (66, N'AnyDesk', N'anydesk', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (67, N'Apache', N'apache', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (68, N'Apache Airflow', N'apache-airflow', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (69, N'Apache Hive', N'apache-hive', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (70, N'Apache Kafka', N'apache-kafka', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (71, N'Apache Maven', N'apache-maven', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (72, N'Apache Pig', N'apache-pig', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (73, N'Apache Solr', N'apache-solr', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (74, N'Apache Spark', N'apache-spark', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (75, N'Apache Sqoop', N'apache-sqoop', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (76, N'Apache Struts', N'apache-struts', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (77, N'Apache Subversion', N'apache-subversion', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (78, N'Apache Tomcat', N'apache-tomcat', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (79, N'Apex', N'apex', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (80, N'API', N'api', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (81, N'API Platform', N'api-platform', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (82, N'API REST', N'api-rest', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (83, N'Application mobile', N'application-mobile', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (84, N'Application web', N'application-web', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (85, N'APS', N'aps', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (86, N'ArcGIS', N'arcgis', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (87, N'Arch Linux', N'arch-linux', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (88, N'Archicad', N'archicad', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (89, N'Architecture', N'architecture', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (90, N'Architecture ARM', N'architecture-arm', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (91, N'Arcserve', N'arcserve', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (92, N'Arduino', N'arduino', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (93, N'Ares', N'ares', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (94, N'ARIMA', N'arima', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (95, N'Artificial neural network (ANN)', N'artificial-neural-network-ann', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (96, N'Aruba', N'aruba', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (97, N'AS/400', N'as-400', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (98, N'Asana', N'asana', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (99, N'ASM', N'asm', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (100, N'ASP', N'asp', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (101, N'ASP.NET', N'asp-net', 1)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (102, N'ASP.NET Core', N'asp-net-core', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (103, N'ASP.NET MVC', N'asp-net-mvc', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (104, N'Assembleur', N'assembleur', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (105, N'Asset Center', N'asset-center', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (106, N'Asterisk', N'asterisk', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (107, N'Atlassian', N'atlassian', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (108, N'Atoll', N'atoll', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (109, N'Atom', N'atom', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (110, N'Audacity', N'audacity', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (111, N'Audit', N'audit', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (112, N'AutoCAD', N'autocad', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (113, N'Automatisation', N'automatisation', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (114, N'Avamar', N'avamar', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (115, N'Avaya', N'avaya', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (116, N'AWS Cloud', N'aws-cloud', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (117, N'Axios', N'axios', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (118, N'Axure RP', N'axure-rp', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (119, N'Azure', N'azure', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (120, N'Azure Active Directory', N'azure-active-directory', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (121, N'Azure Data Factory', N'azure-data-factory', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (122, N'Azure DevOps Server', N'azure-devops-server', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (123, N'Azure DevOps Services', N'azure-devops-services', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (124, N'Back office', N'back-office', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (125, N'Back-end', N'back-end', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (126, N'Backup', N'backup', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (127, N'Backup Exec', N'backup-exec', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (128, N'Balsamiq', N'balsamiq', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (129, N'Base de données', N'base-de-donnees', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (130, N'Bash', N'bash', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (131, N'BASIC', N'basic', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (132, N'Batch', N'batch', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (133, N'BeautifulSoup', N'beautifulsoup', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (134, N'Benchmarking', N'benchmarking', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (135, N'BERT', N'bert', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (136, N'BGP (Border Gateway Protocol)', N'bgp-border-gateway-protocol', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (137, N'BI', N'bi', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (138, N'Big Data', N'big-data', 1)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (139, N'BigQuery', N'bigquery', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (140, N'Bitbucket', N'bitbucket', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (141, N'BitLocker', N'bitlocker', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (142, N'BLADE', N'blade', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (143, N'Blender', N'blender', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (144, N'Blockchain', N'blockchain', 1)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (145, N'Bloomberg', N'bloomberg', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (146, N'Bluetooth', N'bluetooth', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (147, N'BMC Remedy', N'bmc-remedy', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (148, N'Bokeh', N'bokeh', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (149, N'Boostrap', N'boostrap', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (150, N'Boot', N'boot', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (151, N'Bootstrap', N'bootstrap', 1)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (152, N'BPM (Business Process Management)', N'bpm-business-process-management', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (153, N'Branding', N'branding', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (154, N'Bugzilla', N'bugzilla', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (155, N'Bureautique', N'bureautique', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (156, N'Burp Suite', N'burp-suite', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (157, N'Business', N'business', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (158, N'Business Analysis', N'business-analysis', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (159, N'Business Intelligence', N'business-intelligence', 1)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (160, N'Business Object', N'business-object', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (161, N'Business Process Model and Notation (BPMN)', N'business-process-model-and-notation-bpmn', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (162, N'C/C++', N'c-c', 1)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (163, N'Cacti', N'cacti', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (164, N'CakePHP', N'cakephp', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (165, N'Camtasia', N'camtasia', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (166, N'CAN (Controller Area Network)', N'can-controller-area-network', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (167, N'Canva', N'canva', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (168, N'Canvas', N'canvas', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (169, N'CAO', N'cao', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (170, N'CAP FT', N'cap-ft', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (171, N'CAPEX', N'capex', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (172, N'Cassandra', N'cassandra', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (173, N'CATIA', N'catia', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (174, N'CCNA', N'ccna', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (175, N'Cegid', N'cegid', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (176, N'CentOS', N'centos', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (177, N'Centreon', N'centreon', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (178, N'CFT (Cross File Transfer)', N'cft-cross-file-transfer', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (179, N'Change management', N'change-management', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (180, N'Chatbot', N'chatbot', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (181, N'Check Point', N'check-point', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (182, N'CI/CD', N'ci-cd', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (183, N'CICS (Customer Information Control System)', N'cics-customer-information-control-system', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (184, N'Ciel Compta', N'ciel-compta', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (185, N'Cisco ASA', N'cisco-asa', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (186, N'Cisco IOS', N'cisco-ios', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (187, N'Cisco Packet Tracer', N'cisco-packet-tracer', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (188, N'Citrix', N'citrix', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (189, N'Clarity', N'clarity', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (190, N'Classification Ascendante Hiérarchique (CAH)', N'classification-ascendante-hierarchique-cah', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (191, N'ClickUp', N'clickup', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (192, N'Client', N'client', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (193, N'Clonezilla', N'clonezilla', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (194, N'Cloud', N'cloud', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (195, N'Cloud privé', N'cloud-prive', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (196, N'Cloudera', N'cloudera', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (197, N'Clustering', N'clustering', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (198, N'Cmd', N'cmd', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (199, N'CMDB', N'cmdb', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (200, N'CMMI (Capability Maturity Model Integration)', N'cmmi-capability-maturity-model-integration', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (201, N'CMS', N'cms', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (202, N'COBIT', N'cobit', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (203, N'COBOL', N'cobol', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (204, N'Code Blocks', N'code-blocks', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (205, N'Code division multiple access (CDMA)', N'code-division-multiple-access-cdma', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (206, N'CodeIgniter', N'codeigniter', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (207, N'Codename One', N'codename-one', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (208, N'Cognos', N'cognos', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (209, N'Coheris Analytics SPAD', N'coheris-analytics-spad', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (210, N'Comité de pilotage (COPIL)', N'comite-de-pilotage-copil', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (211, N'Commerce', N'commerce', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (212, N'Commercial', N'commercial', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (213, N'Composer', N'composer', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (214, N'Comptabilité', N'comptabilite', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (215, N'Computer vision', N'computer-vision', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (216, N'Conception', N'conception', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (217, N'Conduite du changement', N'conduite-du-changement', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (218, N'Confluence', N'confluence', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (219, N'Control-M', N'control-m', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (220, N'Convolutional neural network (CNN)', N'convolutional-neural-network-cnn', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (221, N'Coordination', N'coordination', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (222, N'Cordova', N'cordova', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (223, N'CoreData', N'coredata', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (224, N'cPanel', N'cpanel', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (225, N'CPU', N'cpu', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (226, N'Create Read Update Delete (CRUD)', N'create-read-update-delete-crud', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (227, N'CRM', N'crm', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (228, N'Crontab', N'crontab', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (229, N'Cross-site scripting (XSS)', N'cross-site-scripting-xss', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (230, N'Cryptographie', N'cryptographie', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (231, N'Crystal Reports', N'crystal-reports', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (232, N'CSS', N'css', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (233, N'CSS3', N'css3', 1)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (234, N'CSV', N'csv', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (235, N'Cubase', N'cubase', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (236, N'Cucumber', N'cucumber', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (237, N'CVS (Concurrent Versions System)', N'cvs-concurrent-versions-system', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (238, N'Cybersécurité', N'cybersecurite', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (239, N'Cycle en V', N'cycle-en-v', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (240, N'Cypress', N'cypress', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (241, N'Dameware', N'dameware', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (242, N'Dart (langage)', N'dart-langage', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (243, N'DAS', N'das', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (244, N'Dash', N'dash', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (245, N'DAT', N'dat', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (246, N'Data analysis', N'data-analysis', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (247, N'Data Center', N'data-center', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (248, N'Data cleaning', N'data-cleaning', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (249, N'Data management', N'data-management', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (250, N'Data mining', N'data-mining', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (251, N'Data science', N'data-science', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (252, N'Data visualisation', N'data-visualisation', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (253, N'Data Warehouse', N'data-warehouse', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (254, N'Database', N'database', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (255, N'Databricks', N'databricks', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (256, N'Dataiku', N'dataiku', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (257, N'DAX', N'dax', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (258, N'dBase', N'dbase', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (259, N'DBeaver', N'dbeaver', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (260, N'DBSCAN', N'dbscan', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (261, N'Deep Learning', N'deep-learning', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (262, N'Delphi', N'delphi', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (263, N'Dépannage', N'depannage', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (264, N'Déploiement', N'deploiement', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (265, N'Design', N'design', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (266, N'Design pattern', N'design-pattern', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (267, N'Design system', N'design-system', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (268, N'Dev-C', N'dev-c', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (269, N'Développement', N'developpement', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (270, N'Développement web', N'developpement-web', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (271, N'DevExpress', N'devexpress', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (272, N'DevOps', N'devops', 1)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (273, N'DHCP (Dynamic Host Configuration Protocol)', N'dhcp-dynamic-host-configuration-protocol', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (274, N'Diagramme d''Ishikawa', N'diagramme-dishikawa', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (275, N'Direction', N'direction', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (276, N'Disaster Recovery Plan (DRP)', N'disaster-recovery-plan-drp', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (277, N'Discord', N'discord', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (278, N'Distributed File System (DFS)', N'distributed-file-system-dfs', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (279, N'Divi', N'divi', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (280, N'Django', N'django', 1)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (281, N'DL Software', N'dl-software', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (282, N'DMAIC', N'dmaic', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (283, N'DNS', N'dns', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (284, N'Docker', N'docker', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (285, N'Docker Compose', N'docker-compose', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (286, N'Docker swarm', N'docker-swarm', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (287, N'Doctrine', N'doctrine', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (288, N'Document Object Model (DOM)', N'document-object-model-dom', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (289, N'Domain Driven Design (DDD)', N'domain-driven-design-ddd', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (290, N'Domino', N'domino', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (291, N'DOS', N'dos', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (292, N'dplyr', N'dplyr', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (293, N'draw.io', N'draw-io', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (294, N'Dreamweaver', N'dreamweaver', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (295, N'Drupal', N'drupal', 1)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (296, N'DWDM', N'dwdm', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (297, N'E-commerce', N'e-commerce', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (298, N'Eagle', N'eagle', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (299, N'EasyPHP', N'easyphp', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (300, N'EasyVista', N'easyvista', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (301, N'EBIOS RM', N'ebios-rm', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (302, N'EBP', N'ebp', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (303, N'échange de données informatisé (EDI)', N'echange-de-donnees-informatise-edi', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (304, N'Eclipse', N'eclipse', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (305, N'ECM (Enterprise Content Management)', N'ecm-entreprise-content-management', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (306, N'EIGRP', N'eigrp', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (307, N'Elasticsearch', N'elasticsearch', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (308, N'Electron', N'electron', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (309, N'Electronic Design Automation (EDA)', N'electronic-design-automation-eda', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (310, N'Electronique', N'electronique', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (311, N'Elementor', N'elementor', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (312, N'ELK', N'elk', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (313, N'EMC', N'emc', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (314, N'Endpoint detection and response (EDR)', N'endpoint-detection-and-response-edr', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (315, N'Enterprise Application Integration (EAI)', N'entreprise-application-integration-eai', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (316, N'Enterprise Service Bus (ESB)', N'entreprise-service-bus-esb', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (317, N'Entity Framework', N'entity-framework', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (318, N'Entreprise Java Bean (EJB)', N'entreprise-java-bean-ejb', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (319, N'Environnement de développement intégré (IDE)', N'environnement-de-developpement-integre-ide', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (320, N'Ericsson', N'ericsson', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (321, N'ERP', N'erp', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (322, N'ES6', N'es6', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (323, N'Eset', N'eset', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (324, N'EtherChannel', N'etherchannel', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (325, N'Ethernet', N'ethernet', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (326, N'ETL (Extract-transform-load)', N'etl-extract-transform-load', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (327, N'EViews', N'eviews', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (328, N'Exchange Online', N'exchange-online', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (329, N'Exploitation', N'exploitation', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (330, N'Express', N'express', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (331, N'Express.js', N'express-js', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (332, N'F5', N'f5', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (333, N'Facebook', N'facebook', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (334, N'Facebook Ads', N'facebook-ads', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (335, N'FastAPI', N'fastapi', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (336, N'FDMA', N'fdma', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (337, N'Fedora', N'fedora', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (338, N'Fibre optique', N'fibre-optique', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (339, N'Figma', N'figma', 1)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (340, N'FileZilla', N'filezilla', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (341, N'Final Cut Pro', N'final-cut-pro', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (342, N'Finance', N'finance', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (343, N'Firebase', N'firebase', 1)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (344, N'Firestore', N'firestore', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (345, N'Firewall', N'firewall', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (346, N'FL Studio', N'fl-studio', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (347, N'Flask', N'flask', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (348, N'Flex', N'flex', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (349, N'Flutter', N'flutter', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (350, N'FME', N'fme', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (351, N'FO', N'fo', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (352, N'FOG', N'fog', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (353, N'Formation', N'formation', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (354, N'Forms', N'forms', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (355, N'FortiGate', N'fortigate', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (356, N'Fortinet', N'fortinet', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (357, N'Fortran', N'fortran', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (358, N'FPGA (Field-Programmable Gate Array)', N'fpga-field-programmable-gate-array', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (359, N'Frame Relay', N'frame-relay', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (360, N'Framework', N'framework', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (361, N'FreeBSD', N'freebsd', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (362, N'Front-end', N'front-end', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (363, N'FTP (File Transfert Protocol)', N'ftp-file-transfert-protocol', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (364, N'FTTx', N'fttx', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (365, N'Full stack', N'full-stack', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (366, N'FusionInventory', N'fusioninventory', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (367, N'GanttProject', N'ganttproject', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (368, N'GarageBand', N'garageband', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (369, N'Gateway', N'gateway', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (370, N'Gateway Load Balancing Protocol (GLBP)', N'gateway-load-balancing-protocol-glbp', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (371, N'GED (Gestion électronique des Documents)', N'ged-gestion-electronique-des-documents', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (372, N'Generalized linear model', N'generalized-linear-model', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (373, N'Gensim', N'gensim', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (374, N'GéoFibre', N'geofibre', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (375, N'Gestion de maintenance assistée par ordinateur (GMAO)', N'gestion-de-maintenance-assistee-par-ordinateur-gmao', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (376, N'Gestion de parc', N'gestion-de-parc', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (377, N'Gestion de projet', N'gestion-de-projet', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (378, N'Gestion des risques', N'gestion-des-risques', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (379, N'Gherkin', N'gherkin', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (380, N'Ghost', N'ghost', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (381, N'GIMP', N'gimp', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (382, N'Git', N'git', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (383, N'Github', N'github', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (384, N'Gitlab', N'gitlab', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (385, N'GitLab CI', N'gitlab-ci', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (386, N'GlassFish', N'glassfish', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (387, N'GLPI', N'glpi', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (388, N'Gmail', N'gmail', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (389, N'GNS3', N'gns3', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (390, N'GNU', N'gnu', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (391, N'Go (langage)', N'go-langage', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (392, N'Google ads', N'google-ads', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (393, N'Google Analytics', N'google-analytics', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (394, N'Google Chrome', N'google-chrome', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (395, N'Google Cloud Platform', N'google-cloud-platform', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (396, N'Google Colab', N'google-colab', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (397, N'Google Dashboard', N'google-dashboard', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (398, N'Google Data Studio', N'google-data-studio', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (399, N'Google Docs', N'google-docs', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (400, N'Google Drive', N'google-drive', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (401, N'Google Earth', N'google-earth', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (402, N'Google Maps', N'google-maps', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (403, N'Google Search Console', N'google-search-console', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (404, N'Google Sheets', N'google-sheets', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (405, N'Google Tag Manager', N'google-tag-manager', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (406, N'Google Workspace', N'google-workspace', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (407, N'Gouvernance', N'gouvernance', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (408, N'GPAO', N'gpao', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (409, N'GPEC', N'gpec', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (410, N'GPRS', N'gprs', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (411, N'GPS', N'gps', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (412, N'GPU', N'gpu', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (413, N'Gradle', N'gradle', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (414, N'Grafana', N'grafana', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (415, N'Grafcet', N'grafcet', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (416, N'Graphisme', N'graphisme', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (417, N'GraphQL', N'graphql', 1)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (418, N'Gretl', N'gretl', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (419, N'Groovy', N'groovy', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (420, N'GSAP', N'gsap', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (421, N'GSM', N'gsm', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (422, N'Gulp.js', N'gulp-js', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (423, N'Hadoop', N'hadoop', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (424, N'HAProxy', N'haproxy', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (425, N'Hardware', N'hardware', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (426, N'Haskell', N'haskell', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (427, N'Hbase', N'hbase', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (428, N'HDFS (Hadoop Distributed File System)', N'hdfs-hadoop-distributed-file-system', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (429, N'Helm', N'helm', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (430, N'Helpdesk', N'helpdesk', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (431, N'Heroku', N'heroku', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (432, N'HFSQL', N'hfsql', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (433, N'Hibernate', N'hibernate', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (434, N'Hooks', N'hooks', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (435, N'Hot Standby Router Protocol (HSRP)', N'hot-standby-router-protocol-hsrp', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (436, N'HP ALM', N'hp-alm', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (437, N'HP Quality Center', N'hp-quality-center', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (438, N'HP-UX', N'hp-ux', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (439, N'HPE', N'hpe', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (440, N'HR Access', N'hr-access', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (441, N'HTML', N'html', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (442, N'HTML5', N'html5', 1)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (443, N'HTTP', N'http', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (444, N'HTTPS', N'https', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (445, N'HubSpot', N'hubspot', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (446, N'Hyper-v', N'hyper-v', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (447, N'I2C', N'i2c', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (448, N'IaaS (Infrastructure-as-a-Service)', N'iaas-infrastructure-as-a-service', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (449, N'IBM Cloud', N'ibm-cloud', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (450, N'IBM DataStage', N'ibm-datastage', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (451, N'IBM Db2', N'ibm-db2', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (452, N'IBM Tivoli Storage Manager (TSM)', N'ibm-tivoli-storage-manager-tsm', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (453, N'ICMP', N'icmp', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (454, N'Idoc', N'idoc', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (455, N'IDS/IPS', N'ids-ips', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (456, N'IFRS', N'ifrs', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (457, N'IMAP', N'imap', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (458, N'iMovie', N'imovie', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (459, N'Impression 3D', N'impression-3d', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (460, N'IMS', N'ims', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (461, N'InfluxDB', N'influxdb', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (462, N'Informatica', N'informatica', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (463, N'Informatique', N'informatique', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (464, N'Informix', N'informix', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (465, N'Infrastructure', N'infrastructure', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (466, N'Inkscape', N'inkscape', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (467, N'InShot', N'inshot', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (468, N'Instagram', N'instagram', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (469, N'Installation', N'installation', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (470, N'Int�gration', N'integration', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (471, N'Intel Quartus Prime', N'intel-quartus-prime', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (472, N'Intelligence artificielle', N'intelligence-artificielle', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (473, N'IntelliJ IDEA', N'intellij-idea', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (474, N'Interface Homme-Machine (IHM)', N'interface-homme-machine-ihm', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (475, N'Internet Information Services (IIS)', N'internet-information-services-iis', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (476, N'Internet Protocol (IP)', N'internet-protocol-ip', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (477, N'Intranet', N'intranet', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (478, N'Intune', N'intune', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (479, N'InVision', N'invision', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (480, N'IOC', N'ioc', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (481, N'Ionic', N'ionic', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (482, N'iOS', N'ios', 1)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (483, N'IoT', N'iot', 1)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (484, N'IP virtuelle', N'ip-virtuelle', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (485, N'IPBX (Internet Protocol Branch eXchange)', N'ipbx-internet-protocol-branch-exchange', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (486, N'IPON', N'ipon', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (487, N'IPsec', N'ipsec', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (488, N'Iptables', N'iptables', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (489, N'IPv4', N'ipv4', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (490, N'IPv6', N'ipv6', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (491, N'IS-IS', N'is-is', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (492, N'iSCSI', N'iscsi', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (493, N'ISIS', N'isis', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (494, N'ISO 27001', N'iso-27001', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (495, N'ISO 9001', N'iso-9001', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (496, N'ISTQB', N'istqb', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (497, N'ITIL', N'itil', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (498, N'ITIL v3', N'itil-v3', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (499, N'ITop', N'itop', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (500, N'ITSM', N'itsm', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (501, N'Ivanti', N'ivanti', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (502, N'J2EE / Java EE', N'j2ee-java-ee', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (503, N'Java', N'java', 1)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (504, N'Java SE', N'java-se', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (505, N'Java Server Faces (JSF)', N'java-server-faces-jsf', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (506, N'JavaFX', N'javafx', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (507, N'Javascript', N'javascript', 1)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (508, N'JavaScript ES6', N'javascript-es6', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (509, N'JavaServer Pages (JSP)', N'javaserver-pages-jsp', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (510, N'JCL (Job Control Language)', N'jcl-job-control-language', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (511, N'JDBC (Java Database Connectivity)', N'jdbc-java-database-connectivity', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (512, N'Jenkins', N'jenkins', 1)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (513, N'Jest', N'jest', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (514, N'JHipster', N'jhipster', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (515, N'JIRA', N'jira', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (516, N'JMeter', N'jmeter', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (517, N'Joomla', N'joomla', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (518, N'JPA (Java Persistence API)', N'jpa-java-persistence-api', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (519, N'jQuery', N'jquery', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (520, N'JSON', N'json', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (521, N'JSON Web Token (JWT)', N'json-web-token-jwt', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (522, N'JSTL', N'jstl', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (523, N'JSX', N'jsx', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (524, N'Julia', N'julia', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (525, N'Juniper', N'juniper', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (526, N'JUnit', N'junit', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (527, N'Jupyter Notebook', N'jupyter-notebook', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (528, N'K-means', N'k-means', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (529, N'Kaggle', N'kaggle', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (530, N'Kaizen', N'kaizen', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (531, N'Kali Linux', N'kali-linux', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (532, N'Kanban', N'kanban', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (533, N'Kaspersky', N'kaspersky', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (534, N'Katalon Studio', N'katalon-studio', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (535, N'Keras', N'keras', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (536, N'Keycloak', N'keycloak', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (537, N'Kibana', N'kibana', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (538, N'KiCad', N'kicad', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (539, N'Klaxoon', N'klaxoon', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (540, N'KNIME', N'knime', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (541, N'KNN', N'knn', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (542, N'Know your customer (KYC)', N'know-your-customer-kyc', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (543, N'Kotlin', N'kotlin', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (544, N'KPI', N'kpi', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (545, N'Kubernetes', N'kubernetes', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (546, N'KVM (Kernel-based Virtual Machine)', N'kvm-kernel-based-virtual-machine', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (547, N'LabVIEW', N'labview', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (548, N'LACP (Link Aggregation Control Protocol)', N'lacp-link-aggregation-control-protocol', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (549, N'Ladder', N'ladder', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (550, N'LAMP (Linux Apache MySQL PHP)', N'lamp-linux-apache-mysql-php', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (551, N'LAN', N'lan', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (552, N'LANDesk', N'landesk', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (553, N'Laravel', N'laravel', 1)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (554, N'Latex', N'latex', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (555, N'LDAP', N'ldap', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (556, N'Lean', N'lean', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (557, N'Legacy System Migration Workbench (LSMW)', N'legacy-system-migration-workbench-lsmw', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (558, N'Less', N'less', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (559, N'LibreOffice', N'libreoffice', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (560, N'Linear Discriminant Analysis (LDA)', N'linear-discriminant-analysis-lda', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (561, N'LinkedIn', N'linkedin', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (562, N'LINQ', N'linq', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (563, N'Linux', N'linux', 1)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (564, N'Linux Debian', N'linux-debian', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (565, N'Linux Ubuntu', N'linux-ubuntu', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (566, N'Lisp', N'lisp', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (567, N'LMS (Learning Management System)', N'lms-learning-management-system', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (568, N'Load Balancing', N'load-balancing', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (569, N'Logical Volume Management (LVM)', N'logical-volume-management-lvm', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (570, N'Logistique', N'logistique', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (571, N'Logstash', N'logstash', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (572, N'LoRa', N'lora', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (573, N'Lotus Notes', N'lotus-notes', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (574, N'LSTM', N'lstm', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (575, N'LTE', N'lte', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (576, N'LTspice', N'ltspice', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (577, N'Lua', N'lua', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (578, N'Lumen', N'lumen', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (579, N'Lumion', N'lumion', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (580, N'LUnix', N'lunix', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (581, N'LXC', N'lxc', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (582, N'MAC', N'mac', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (583, N'Machine Learning', N'machine-learning', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (584, N'macOS', N'macos', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (585, N'Magento', N'magento', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (586, N'MailChimp', N'mailchimp', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (587, N'Mailjet', N'mailjet', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (588, N'Mainframe', N'mainframe', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (589, N'Maintenance informatique', N'maintenance-informatique', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (590, N'Maintien en condition opérationnelle (MCO)', N'maintien-en-condition-operationnelle-mco', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (591, N'MAMP', N'mamp', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (592, N'Managed Service Provider (MSP)', N'managed-service-provider-msp', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (593, N'Management', N'management', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (594, N'Mantis', N'mantis', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (595, N'MapInfo', N'mapinfo', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (596, N'Maple', N'maple', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (597, N'MapReduce', N'mapreduce', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (598, N'MariaDB', N'mariadb', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (599, N'Marketing', N'marketing', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (600, N'Marketing digital', N'marketing-digital', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (601, N'Master Data Management (MDM)', N'master-data-management-mdm', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (602, N'Material-UI', N'material-ui', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (603, N'Matlab', N'matlab', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (604, N'Matplotlib', N'matplotlib', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (605, N'McAfee', N'mcafee', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (606, N'MDX', N'mdx', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (607, N'Méhari', N'mehari', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (608, N'Meraki', N'meraki', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (609, N'Merise', N'merise', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (610, N'MERN Stack', N'mern-stack', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (611, N'MES (Manufacturing Execution System)', N'mes-manufacturing-execution-system', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (612, N'Metasploit', N'metasploit', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (613, N'Méthode Agile', N'methode-agile', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (614, N'Méthode de Monte-Carlo', N'methode-de-monte-carlo', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (615, N'MFA', N'mfa', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (616, N'Microservices', N'microservices', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (617, N'Microsoft Access', N'microsoft-access', 1)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (618, N'Microsoft Analysis Services (SSAS)', N'microsoft-analysis-services-ssas', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (619, N'Microsoft Deployment Toolkit (MDT)', N'microsoft-deployment-toolkit-mdt', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (620, N'Microsoft Dynamics', N'microsoft-dynamics', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (621, N'Microsoft Edge', N'microsoft-edge', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (622, N'Microsoft Excel', N'microsoft-excel', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (623, N'Microsoft Exchange Server', N'microsoft-exchange-server', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (624, N'Microsoft Lync', N'microsoft-lync', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (625, N'Microsoft Office', N'microsoft-office', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (626, N'Microsoft OneDrive', N'microsoft-onedrive', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (627, N'Microsoft OneNote', N'microsoft-onenote', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (628, N'Microsoft Outlook', N'microsoft-outlook', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (629, N'Microsoft Power', N'microsoft-power', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (630, N'Microsoft Power BI', N'microsoft-power-bi', 1)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (631, N'Microsoft Project', N'microsoft-project', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (632, N'Microsoft Publisher', N'microsoft-publisher', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (633, N'Microsoft SQL Server', N'microsoft-sql-server', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (634, N'Microsoft SSIS', N'microsoft-ssis', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (635, N'Microsoft Teams', N'microsoft-teams', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (636, N'Microsoft Visio', N'microsoft-visio', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (637, N'Microsoft Windows', N'microsoft-windows', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (638, N'Microsoft Word', N'microsoft-word', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (639, N'Microstrategy', N'microstrategy', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (640, N'Middleware', N'middleware', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (641, N'Migration', N'migration', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (642, N'Minitab', N'minitab', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (643, N'Mint', N'mint', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (644, N'Miro', N'miro', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (645, N'MOA', N'moa', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (646, N'MobaXterm', N'mobaxterm', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (647, N'Mockito', N'mockito', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (648, N'Modèle Conceptuel des Données (MCD)', N'modele-conceptuel-des-donnees-mcd', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (649, N'Modèle Logique des Donnèes (MLD)', N'modele-logique-des-donnees-mld', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (650, N'Modèle-vue-controleur (MVC)', N'modele-vue-controleur-mvc', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (651, N'Modélisation', N'modelisation', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (652, N'ModelSim', N'modelsim', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (653, N'MOE', N'moe', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (654, N'Mongodb', N'mongodb', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (655, N'Mongoose', N'mongoose', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (656, N'Monitoring', N'monitoring', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (657, N'Motion design', N'motion-design', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (658, N'Mozilla Firefox', N'mozilla-firefox', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (659, N'MPLS (MultiProtocol Label Switching)', N'mpls-multiprotocol-label-switching', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (660, N'MQTT (Message Queuing Telemetry Transport)', N'mqtt-message-queuing-telemetry-transport', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (661, N'MRP (Material Requirements Planning)', N'mrp-material-requirements-planning', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (662, N'MS-DOS', N'ms-dos', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (663, N'MSBI', N'msbi', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (664, N'Multiple Virtual Storage (MVS)', N'multiple-virtual-storage-mvs', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (665, N'MVVM (Model View ViewModel)', N'mvvm-model-view-viewmodel', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (666, N'MySQL', N'mysql', 1)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (667, N'MySQL Workbench', N'mysql-workbench', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (668, N'Nagios', N'nagios', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (669, N'Naive Bayes', N'naive-bayes', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (670, N'NAS', N'nas', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (671, N'NAS Synology', N'nas-synology', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (672, N'Natural Language Processing (NLP)', N'natural-language-processing-nlp', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (673, N'Neo4j', N'neo4j', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (674, N'Nessus', N'nessus', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (675, N'NestJS', N'nestjs', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (676, N'Net Promoter Score (NPS)', N'net-promoter-score-nps', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (677, N'NetApp', N'netapp', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (678, N'NetBackup', N'netbackup', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (679, N'NetBeans', N'netbeans', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (680, N'Netgear', N'netgear', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (681, N'Network', N'network', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (682, N'Network address translation (NAT)', N'network-address-translation-nat', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (683, N'Network and Information System Security (NIS)', N'network-and-information-system-security-nis', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (684, N'Network Time Protocol (NTP)', N'network-time-protocol-ntp', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (685, N'Neural networks', N'neural-networks', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (686, N'Next Generation Network (NGN)', N'next-generation-network-ngn', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (687, N'Next.js', N'next-js', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (688, N'Nextcloud', N'nextcloud', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (689, N'Nexus', N'nexus', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (690, N'NFS (Network File System)', N'nfs-network-file-system', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (691, N'Nginx', N'nginx', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (692, N'NIST', N'nist', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (693, N'NLTK', N'nltk', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (694, N'Nmap', N'nmap', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (695, N'Node.js', N'node-js', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (696, N'Norton Security', N'norton-security', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (697, N'Nosql', N'nosql', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (698, N'Notepad++', N'notepad', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (699, N'Notion', N'notion', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (700, N'Novell', N'novell', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (701, N'npm', N'npm', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (702, N'NTFS', N'ntfs', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (703, N'Numpy', N'numpy', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (704, N'Nutanix', N'nutanix', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (705, N'Nuxt.js', N'nuxt-js', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (706, N'Object-Relational Mapping (ORM)', N'object-relational-mapping-orm', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (707, N'Objective-c', N'objective-c', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (708, N'Objet de stratégie de groupe (GPO)', N'objet-de-strategie-de-groupe-gpo', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (709, N'Ocaml', N'ocaml', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (710, N'OCR (Optical Character Recognition)', N'ocr-optical-character-recognition', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (711, N'OCS Inventory', N'ocs-inventory', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (712, N'Octave', N'octave', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (713, N'ODI Oracle Data Integrator', N'odi-oracle-data-integrator', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (714, N'Odoo', N'odoo', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (715, N'OLAP (Online Analytical Processing)', N'olap-online-analytical-processing', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (716, N'Open Shortest Path First (OSPF)', N'open-shortest-path-first-ospf', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (717, N'Open Source', N'open-source', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (718, N'Open-source Ticket Request System (OTRS)', N'open-source-ticket-request-system-otrs', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (719, N'OpenCV', N'opencv', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (720, N'OpenGl', N'opengl', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (721, N'OpenLDAP', N'openldap', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (722, N'OpenOffice', N'openoffice', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (723, N'Openshift', N'openshift', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (724, N'OpenSSL', N'openssl', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (725, N'OpenStack', N'openstack', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (726, N'OpenVPN', N'openvpn', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (727, N'OPEX', N'opex', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (728, N'Oracle', N'oracle', 1)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (729, N'Oracle Database', N'oracle-database', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (730, N'Oracle forms', N'oracle-forms', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (731, N'Oracle SQL Developer', N'oracle-sql-developer', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (732, N'Oracle VM VirtualBox', N'oracle-vm-virtualbox', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (733, N'Oracle WebLogic Server', N'oracle-weblogic-server', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (734, N'Organisation', N'organisation', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (735, N'Organisation autonome décentralisée (DAO)', N'organisation-autonome-decentralisee-dao', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (736, N'OSI (Open Systems Interconnection)', N'osi-open-systems-interconnection', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (737, N'OSINT', N'osint', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (738, N'OSS', N'oss', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (739, N'OVHcloud', N'ovhcloud', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (740, N'OWASP', N'owasp', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (741, N'PaaS (Platform-as-a-Service)', N'paas-platform-as-a-service', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (742, N'PABX', N'pabx', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (743, N'Palo Alto', N'palo-alto', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (744, N'Panda Cloud Antivirus', N'panda-cloud-antivirus', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (745, N'Pandas', N'pandas', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (746, N'Pare-feu', N'pare-feu', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (747, N'Pareto', N'pareto', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (748, N'Pascal', N'pascal', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (749, N'PAT', N'pat', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (750, N'PC', N'pc', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (751, N'PDCA (Plan Do Check Act)', N'pdca-plan-do-check-act', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (752, N'PDF', N'pdf', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (753, N'PDH (Plesiochronous Digital Hierarchy)', N'pdh-plesiochronous-digital-hierarchy', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (754, N'Pentaho', N'pentaho', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (755, N'Pentesting', N'pentesting', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (756, N'Perl (langage)', N'perl-langage', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (757, N'PERT', N'pert', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (758, N'pfSense', N'pfsense', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (759, N'pgAdmin', N'pgadmin', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (760, N'PHP', N'php', 1)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (761, N'phpMyAdmin', N'phpmyadmin', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (762, N'PhpStorm', N'phpstorm', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (763, N'PHPUnit', N'phpunit', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (764, N'PicsArt Photo Studio', N'picsart-photo-studio', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (765, N'Pilotage', N'pilotage', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (766, N'PL/pgSQL', N'pl-pgsql', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (767, N'PL/SQL', N'pl-sql', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (768, N'Plan de continuité d''activité (PCA)', N'plan-de-continuite-dactivite-pca', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (769, N'Plan de reprise d''activité (PRA)', N'plan-de-reprise-dactivite-pra', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (770, N'Planification', N'planification', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (771, N'Plesk', N'plesk', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (772, N'PLM (Product Lifecycle Management)', N'plm-product-lifecycle-management', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (773, N'Plotly', N'plotly', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (774, N'Point-to-Point Protocol (PPP)', N'point-to-point-protocol-ppp', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (775, N'Politique de sécurité du système d''information (PSSI)', N'politique-de-securite-du-systeme-dinformation-pssi', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (776, N'Polycom', N'polycom', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (777, N'POP', N'pop', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (778, N'Postfix', N'postfix', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (779, N'PostGIS', N'postgis', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (780, N'PostgreSQL', N'postgresql', 1)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (781, N'Postman', N'postman', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (782, N'Power Apps', N'power-apps', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (783, N'Power Automate', N'power-automate', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (784, N'Power BI Desktop', N'power-bi-desktop', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (785, N'Power Pivot', N'power-pivot', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (786, N'Power Query', N'power-query', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (787, N'PowerAMC', N'poweramc', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (788, N'Powerpoint', N'powerpoint', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (789, N'Powershell', N'powershell', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (790, N'PrestaShop', N'prestashop', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (791, N'Preuve de concept (POC)', N'preuve-de-concept-poc', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (792, N'Prezi', N'prezi', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (793, N'PrimeFaces', N'primefaces', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (794, N'Prince2', N'prince2', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (795, N'Product Information Management (PIM)', N'product-information-management-pim', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (796, N'Produit minimum viable (MVP)', N'produit-minimum-viable-mvp', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (797, N'Programmation', N'programmation', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (798, N'Programmation Orientée Objet (POO)', N'programmation-orientee-objet-poo', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (799, N'Project Portfolio Management (PPM)', N'project-portfolio-management-ppm', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (800, N'Prolog', N'prolog', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (801, N'Prometheus', N'prometheus', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (802, N'Proteus', N'proteus', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (803, N'Protocole AAA', N'protocole-aaa', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (804, N'Proxmox', N'proxmox', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (805, N'Proxy', N'proxy', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (806, N'PRTG Network Monitor', N'prtg-network-monitor', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (807, N'PSIM', N'psim', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (808, N'PSpice', N'pspice', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (809, N'Public Key Infrastructure (PKI)', N'public-key-infrastructure-pki', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (810, N'Publication Assistée par Ordinateur (PAO)', N'publication-assistee-par-ordinateur-pao', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (811, N'Puppet', N'puppet', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (812, N'PuTTY', N'putty', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (813, N'PyCharm', N'pycharm', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (814, N'PySpark', N'pyspark', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (815, N'pytest', N'pytest', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (816, N'Python', N'python', 1)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (817, N'Pytorch', N'pytorch', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (818, N'QGIS', N'qgis', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (819, N'QHSE', N'qhse', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (820, N'Qlik', N'qlik', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (821, N'Qlik Sense', N'qlik-sense', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (822, N'Qlikview', N'qlikview', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (823, N'QNAP', N'qnap', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (824, N'QRadar', N'qradar', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (825, N'QT', N'qt', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (826, N'Qt Creator', N'qt-creator', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (827, N'Quality of service (QoS)', N'quality-of-service-qos', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (828, N'Qualys', N'qualys', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (829, N'R (langage)', N'r-langage', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (830, N'RabbitMQ', N'rabbitmq', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (831, N'RACI', N'raci', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (832, N'Radio-identification (RFID)', N'radio-identification-rfid', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (833, N'RADIUS (Remote Authentication Dial-In User Service)', N'radius-remote-authentication-dial-in-user-service', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (834, N'RAID', N'raid', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (835, N'Random Forest', N'random-forest', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (836, N'Raspberry Pi', N'raspberry-pi', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (837, N'Raster Imaging Processor (RIP)', N'raster-imaging-processor-rip', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (838, N'Rational Rose', N'rational-rose', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (839, N'RDBMS (Relational Database Management System)', N'rdbms-relational-database-management-system', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (840, N'RDP (Remote Desktop Protocol)', N'rdp-remote-desktop-protocol', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (841, N'React', N'react', 1)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (842, N'React Native', N'react-native', 1)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (843, N'Réalité augmentée', N'realite-augmentee', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (844, N'Recette', N'recette', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (845, N'RECHERCHEV', N'recherchev-1', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (846, N'Recrutement', N'recrutement', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (847, N'Recurrent Neural Network (RNN)', N'recurrent-neural-network-rnn', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (848, N'Red Hat Linux', N'red-hat-linux', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (849, N'Rédaction', N'redaction', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (850, N'Redis', N'redis', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (851, N'Redmine', N'redmine', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (852, N'Redux', N'redux', 1)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (853, N'Redux Toolkit', N'redux-toolkit', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (854, N'Régression', N'regression', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (855, N'Régression linéaire', N'regression-lineaire', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (856, N'Régression logistique', N'regression-logistique', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (857, N'Relation client', N'relation-client', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (858, N'Remedy', N'remedy', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (859, N'Reporting', N'reporting', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (860, N'Réseau de stockage SAN', N'reseau-de-stockage-san', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (861, N'Réseau FTTH', N'reseau-ftth', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (862, N'Réseau numérique à intégration de services', N'reseau-numerique-a-integration-de-services', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (863, N'Réseau téléphonique commuté (RTC))', N'reseau-telephonique-commute-rtc', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (864, N'Réseaux', N'reseaux', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (865, N'Réseaux sociaux', N'reseaux-sociaux', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (866, N'Resource Description Framework (RDF)', N'resource-description-framework-rdf', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (867, N'Responsabilité Sociétale des Entreprises (RSE)', N'responsabilite-societale-des-entreprises-rse', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (868, N'Responsive Web Design', N'responsive-web-design', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (869, N'Ressources humaines', N'ressources-humaines', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (870, N'Rest', N'rest', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (871, N'Retour sur investissement (ROI)', N'retour-sur-investissement-roi', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (872, N'Rétrofit', N'retrofit', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (873, N'Reverse proxy', N'reverse-proxy', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (874, N'Revit', N'revit', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (875, N'RF', N'rf', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (876, N'Rgpd', N'rgpd', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (877, N'RMAN', N'rman', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (878, N'Robot Framework', N'robot-framework', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (879, N'Robot Operating System (ROS)', N'robot-operating-system-ros', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (880, N'Routage', N'routage', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (881, N'Routage IP', N'routage-ip', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (882, N'Routage Statique', N'routage-statique', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (883, N'Routeurs Cisco', N'routeurs-cisco', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (884, N'Routing & Switching (R&S)', N'routing-switching-rs', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (885, N'RPA (Robotic Process Automation)', N'rpa-robotic-process-automation', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (886, N'RPG (Report Program Generator)', N'rpg-report-program-generator', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (887, N'RStudio', N'rstudio', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (888, N'RTP', N'rtp', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (889, N'Ruby', N'ruby', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (890, N'Ruby on Rails', N'ruby-on-rails', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (891, N'Run', N'run', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (892, N'Rust', N'rust', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (893, N'RxJava', N'rxjava', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (894, N'RxJS', N'rxjs', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (895, N'SaaS', N'saas', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (896, N'Safe', N'safe', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (897, N'Sage 100', N'sage-100', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (898, N'Sage Paie', N'sage-paie', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (899, N'Sage x3', N'sage-x3', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (900, N'Salesforce Sales Cloud', N'salesforce-sales-cloud', 1)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (901, N'Samba', N'samba', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (902, N'SAP', N'sap', 1)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (903, N'Sap BO', N'sap-bo', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (904, N'SAP BW', N'sap-bw', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (905, N'SAP Fiori', N'sap-fiori', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (906, N'SAP HANA', N'sap-hana-1', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (907, N'SAP MM', N'sap-mm', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (908, N'SAP R/3', N'sap-r-3-4', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (909, N'SAP S/4HANA', N'sap-s-4hana-2', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (910, N'SAS', N'sas', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (911, N'Sass', N'sass', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (912, N'Sauvegarde', N'sauvegarde', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (913, N'SCADA', N'scada', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (914, N'Scala', N'scala', 1)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (915, N'SCCM', N'sccm', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (916, N'Sciforma', N'sciforma', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (917, N'Scikit-learn', N'scikit-learn', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (918, N'Scilab', N'scilab', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (919, N'SciPy', N'scipy', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (920, N'SCM (Supply Chain Management)', N'scm-supply-chain-management', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (921, N'Scrapy', N'scrapy', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (922, N'Scripting', N'scripting', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (923, N'Scrum', N'scrum', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (924, N'SCSS', N'scss', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (925, N'SD-WAN', N'sd-wan', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (926, N'SDH (Synchronous Digital Hierarchy)', N'sdh-synchronous-digital-hierarchy', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (927, N'SDN (software defined network)', N'sdn-software-defined-network', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (928, N'SEA (Search Engine Advertising)', N'sea-search-engine-advertising', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (929, N'Seaborn', N'seaborn', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (930, N'Search Engine Marketing (SEM)', N'search-engine-marketing-sem', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (931, N'Secure Shell (SSH)', N'secure-shell-ssh', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (932, N'Secure Socket Layer (SSL)', N'secure-socket-layer-ssl', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (933, N'Sécurité informatique', N'securite-informatique', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (934, N'Security Information Event Management (SIEM)', N'security-information-event-management-siem', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (935, N'Selenium', N'selenium', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (936, N'Selenium IDE', N'selenium-ide', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (937, N'Selenium WebDriver', N'selenium-webdriver', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (938, N'Semrush', N'semrush', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (939, N'Sendinblue', N'sendinblue', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (940, N'SEO', N'seo', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (941, N'Sequelize', N'sequelize', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (942, N'Serveur', N'serveur', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (943, N'Serveur web', N'serveur-web', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (944, N'Service client', N'service-client', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (945, N'Service Cloud', N'service-cloud', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (946, N'ServiceNow', N'servicenow', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (947, N'Servlet', N'servlet', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (948, N'Session Initiation Protocol (SIP)', N'session-initiation-protocol-sip', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (949, N'Seven', N'seven', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (950, N'SFML', N'sfml', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (951, N'SFTP (Secure File Transfer Protocol)', N'sftp-secure-file-transfer-protocol', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (952, N'SGBD', N'sgbd', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (953, N'SGBDR', N'sgbdr', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (954, N'SharePoint', N'sharepoint', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (955, N'SharePoint Online', N'sharepoint-online', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (956, N'Shell', N'shell', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (957, N'Shell Unix', N'shell-unix', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (958, N'Shiny', N'shiny', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (959, N'Shopify', N'shopify', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (960, N'SI', N'si', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (961, N'Siebel', N'siebel', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (962, N'Siemens', N'siemens', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (963, N'SIG (Systémes d''Information Géographique)', N'sig-systemes-dinformation-geographique', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (964, N'Silae', N'silae', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (965, N'Simple DirectMedia Layer (SDL)', N'simple-directmedia-layer-sdl', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (966, N'Simulink', N'simulink', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (967, N'Single Sign-on (SSO)', N'single-sign-on-sso', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (968, N'SIRH', N'sirh', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (969, N'Site web', N'site-web', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (970, N'Six Sigma', N'six-sigma', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (971, N'Sketch', N'sketch', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (972, N'SketchUp', N'sketchup', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (973, N'Skype', N'skype', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (974, N'SLA', N'sla', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (975, N'Slack', N'slack', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (976, N'Smarty', N'smarty', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (977, N'SMB (Server Message Block)', N'smb-server-message-block', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (978, N'SMED', N'smed', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (979, N'SMO (Social Media Optimization)', N'smo-social-media-optimization', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (980, N'SMS', N'sms', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (981, N'SMSI', N'smsi', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (982, N'SMTP (Simple Mail Transfer Protocol)', N'smtp-simple-mail-transfer-protocol', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (983, N'SNMP (Simple Network Management Protocol)', N'snmp-simple-network-management-protocol', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (984, N'Snort', N'snort', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (985, N'Snow', N'snow', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (986, N'Snowflake', N'snowflake', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (987, N'SOA (Service Oriented Architecture)', N'soa-service-oriented-architecture', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (988, N'Soap', N'soap', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (989, N'SoapUI', N'soapui', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (990, N'SOC (Security Operation Center)', N'soc-security-operation-center', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (991, N'Socket', N'socket', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (992, N'Socket.IO', N'socket-io', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (993, N'Software', N'software', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (994, N'Software Development LifeCycle (SDLC)', N'software-development-lifecycle-sdlc', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (995, N'Solaris', N'solaris', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (996, N'SolarWinds', N'solarwinds', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (997, N'Solidity', N'solidity', 1)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (998, N'SolidWorks', N'solidworks', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (999, N'Sonarqube', N'sonarqube', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1000, N'Sophos', N'sophos', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1001, N'SOQL', N'soql', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1002, N'Sourcetree', N'sourcetree', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1003, N'SpaCy', N'spacy', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1004, N'Spanning Tree Protocol', N'spanning-tree-protocol', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1005, N'Spark Streaming', N'spark-streaming', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1006, N'SPARQL', N'sparql', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1007, N'Spécifications Fonctionnelles Détaillées (SFD)', N'specifications-fonctionnelles-detaillees-sfd', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1008, N'Sphinx', N'sphinx', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1009, N'Splunk', N'splunk', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1010, N'Spotfire', N'spotfire', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1011, N'Spring', N'spring', 1)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1012, N'Spring Batch', N'spring-batch', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1013, N'Spring Data', N'spring-data', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1014, N'Spring MVC', N'spring-mvc', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1015, N'Spring Security', N'spring-security', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1016, N'Springboot', N'springboot', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1017, N'Sprint Planning', N'sprint-planning', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1018, N'SPSS', N'spss', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1019, N'Spyder', N'spyder', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1020, N'SQL', N'sql', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1021, N'SQL Server Management Studio', N'sql-server-management-studio', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1022, N'SQL Server Reporting Services (SSRS)', N'sql-server-reporting-services-ssrs', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1023, N'SQLAlchemy', N'sqlalchemy', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1024, N'SQLite', N'sqlite', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1025, N'Squash', N'squash', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1026, N'Squash TM', N'squash-tm', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1027, N'Squid', N'squid', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1028, N'SS7', N'ss7', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1029, N'SST', N'sst', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1030, N'Stack', N'stack', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1031, N'StarUML', N'staruml', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1032, N'Stata', N'stata', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1033, N'Statistiques', N'statistiques', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1034, N'STEP 7', N'step-7', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1035, N'Stm32', N'stm32', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1036, N'Stockage', N'stockage', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1037, N'Stormshield', N'stormshield', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1038, N'STP', N'stp', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1039, N'Stratégie', N'strategie', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1040, N'Streamlit', N'streamlit', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1041, N'Stripe', N'stripe', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1042, N'Sublime Text', N'sublime-text', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1043, N'Supervision', N'supervision', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1044, N'Supply Chain', N'supply-chain', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1045, N'Support informatique', N'support-informatique', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1046, N'Support technique', N'support-technique', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1047, N'Support utilisateurs', N'support-utilisateurs', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1048, N'Support-Vector Machine (SVM)', N'support-vector-machine-svm', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1049, N'Suricata', N'suricata', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1050, N'SUSE', N'suse', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1051, N'Swagger', N'swagger', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1052, N'SWIFT', N'swift', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1053, N'SwiftUI', N'swiftui', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1054, N'Swing (Java)', N'swing-java', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1055, N'Switch Cisco', N'switch-cisco', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1056, N'Sybase', N'sybase', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1057, N'Symantec', N'symantec', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1058, N'Symfony', N'symfony', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1059, N'Synology', N'synology', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1060, N'Syslog', N'syslog', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1061, N'System Center Operations Manager (SCOM)', N'system-center-operations-manager-scom', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1062, N'Système d''exploitation', N'systeme-dexploitation', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1063, N'Système de détection d''intrusion (IDS)', N'systeme-de-detection-dintrusion-ids', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1064, N'Systéme de prévention des intrusions (IPS)', N'systeme-de-prevention-des-intrusions-ips', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1065, N'Tableau croisé dynamique', N'tableau-croise-dynamique', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1066, N'Tableau de bord', N'tableau-de-bord', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1067, N'Tableau Desktop', N'tableau-desktop', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1068, N'Tableau software', N'tableau-software', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1069, N'Tailwind CSS', N'tailwind-css', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1070, N'Talend', N'talend', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1071, N'Talentsoft', N'talentsoft', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1072, N'TCP/IP', N'tcp-ip', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1073, N'tcpdump', N'tcpdump', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1074, N'TDMA', N'tdma', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1075, N'TeamViewer', N'teamviewer', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1076, N'Teamwork', N'teamwork', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1077, N'Technologies de l''information et de la communication (TIC)', N'technologies-de-l-information-et-de-la-communication-tic', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1078, N'Technologies Web', N'technologies-web', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1079, N'Telecom', N'telecom', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1080, N'Telnet', N'telnet', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1081, N'Tensorflow', N'tensorflow', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1082, N'Teradata', N'teradata', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1083, N'Terraform', N'terraform', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1084, N'Test unitaire', N'test-unitaire', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1085, N'Test-Driven Development (TDD)', N'test-driven-development-tdd', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1086, N'TestLink', N'testlink', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1087, N'TestNG', N'testng', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1088, N'Text mining', N'text-mining', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1089, N'Three.js', N'three-js', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1090, N'Thunderbird', N'thunderbird', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1091, N'Thymeleaf', N'thymeleaf', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1092, N'TIA Portal', N'tia-portal', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1093, N'Ticketing', N'ticketing', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1094, N'Tierce Maintenance Applicative (TMA)', N'tierce-maintenance-applicative-tma', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1095, N'Time series', N'time-series', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1096, N'TINA', N'tina', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1097, N'Tkinter', N'tkinter', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1098, N'Toad', N'toad', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1099, N'TOGAF', N'togaf', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1100, N'ToIP', N'toip', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1101, N'Transact-SQL', N'transact-sql', 1)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1102, N'Transformation digitale', N'transformation-digitale', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1103, N'Transmission Control Protocol (TCP)', N'transmission-control-protocol-tcp', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1104, N'Transport Layer Security (TLS)', N'transport-layer-security-tls', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1105, N'Trello', N'trello', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1106, N'Trésorerie', N'tresorerie', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1107, N'Turbo Pascal', N'turbo-pascal', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1108, N'TVA', N'tva', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1109, N'Twig', N'twig', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1110, N'Twitter', N'twitter', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1111, N'TypeScript', N'typescript', 1)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1112, N'UART', N'uart', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1113, N'Ubiquiti', N'ubiquiti', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1114, N'Ubuntu Server', N'ubuntu-server', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1115, N'UDP (User Datagram Protocol)', N'udp-user-datagram-protocol', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1116, N'Ui design', N'ui-design', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1117, N'UIkit', N'uikit', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1118, N'UiPath', N'uipath', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1119, N'UML', N'uml', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1120, N'UMTS', N'umts', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1121, N'Unity', N'unity', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1122, N'UNIX', N'unix', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1123, N'Unreal Engine', N'unreal-engine', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1124, N'USB', N'usb', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1125, N'User acceptance testing (UAT)', N'user-acceptance-testing-uat', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1126, N'User story', N'user-story', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1127, N'Utilisateurs', N'utilisateurs', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1128, N'UX design', N'ux-design', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1129, N'Vagrant', N'vagrant', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1130, N'Vanilla JS', N'vanilla-js', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1131, N'VBA', N'vba', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1132, N'VBScript', N'vbscript', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1133, N'vCenter', N'vcenter', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1134, N'Veeam', N'veeam', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1135, N'Veeam Backup & Replication', N'veeam-backup-replication', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1136, N'Vegas Pro', N'vegas-pro', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1137, N'Vente', N'vente', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1138, N'Versioning', N'versioning', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1139, N'VHDL', N'vhdl', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1140, N'Vim', N'vim', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1141, N'Virtual machine', N'virtual-machine', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1142, N'Virtual Network Computing', N'virtual-network-computing', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1143, N'Virtual Private Server (VPS)', N'virtual-private-server-vps', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1144, N'Virtual Router Redundancy Protocol (VRRP)', N'virtual-router-redundancy-protocol-vrrp', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1145, N'Virtual routing and forwarding (VRF)', N'virtual-routing-and-forwarding-vrf', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1146, N'Virtualisation', N'virtualisation', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1147, N'Visual Basic .NET', N'visual-basic-net', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1148, N'Visual Basic (VB)', N'visual-basic-vb', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1149, N'Visual C++', N'visual-c', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1150, N'Visual Paradigm', N'visual-paradigm', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1151, N'Visual Studio Code', N'visual-studio-code', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1152, N'Visual TOM', N'visual-tom', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1153, N'Visualforce', N'visualforce', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1154, N'VLAN', N'vlan', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1155, N'VLAN Trunking Protocol', N'vlan-trunking-protocol', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1156, N'VLSM', N'vlsm', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1157, N'VMware', N'vmware', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1158, N'VMware AirWatch', N'vmware-airwatch', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1159, N'VMware ESX', N'vmware-esx', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1160, N'VMware vSphere', N'vmware-vsphere', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1161, N'VMware Workstation', N'vmware-workstation', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1162, N'VoIP', N'voip', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1163, N'VPC (Virtual Private Cloud)', N'vpc-virtual-private-cloud', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1164, N'VPN', N'vpn', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1165, N'VPN IPsec', N'vpn-ipsec', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1166, N'VPN SSL', N'vpn-ssl', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1167, N'VSAT', N'vsat', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1168, N'Vue.js', N'vue-js', 1)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1169, N'Vuetify', N'vuetify', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1170, N'Vuex', N'vuex', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1171, N'WAMP (Windows Apache MySQL PHP)', N'wamp-windows-apache-mysql-php', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1172, N'WampServer', N'wampserver', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1173, N'WAN (Wide Area Network)', N'wan-wide-area-network', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1174, N'WatchGuard', N'watchguard', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1175, N'Waterfall', N'waterfall', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1176, N'WBS (Work Breakdown Structure)', N'wbs-work-breakdown-structure', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1177, N'WDM (Wavelength Division Multiplexing)', N'wdm-wavelength-division-multiplexing', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1178, N'Web', N'web', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1179, N'Web analytics', N'web-analytics', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1180, N'Web API', N'web-api', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1181, N'Web Application Firewall (WAF)', N'web-application-firewall-waf', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1182, N'Web design', N'web-design', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1183, N'Web marketing', N'web-marketing', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1184, N'Web mobile', N'web-mobile', 1)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1185, N'Web scraping', N'web-scraping', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1186, N'Web service', N'web-service', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1187, N'Webflow', N'webflow', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1188, N'Webi', N'webi', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1189, N'webpack', N'webpack', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1190, N'WebSphere', N'websphere', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1191, N'WebStorm', N'webstorm', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1192, N'Weka', N'weka', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1193, N'Wi-Fi', N'wi-fi', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1194, N'WildFly', N'wildfly', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1195, N'WiMAX', N'wimax', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1196, N'WinDev', N'windev', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1197, N'WINDEV Mobile', N'windev-mobile', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1198, N'Windows Client', N'windows-client', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1199, N'Windows Communication Foundation (WCF)', N'windows-communication-foundation-wcf', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1200, N'Windows Deployment Services (WDS)', N'windows-deployment-services-wds', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1201, N'Windows Forms', N'windows-forms', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1202, N'Windows Internet Name Service (WINS)', N'windows-internet-name-service-wins', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1203, N'Windows NT', N'windows-nt', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1204, N'Windows Presentation Foundation (WPF)', N'windows-presentation-foundation-wpf', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1205, N'Windows Server', N'windows-server', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1206, N'WinSCP', N'winscp', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1207, N'Wireframing', N'wireframing', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1208, N'Wireshark', N'wireshark', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1209, N'Wix', N'wix', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1210, N'WLAN', N'wlan', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1211, N'WLangage', N'wlangage', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1212, N'WMS (Warehouse Management System)', N'wms-warehouse-management-system', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1213, N'WooCommerce', N'woocommerce', 1)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1214, N'Wordpress', N'wordpress', 1)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1215, N'Workday', N'workday', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1216, N'Workflow', N'workflow', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1217, N'Wrike', N'wrike', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1218, N'WSDL (Web Services Description Language)', N'wsdl-web-services-description-language', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1219, N'WSUS (Windows Server Update Services)', N'wsus-windows-server-update-services', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1220, N'X++ (langage)', N'x-langage', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1221, N'Xamarin', N'xamarin', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1222, N'Xamarin.Forms', N'xamarin-forms', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1223, N'XAML', N'xaml', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1224, N'XAMPP', N'xampp', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1225, N'Xcode', N'xcode', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1226, N'xDSL', N'xdsl', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1227, N'XGBoost', N'xgboost', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1228, N'XHTML', N'xhtml', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1229, N'Xilinx', N'xilinx', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1230, N'XiVO', N'xivo', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1231, N'XMind', N'xmind', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1232, N'XML', N'xml', 1)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1233, N'Xpath', N'xpath', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1234, N'Xray', N'xray', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1235, N'XSD', N'xsd', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1236, N'XSL', N'xsl', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1237, N'XSLT', N'xslt', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1238, N'YAML', N'yaml', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1239, N'Yammer', N'yammer', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1240, N'Yarn', N'yarn', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1241, N'Youtube', N'youtube', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1242, N'z/OS', N'z-os', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1243, N'Zabbix', N'zabbix', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1244, N'Zendesk', N'zendesk', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1245, N'Zeplin', N'zeplin', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1246, N'Zimbra', N'zimbra', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1247, N'Zoho', N'zoho', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1248, N'Zone démilitarisée (DMZ)', N'zone-demilitarisee-dmz', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1249, N'Zoom', N'zoom', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1250, N'Zyxel', N'zyxel', 0)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1251, N'C#', N'c-sharp', 1)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1252, N'Golang', N'golang', 1)
GO
INSERT [config].[Skills] ([Id], [Name], [Code], [HasImage]) VALUES (1254, N'D3 js', N'd3js', 1)
GO
SET IDENTITY_INSERT [config].[Skills] OFF
GO
ALTER TABLE [chat].[Candidates] ADD  CONSTRAINT [DF_Candidates_IsConnected]  DEFAULT ((0)) FOR [IsConnected]
GO
ALTER TABLE [config].[Skills] ADD  CONSTRAINT [DF_Skills_HasImage]  DEFAULT ((0)) FOR [HasImage]
GO
