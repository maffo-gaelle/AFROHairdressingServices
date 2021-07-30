CREATE TABLE [dbo].[Avis]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Content] VARCHAR(380) NULL, 
    [Star] INT NOT NULL DEFAULT 1, 
    [UserIdProfessionnal] INT NOT NULL, 
    [UserIdMember] INT NOT NULL, 
    [Timestamp] DATETIME2 NOT NULL, 
    CONSTRAINT [FK_Avis_UserProfessionnel] FOREIGN KEY ([UserIdProfessionnal]) REFERENCES [User]([Id]), 
    CONSTRAINT [FK_Avis_UserMembre] FOREIGN KEY ([UserIdMember]) REFERENCES [User]([Id]), 
    CONSTRAINT [CK_Avis_Cunique] UNIQUE (UserIdProfessionnal, UserIdMember)
)
