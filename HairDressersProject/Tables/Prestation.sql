CREATE TABLE [dbo].[Prestation]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Description] VARCHAR(384) NULL, 
    [MemberId] INT NOT NULL, 
    [ProfessionnalId] INT NOT NULL, 
    [NbRendezVous] INT NOT NULL, 
    CONSTRAINT [FK_Prestation_UserMember] FOREIGN KEY ([MemberId]) REFERENCES [User]([Id]), 
    CONSTRAINT [FK_Prestation_UserProfessionnal] FOREIGN KEY ([ProfessionnalId]) REFERENCES [User]([Id]), 
)
