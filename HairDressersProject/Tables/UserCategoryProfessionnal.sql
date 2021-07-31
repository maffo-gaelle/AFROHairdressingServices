CREATE TABLE [dbo].[UserCategoryProfessionnal]
(
	[IdUser] INT NOT NULL , 
    [IdProfessionnalCategory] INT NOT NULL, 
    CONSTRAINT [FK_UserCategoryProfessionnal_User] FOREIGN KEY ([IdUser]) REFERENCES [User]([Id]), 
    CONSTRAINT [FK_UserCategoryProfessionnal_ProfessionnalCategory] FOREIGN KEY ([IdProfessionnalCategory]) REFERENCES [ProfessionnalCategory]([Id])
)
