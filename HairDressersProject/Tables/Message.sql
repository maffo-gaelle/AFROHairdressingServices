CREATE TABLE [dbo].[Message]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Title] VARCHAR(50) NULL, 
    [Body] VARCHAR(MAX) NOT NULL, 
    [datetime] DATETIME2 NOT NULL, 
    [AuthorId] INT NOT NULL, 
    [RecipientId] INT NOT NULL, 
    [ParentId] INT NULL, 
    CONSTRAINT [FK_Message_UserAuthor] FOREIGN KEY ([AuthorId]) REFERENCES [User]([Id]), 
    CONSTRAINT [FK_Message_UserRecipient] FOREIGN KEY ([RecipientId]) REFERENCES [User]([Id]), 
    CONSTRAINT [FK_Message_Message] FOREIGN KEY ([ParentId]) REFERENCES [Message]([Id])
)
