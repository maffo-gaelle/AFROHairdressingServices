CREATE TABLE [dbo].[RendezVous]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [IdPrestation] INT NOT NULL, 
    [Datetime] DATETIME NOT NULL, 
    [status] INT NOT NULL
)
