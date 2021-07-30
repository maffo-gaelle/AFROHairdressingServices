CREATE TABLE [dbo].[Image]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [PicturePath] VARCHAR(384) NOT NULL, 
    [UserId] INT NOT NULL, 
    CONSTRAINT [FK_Image_User] FOREIGN KEY ([UserId]) REFERENCES [User]([Id])
)
