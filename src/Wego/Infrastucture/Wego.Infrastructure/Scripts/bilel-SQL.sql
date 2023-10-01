-- =============================================
-- Creation date:   09/09/2023
-- Description:	remove tables users
-- =============================================
 

IF OBJECT_ID(N'[profile].[Languages]', N'U') IS NOT NULL 
  DROP TABLE  [profile].[Languages]
GO

IF OBJECT_ID(N'[profile].[DocVisibility]', N'U') IS NOT NULL 
  DROP TABLE  [profile].[DocVisibility]
GO

IF OBJECT_ID(N'[profile].[Experiences]', N'U') IS NOT NULL 
  DROP TABLE [profile].[Experiences]
GO

 IF OBJECT_ID(N'[profile].[TrainShip]', N'U') IS NOT NULL 
  DROP TABLE [profile].[TrainShip]
 GO

 IF OBJECT_ID(N'[profile].[UserVisibility]', N'U') IS NOT NULL 
  DROP TABLE [profile].[UserVisibility]
 GO
 
IF OBJECT_ID(N'[profile].[Documents]', N'U') IS NOT NULL 
  DROP TABLE [profile].[Documents]
 GO
 
IF OBJECT_ID(N'[profile].[ImageProfile]', N'U') IS NOT NULL 
  DROP TABLE [profile].[ImageProfile]
 GO

 IF OBJECT_ID(N'[chat].[Candidates]', N'U') IS NOT NULL 
  DROP TABLE [chat].[Candidates]
 GO

IF OBJECT_ID(N'[profile].[Profiles]', N'U') IS NOT NULL 
  DROP TABLE [profile].[Profiles]
GO

-- =============================================
-- Creation date:   09/09/2023
-- Description:	add user profiles
-- =============================================

IF OBJECT_ID(N'[profile].[Profiles]', N'U') IS NULL
BEGIN
  CREATE TABLE [profile].[Profiles](
	[Id] [bigint] PRIMARY KEY IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](450) NOT NULL,
	[FirstName] [nvarchar](250) NULL,
	[LastName] [nvarchar](250) NULL,
	[InitialUserName] [varchar] (10) NOT NULL,
	[Email] [nvarchar](250) NOT NULL,
	[PhoneNumber] [int] NULL,
	[CreationDate] [datetime] NOT NULL,
	[UpdateDate] [datetime]  NULL,
	[UsId] [nvarchar](100) NULL,
	[Position] [varchar](100) NULL,
	[Skills] [nvarchar] (max) NULL
	) 
END
GO

IF OBJECT_ID(N'[profile].[ImageProfile]', N'U') IS NULL
BEGIN
CREATE TABLE profile.ImageProfile (
Id BIGINT IDENTITY(1,1) PRIMARY KEY,
ImageData varbinary(max) NOT NULL,
Width TINYINT,
Height TINYINT,
ContentType NVARCHAR(50),
CreationDate datetime NULL,
UpateDate dateTime NULL,
ProfileId BIGINT NULL,
FOREIGN KEY (ProfileId) REFERENCES [profile].[Profiles](Id)
);
END
GO
ALTER TABLE profile.Profiles DROP CONSTRAINT IF EXISTS uniqueusid;
ALTER TABLE profile.Profiles
ADD CONSTRAINT uniqueusid UNIQUE ([UsId])


-- =============================================
-- Creation date:   30/09/2023
-- Description:	add image profiles
-- =============================================

IF OBJECT_ID(N'[profile].[BackGroundImage]', N'U') IS NULL
BEGIN
CREATE TABLE profile.BackGroundImage (
Id BIGINT IDENTITY(1,1) PRIMARY KEY,
ParentId BIGINT NULL,
FileName  NVARCHAR(250) NULL,
Extension NVARCHAR(50) NULL,
ContentType NVARCHAR(50),
BigData varbinary(max)  NULL,
LittleData varbinary(max)  NULL,
Size INT NULL,
Width INT NULL,
Height INT NULL,
CreationDate datetime NULL,
UpDateDate dateTime NULL,
FileType BIT NOT NULL,
)
END
GO