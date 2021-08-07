CREATE TABLE [dbo].[UserLocality]
(
	[CodePostal] VARCHAR(4) NOT NULL, 
    [UserId] INT NOT NULL, 
    CONSTRAINT [FK_UserLocality_Locality] FOREIGN KEY ([CodePostal]) REFERENCES [Locality]([CodePostal]), 
    CONSTRAINT [FK_UserLocality_User] FOREIGN KEY ([UserId]) REFERENCES [User]([Id]), 
    CONSTRAINT [CK_UserLocality_CodePostal_UserId] Unique (CodePostal, UserId) 
)
