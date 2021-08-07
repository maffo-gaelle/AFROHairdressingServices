CREATE TABLE [dbo].[UserCategoryProfessionnal]
(
	[IdUser] INT NOT NULL , 
    [IdProfessionnalCategory] INT NOT NULL, 
    CONSTRAINT [FK_UserCategoryProfessionnal_User] FOREIGN KEY ([IdUser]) REFERENCES [User]([Id]), 
    CONSTRAINT [FK_UserCategoryProfessionnal_ProfessionnalCategory] FOREIGN KEY ([IdProfessionnalCategory]) REFERENCES [ProfessionnalCategory]([Id]), 
    CONSTRAINT [CK_UserCategoryProfessionnal_IdUser_IdProfessionnalCategory] UNIQUE(IdUser, IdProfessionnalCategory)
)
