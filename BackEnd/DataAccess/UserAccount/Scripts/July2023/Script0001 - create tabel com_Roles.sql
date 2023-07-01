IF (NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND TABLE_NAME = 'com_Roles'))
BEGIN
	CREATE TABLE [dbo].[com_Roles](
	[Uuid] [nvarchar](100) NOT NULL,
	[RoleName] [nvarchar](100) NOT NULL,
	[CreatedBy][nvarchar](100) NOT NULL,
	[CreatedAt][datetime2] NOT NULL,
	[UpdatedBy][nvarchar](100) NOT NULL,
	[UpdatedAt][datetime2] NOT NULL,
		PRIMARY KEY CLUSTERED ([Uuid] ASC)
	);
END
GO