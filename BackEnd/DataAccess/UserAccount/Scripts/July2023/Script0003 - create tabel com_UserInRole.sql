IF (NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND TABLE_NAME = 'com_UserInRole'))
BEGIN
	CREATE TABLE [dbo].[com_UserInRole](
	[Uuid] [nvarchar](100) NOT NULL,
	[UserUuid] [nvarchar](100) NOT NULL,
	[RoleUuid] [nvarchar](100) NOT NULL,
	[CreatedBy][nvarchar](100) NOT NULL,
	[CreatedAt][datetime2] NOT NULL,
	[UpdatedBy][nvarchar](100) NOT NULL,
	[UpdatedAt][datetime2] NOT NULL,
		PRIMARY KEY CLUSTERED ([Uuid] ASC)
	);

ALTER TABLE [dbo].[com_UserInRole] WITH CHECK ADD CONSTRAINT [FK_com_UserInRole_To_com_Roles] FOREIGN KEY([RoleUuid])
REFERENCES [dbo].[com_Roles] (Uuid) ON DELETE CASCADE

ALTER TABLE [dbo].[com_UserInRole] CHECK CONSTRAINT [FK_com_UserInRole_To_com_Roles]

ALTER TABLE [dbo].[com_UserInRole] WITH CHECK ADD CONSTRAINT [FK_com_UserInRole_To_com_UserAccount] FOREIGN KEY([UserUuid])
REFERENCES [dbo].[com_UserAccount] (Uuid) ON DELETE CASCADE

ALTER TABLE [dbo].[com_UserInRole] CHECK CONSTRAINT [FK_com_UserInRole_To_com_UserAccount]
END
GO