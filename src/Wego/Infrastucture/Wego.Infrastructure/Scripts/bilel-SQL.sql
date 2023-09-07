-- =============================================
-- Creation date:   09/07/2023
-- Description:	Add new column initialUserName
-- =============================================
IF COL_LENGTH('[profile].[UserProfiles]', 'InitialUserName') IS NULL
BEGIN
    ALTER TABLE [profile].[UserProfiles]
    ADD InitialUserName varchar(50)
END

GO

IF OBJECT_ID(N'[profile].[ImageProfile]', N'U') IS NULL
CREATE TABLE profile.ImageProfile (
Id BIGINT IDENTITY(1,1) PRIMARY KEY,
ImageData varbinary(max) NOT NULL,
Width TINYINT,
Height TINYINT,
ContentType NVARCHAR(50),
CreationDate datetime NULL,
UpateDate dateTime NULL,
ProfileId BIGINT NULL,
FOREIGN KEY (ProfileId) REFERENCES [profile].[UserProfiles](Id)
);
GO


-- =============================================
-- Creation date:   06/06/2023
-- Description:	Add new column initialUserName 
-- Drop Coloms country , cities et skills
-- =============================================
IF NOT EXISTS (
  SELECT 1  FROM   INFORMATION_SCHEMA.COLUMNS
  WHERE TABLE_NAME = '[profile].[UserProfiles]' AND COLUMN_NAME = '[Country]')
BEGIN
ALTER TABLE [profile].[UserProfiles]
DROP COLUMN [Country]
END

IF NOT EXISTS (
  SELECT 1  FROM   INFORMATION_SCHEMA.COLUMNS
  WHERE TABLE_NAME = '[profile].[UserProfiles]' AND COLUMN_NAME = '[City]')
BEGIN
ALTER TABLE [profile].[UserProfiles]
DROP COLUMN [City]
END

IF NOT EXISTS (
  SELECT 1  FROM   INFORMATION_SCHEMA.COLUMNS
  WHERE TABLE_NAME = '[profile].[UserProfiles]' AND COLUMN_NAME = '[Skills]')
 BEGIN
ALTER TABLE [profile].[UserProfiles]
DROP COLUMN [Skills]
END