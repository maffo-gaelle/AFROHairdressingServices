CREATE TABLE [dbo].[ProfessionnalCategory]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [NameCategory] VARCHAR(50) NOT NULL UNIQUE 
)
