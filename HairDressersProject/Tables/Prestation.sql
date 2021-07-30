CREATE TABLE [dbo].[Prestation]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Message] VARCHAR(MAX) NOT NULL, 
    [Statut] INT NOT NULL DEFAULT 0, 
    [IdCategoryPrestation] INT NOT NULL, 
    [Timestamp] DATETIME2 NOT NULL, 
    CONSTRAINT [FK_Prestation_CategoryPrestation] FOREIGN KEY ([IdCategoryPrestation]) REFERENCES [CategoryPrestation]([Id])
)
