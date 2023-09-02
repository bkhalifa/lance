-- =============================================
-- Creation date:   09/07/2023
-- Description:	Add new column initialUserName
-- =============================================
IF COL_LENGTH('[profile].[UserProfiles]', 'InitialUserName') IS NULL
BEGIN
    ALTER TABLE [profile].[UserProfiles]
    ADD InitialUserName varchar(50)
END


CREATE TABLE profile.ImageProfile (
Id BIGINT IDENTITY(1,1) PRIMARY KEY,
ImageData varbinary(max) NOT NULL,
Width TINYINT,
Height TINYINT,
PorifleId BIGINT NULL,
FOREIGN KEY (PorifleId) REFERENCES [profile].[UserProfiles](Id)
);
