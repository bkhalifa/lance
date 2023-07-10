-- =============================================
-- Creation date:   09/07/2023
-- Description:	Add new column initialUserName
-- =============================================
IF COL_LENGTH('[profile].[UserProfiles]', 'InitialUserName') IS NULL
BEGIN
    ALTER TABLE [profile].[UserProfiles]
    ADD InitialUserName varchar(50)
END
