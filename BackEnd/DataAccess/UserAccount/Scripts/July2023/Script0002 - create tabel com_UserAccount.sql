IF (NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND TABLE_NAME = 'com_UserAccount'))
BEGIN
	CREATE TABLE [dbo].[com_UserAccount](
	[Uuid] [nvarchar](100) NOT NULL,
	[EmailAddress] [nvarchar](100) NOT NULL,
	[FirstName] [nvarchar](100) NOT NULL,
	[LastName] [nvarchar](100) NOT NULL,
	[TimeZoneId] [nvarchar](100) NOT NULL,
	[IsArchived][bit] NOT NULL,
	[CreatedBy][nvarchar](100) NOT NULL,
	[CreatedAt][datetime2] NOT NULL,
	[UpdatedBy][nvarchar](100) NOT NULL,
	[UpdatedAt][datetime2] NOT NULL,
		PRIMARY KEY CLUSTERED ([Uuid] ASC),
		UNIQUE NONCLUSTERED ([EmailAddress] ASC)
	);
END
GO