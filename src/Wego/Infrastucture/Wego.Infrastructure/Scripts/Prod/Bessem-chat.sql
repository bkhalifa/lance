
/****** Object:  StoredProcedure [chat].[AddMessage]    Script Date: 16/10/2023 23:10:01 ******/
DROP PROCEDURE [chat].[AddMessage]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE name = 'DF_Candidates_IsConnected')
ALTER TABLE [chat].[Candidates] DROP CONSTRAINT [DF_Candidates_IsConnected]
go 

IF  EXISTS (SELECT * FROM sys.objects WHERE name = 'DF_Messages_IsOpen')
ALTER TABLE [chat].[Messages] DROP CONSTRAINT [DF_Messages_IsOpen]
GO
/****** Object:  Table [chat].[Messages]    Script Date: 16/10/2023 23:10:01 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[chat].[Messages]') AND type in (N'U'))
DROP TABLE [chat].[Messages]
GO
/****** Object:  Table [chat].[MessageFiles]    Script Date: 16/10/2023 23:10:01 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[chat].[MessageFiles]') AND type in (N'U'))
DROP TABLE [chat].[MessageFiles]
GO
/****** Object:  Table [chat].[LinkedUsers]    Script Date: 16/10/2023 23:10:01 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[chat].[LinkedUsers]') AND type in (N'U'))
DROP TABLE [chat].[LinkedUsers]
GO
/****** Object:  Table [chat].[Candidates]    Script Date: 16/10/2023 23:10:01 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[chat].[Candidates]') AND type in (N'U'))
DROP TABLE [chat].[Candidates]
GO
/****** Object:  Table [chat].[Candidates]    Script Date: 16/10/2023 23:10:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [chat].[Candidates](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[ProfileId] [bigint] NOT NULL,
	[Name] [nvarchar](250) NOT NULL,
	[Email] [nvarchar](250) NOT NULL,
	[IsConnected] [bit] NOT NULL,
	[ConnectionId] [nvarchar](50) NULL,
	[ModifiedDate] [datetime] NULL,
 CONSTRAINT [PK_Candidates] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [chat].[LinkedUsers]    Script Date: 16/10/2023 23:10:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [chat].[LinkedUsers](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[ProfileIdA] [bigint] NOT NULL,
	[ProfileIdB] [bigint] NOT NULL,
	[Code] [nvarchar](100) NOT NULL,
	[LastMessage] [nvarchar](250) NULL,
	[IsOpen] [bit] NOT NULL,
	[SendBy] [bigint] NULL,
	[ModifiedDate] [datetime] NOT NULL,
 CONSTRAINT [PK_LinkedUsers] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [chat].[MessageFiles]    Script Date: 16/10/2023 23:10:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [chat].[MessageFiles](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[FileName] [nvarchar](100) NOT NULL,
	[FileData] [varbinary](max) NOT NULL,
	[ContentType] [nvarchar](50) NOT NULL,
	[Size] [float] NOT NULL,
 CONSTRAINT [PK_Files] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [chat].[Messages]    Script Date: 16/10/2023 23:10:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [chat].[Messages](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[ProfileFromId] [int] NOT NULL,
	[ProfileToId] [int] NOT NULL,
	[Code] [nvarchar](100) NULL,
	[MsgContent] [nvarchar](500) NULL,
	[IsOpen] [bit] NOT NULL,
	[FileId] [bigint] NULL,
	[CreationDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Messages] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [chat].[Candidates] ADD  CONSTRAINT [DF_Candidates_IsConnected]  DEFAULT ((0)) FOR [IsConnected]
GO
ALTER TABLE [chat].[Messages] ADD  CONSTRAINT [DF_Messages_IsOpen]  DEFAULT ((0)) FOR [IsOpen]
GO
/****** Object:  StoredProcedure [chat].[AddMessage]    Script Date: 16/10/2023 23:10:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [chat].[AddMessage]
	@ProfileFromId BIGINT,
	@ProfileToId BIGINT,
    @FileId BIGINT = null,
	@Code NVARCHAR(100),
	@MsgContent NVARCHAR(500),
	@IsOpen bit = 0
AS
BEGIN

	INSERT INTO [chat].[Messages] (
	[ProfileFromId] ,
	[ProfileToId] ,
	[Code] ,
	[MsgContent] ,
    [FileId],
	[IsOpen] ,
	[CreationDate]) 
    VALUES (@profileFromId, @profileToId, @code, @msgContent, @FileId, @isOpen, GETUTCDATE())

    IF EXISTS (SELECT 1  FROM chat.LinkedUsers WHERE Code = @Code)
        UPDATE chat.LinkedUsers
        SET    LastMessage = @MsgContent,
               IsOpen = @IsOpen,
               SendBy = @ProfileFromId,
               ModifiedDate= GETUTCDATE()
        WHERE Code = @Code

    ELSE
        INSERT INTO [chat].[LinkedUsers]
           ([ProfileIdA]
           ,[ProfileIdB]
           ,[Code]
           ,[LastMessage]
           ,[IsOpen]
           ,SendBy
           ,[ModifiedDate])
        VALUES (@profileFromId, @profileToId, @code, @msgContent,@IsOpen, @ProfileFromId, GETUTCDATE())
           
END
GO
