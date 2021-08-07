CREATE TABLE [dbo].[Avis]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Content] VARCHAR(380) NULL, 
    [Star] INT NOT NULL DEFAULT 1, 
    [UserId] INT NOT NULL, 
    [PrestationId] INT NOT NULL, 
    [Timestamp] DATETIME NOT NULL, 
    CONSTRAINT [FK_Avis_UserProfessionnel] FOREIGN KEY ([UserId]) REFERENCES [User]([Id]), 
    CONSTRAINT [FK_Avis_UserMembre] FOREIGN KEY ([PrestationId]) REFERENCES [User]([Id]), 
    CONSTRAINT [CK_Avis_Cunique] UNIQUE ([UserId], [PrestationId]), 
    CONSTRAINT [CK_Avis_Star] CHECK (Star between 1 and 6)
)
