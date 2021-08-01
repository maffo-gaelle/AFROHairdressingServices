CREATE TABLE [dbo].[Comment]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Content] VARCHAR(384) NOT NULL, 
    [AvisId] INT NOT NULL, 
    [UserId] INT NOT NULL, 
    [Timestamp] DATETIME2 NOT NULL, 
    CONSTRAINT [FK_Comment_Avis] FOREIGN KEY ([AvisId]) REFERENCES [Avis]([Id]), 
    CONSTRAINT [FK_Comment_User] FOREIGN KEY ([UserId]) REFERENCES [User]([Id])
)
