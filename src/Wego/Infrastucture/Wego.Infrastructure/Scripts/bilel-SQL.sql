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
LittleData varbinary(max)  NULL,
BigData varbinary(max)  NULL,
Size INT NULL,
Width INT NULL,
Height INT NULL,
CreationDate datetime NULL,
UpDateDate dateTime NULL,
FileType BIT  NULL,
)
END
GO

IF NOT EXISTS(SELECT 1 FROM sys.columns 
          WHERE Name = N'ProfileId'
         AND Object_ID = Object_ID(N'[profile].[ImageProfile]'))
BEGIN
    ALTER TABLE [dbo].[T_Wedoc_Template_Wed]
    ADD [ProfileId] BIGINT  NULL   
END
GO

 ------------------------------CHAT SCRIPTS 11/11/2023-------------------------------
 -- =============================================
-- Creation date:   11/11/2023
-- Description:	REMOVE TABLE Messages
-- =============================================
 

IF OBJECT_ID(N'[chat].[Messages]', N'U') IS NOT NULL
BEGIN
DROP TABLE [chat].[Messages]
END
GO

-- =============================================
-- Creation date:   11/11/2023
-- Description:	ADD TABLE Messages
-- =============================================
 

IF OBJECT_ID(N'[chat].[WeMessages]', N'U') IS NULL
BEGIN

CREATE TABLE [chat].[WeMessages](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[IsOpen] [bit] NOT NULL,
	[Code] [nvarchar](100) NOT NULL,
	[LastUpdateDate] [datetime] NULL,
	[Message] [nvarchar](MAX) NOT NULL,
	CONSTRAINT ck_message_json CHECK(ISJSON([Message])=1))
END
GO


-- =============================================
-- Creation date:   11/11/2023
-- Description:	PS INSERT CHAT MESSAGES
-- =============================================
 CREATE OR ALTER      PROCEDURE [chat].[Insert_Chat_Message]
	@Code NVARCHAR(100),
	@IsOpen bit = 0, 
	@LastUpdateDate DateTime,
	@Message NVARCHAR(MAX)

AS

BEGIN

	INSERT INTO [chat].[WeMessages]
           ([IsOpen]
           ,[Code]
           ,[LastUpdateDate]
           ,[Message])
     VALUES
           (@IsOpen
           ,@Code
           ,@LastUpdateDate
           ,@Message)

END
GO

-- =============================================
-- Creation date:   11/11/2023
-- Description:	PS SAVE CHAT MESSAGES
-- =============================================

CREATE OR ALTER           PROCEDURE [chat].[Save_Chat_Message]
(
@Code NVARCHAR(100),
@LastUpdateDate DateTime,
@NewMessage NVARCHAR(MAX)
)
AS

BEGIN

DECLARE @selectedMsg NVARCHAR(MAX);
DECLARE @lastDateTimeMessage DATETIME;
DECLARE	@msgId BIGINT;
DECLARE @diffLimitter INT;

SELECT TOP 1 @msgId = m.[Id], @selectedMsg =  m.[MESSAGE] , @lastDateTimeMessage = m.[LastUpdateDate] FROM [chat].[WeMessages] m
WHERE m.Code = @Code
ORDER BY m.LastUpdateDate desc

DECLARE @limitter INT = 1 ;

 SET @diffLimitter = DATEDIFF(day,  @lastDateTimeMessage, @LastUpdateDate)

IF(@diffLimitter IS NOT NULL AND @diffLimitter < @limitter)
BEGIN -- UPDATE
    DECLARE @updatemsg NVARCHAR(MAX) = (SELECT  newMsg.value  from   OPENJSON (@NewMessage, '$') newMsg)
	EXEC [chat].[Update_Chat_Message] 0 , @LastUpdateDate , @selectedMsg , @updatemsg, @msgId
END
 ELSE -- INSERT
BEGIN
   EXEC [chat].[Insert_Chat_Message] @Code, 0, @LastUpdateDate , @NewMessage
END
END

GO
-- =============================================
-- Creation date:   11/11/2023
-- Description:	PS SAVE LINKED SUERS
-- =============================================

CREATE OR ALTER      PROCEDURE [chat].[Save_LinkedUsers]
(
@Code NVARCHAR(100),
@ProfileFromId BIGINT , 
@ProfileToId BIGINT,
@MsgContent NVARCHAR(MAX),
@ModifiedDate DateTime
)
AS

BEGIN

 IF EXISTS (SELECT 1 FROM chat.LinkedUsers WHERE Code = @Code)
BEGIN   --UPDATE
 UPDATE chat.LinkedUsers
        SET    LastMessage = @MsgContent,
               IsOpen = 0,
               SendBy = @ProfileFromId,
               ModifiedDate= @ModifiedDate
        WHERE Code = @Code
 END

 ELSE  -- INSERT

 BEGIN
  INSERT INTO [chat].[LinkedUsers]
           ([ProfileIdA]
           ,[ProfileIdB]
           ,[Code]
           ,[LastMessage]
           ,[IsOpen]
           ,SendBy
           ,[ModifiedDate])
        VALUES (@ProfileFromId, @ProfileToId, @code, @MsgContent,0, @ProfileFromId, @ModifiedDate)
END
END
GO

-- =============================================
-- Creation date:   11/11/2023
-- Description:	PS Select_Last_Message_By_Code
-- =============================================

CREATE OR ALTER             PROCEDURE [chat].[Select_Last_Message_By_Code]
(
@Code NVARCHAR(100)
)
AS

BEGIN

WITH Simple_CTE
AS (
 SELECT TOP 1 p.[Id], p.[LastUpdateDate], p.[Message] FROM [chat].[WeMessages] p 
 WHERE p.Code = @Code
 ORDER BY p.LastUpdateDate desc
 )
SELECT 
Simple_CTE.[Id],
Simple_CTE.[LastUpdateDate],
a.* from Simple_CTE

CROSS APPLY OPENJSON (Simple_CTE.[Message]) WITH (   
              FileId        BIGINT '$.FileId' , 
			  FileName      VARCHAR '$.FileName',
			  ProfileFromId BIGINT '$.ProfileFromId' , 
			  ProfileToId   BIGINT '$.ProfileToId' , 
              MsgContent    NVARCHAR(500)  '$.MsgContent',
			  CreationDate  NVARCHAR(150) '$.CreationDate'
     ) a
ORDER BY  a.CreationDate ASC
           
END
GO

-- =============================================
-- Creation date:   11/11/2023
-- Description:	PS Update Chat Message
-- =============================================

CREATE OR ALTER            PROCEDURE [chat].[Update_Chat_Message]
	(
	@IsOpen bit = 0, 
	@LastUpdateDate DateTime,
	@selectedMsg 	VARCHAR(max),
	@newMesg	VARCHAR(max),
	@msgId BIGINT
	)

AS

BEGIN

	 UPDATE [chat].[WeMessages]
       SET [IsOpen] = @IsOpen ,
	       [LastUpdateDate] = @LastUpdateDate,
		   [Message] = JSON_MODIFY(@selectedMsg, 'append $', JSON_QUERY(@newMesg))
		   WHERE  Id = @msgId
           
END


--************************************************************
-- Creation date:   11/11/2023 
-- Descrition : Porifle Add Column
--************************************************************

-- ADD CountryId
IF COL_LENGTH('[profile].[Profiles]', 'CountryId') IS  NULL
BEGIN
ALTER TABLE  [profile].[Profiles]
ADD  CountryId INT NULL  DEFAULT NULL; 
END
GO

-- ADD SkillS
IF COL_LENGTH('[profile].[Profiles]', '[Skills]') IS NULL
begin
ALTER TABLE [profile].[Profiles]
DROP COLUMN Skills;
end
GO

-- ADD linkLinkedIn
IF COL_LENGTH('[profile].[Profiles]', 'linkLinkedIn') IS  NULL
BEGIN
ALTER TABLE  [profile].[Profiles]
ADD  linkLinkedIn NVARCHAR(150) NULL  DEFAULT NULL; 
END
GO

--************************************************************
-- Creation date:   27/02/2024
-- Descrition : PS Profile : Update profile infos
--************************************************************



CREATE OR ALTER         PROCEDURE [profile].[UpdateProfileInfo](
    @ProfileId BIGINT,
	@FirstName NVARCHAR(50),
	@LastName NVARCHAR(50),
	@PhoneNumber INT,
	@Position NVARCHAR(100),
    @CountryId INT,
	@linkLinkedIn NVARCHAR(100),
	@RegionCode VARCHAR(120)
	)
AS

BEGIN
UPDATE [profile].[Profiles]
   SET [FirstName] = @FirstName,
       [LastName] = @LastName,
       [PhoneNumber] = @PhoneNumber,
       [UpdateDate] = GETDATE(),
       [Position] = @Position,
       [CountryId] = @CountryId,
       [linkLinkedIn] = @linkLinkedIn,
	   [RegionCode] = @RegionCode
 WHERE 
     [Id] = @ProfileId

END

go

END
