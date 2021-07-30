CREATE TABLE [dbo].[UserComment]
(
	[IdComment] INT NOT NULL, 
    [IdUser] INT NOT NULL, 
    CONSTRAINT [FK_UserComment_Comment] FOREIGN KEY ([IdComment]) REFERENCES [Comment]([Id]), 
    CONSTRAINT [FK_UserComment_User] FOREIGN KEY ([IdUser]) REFERENCES [User]([Id]) 
)
