CREATE TABLE [dbo].[Comment]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Content] VARCHAR(384) NOT NULL, 
    [AvisId] INT NOT NULL, 
    CONSTRAINT [FK_Comment_Avis] FOREIGN KEY ([AvisId]) REFERENCES [Avis]([Id])
)
