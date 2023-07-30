
/****** Object:  Schema [profile]    Script Date: 30/07/2023 13:19:50 ******/
CREATE SCHEMA [chat]
GO
/****** Object:  Table [chat].[Candidates]    Script Date: 30/07/2023 13:19:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [chat].[Candidates](
	[ProfileId] [bigint] NOT NULL,
	[CandidateName] [nvarchar](250) NOT NULL,
	[CandidateEmail] [nvarchar](250) NOT NULL,
	[IsConnected] [bit] NOT NULL,
	[ConnectionId] [nvarchar](50) NULL,
 CONSTRAINT [PK_Candidates_1] PRIMARY KEY CLUSTERED 
(
	[ProfileId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [chat].[Messages]    Script Date: 30/07/2023 13:19:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [chat].[Messages](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[ProfileFromId] [int] NOT NULL,
	[ProfileToId] [int] NOT NULL,
	[Code] [nvarchar](100) NULL,
	[MsgContent] [nvarchar](500) NOT NULL,
	[IsOpen] [bit] NOT NULL,
	[CreationDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Messages] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [chat].[Recruiters]    Script Date: 30/07/2023 13:19:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [chat].[Recruiters](
	[ProfileId] [bigint] NOT NULL,
	[RecruiterName] [nvarchar](250) NOT NULL,
	[RecruiterEmail] [nvarchar](250) NOT NULL,
	[RecruiterCompany] [nvarchar](250) NOT NULL,
	[IsConnected] [bit] NOT NULL,
 CONSTRAINT [PK_Recruiters_1] PRIMARY KEY CLUSTERED 
(
	[ProfileId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [chat].[Candidates] ADD  CONSTRAINT [DF_Candidates_IsConnected]  DEFAULT ((0)) FOR [IsConnected]
GO
ALTER TABLE [chat].[Messages] ADD  CONSTRAINT [DF_Messages_IsOpen]  DEFAULT ((0)) FOR [IsOpen]
GO
ALTER TABLE [chat].[Recruiters] ADD  CONSTRAINT [DF_Recruiters_IsConnected]  DEFAULT ((0)) FOR [IsConnected]
GO
