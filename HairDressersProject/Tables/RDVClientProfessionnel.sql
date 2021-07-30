CREATE TABLE [dbo].[RDVClientProfessionnel]
(
    [IDMember] INT NOT NULL, 
    [IDProfessionnal] INT NOT NULL, 
    [IDPrestation] INT NOT NULL, 
    CONSTRAINT [FK_RDVClientProfessionnel_UserMembre] FOREIGN KEY ([IDMember]) REFERENCES [User]([Id]), 
    CONSTRAINT [FK_RDVClientProfessionnel_UserProfessionnel] FOREIGN KEY ([IDProfessionnal]) REFERENCES [User]([Id]), 
    CONSTRAINT [FK_RDVClientProfessionnel_Prestation] FOREIGN KEY ([IDPrestation]) REFERENCES [Prestation]([Id]) 
)
