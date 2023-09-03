-- =============================================
-- Creation date:   03/09/2023
-- Description:	Add table ImageProfile
-- =============================================


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

