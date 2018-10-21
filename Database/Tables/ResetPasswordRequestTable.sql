CREATE TABLE [dbo].[ResetPasswordRequestTable]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
	[UserID] int Foreign Key REFERENCES Users(UserID),
	[ResetRequestDateTime] DateTime
)
