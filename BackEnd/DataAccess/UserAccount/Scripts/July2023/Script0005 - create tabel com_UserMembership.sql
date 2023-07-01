IF (NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND TABLE_NAME = 'com_UserMembership'))
BEGIN
	CREATE TABLE [dbo].[com_UserMembership](
	[Uuid] [nvarchar](100) NOT NULL,
	[UserUuid] [nvarchar](100) NOT NULL,
	[Password] [nvarchar](200) NOT NULL,
	[CreatedBy][nvarchar](100) NOT NULL,
	[CreatedAt][datetime2] NOT NULL,
	[UpdatedBy][nvarchar](100) NOT NULL,
	[UpdatedAt][datetime2] NOT NULL,
		PRIMARY KEY CLUSTERED ([Uuid] ASC)
	);

ALTER TABLE [dbo].[com_UserMembership] WITH CHECK ADD CONSTRAINT [FK_com_UserMembership_To_com_UserAccount] FOREIGN KEY([UserUuid])
REFERENCES [dbo].[com_UserAccount] (Uuid) ON DELETE CASCADE

ALTER TABLE [dbo].[com_UserMembership] CHECK CONSTRAINT [FK_com_UserMembership_To_com_UserAccount]
END
GO