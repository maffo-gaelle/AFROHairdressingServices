CREATE TABLE [dbo].[User]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[Lastname] VARCHAR(50) NOT NULL, 
    [Firstname] VARCHAR(50) NOT NULL, 
    [Pseudo] VARCHAR(75) NOT NULL UNIQUE, 
    [Email] VARCHAR(75) NOT NULL UNIQUE, 
    [Passwd] BINARY(64) NOT NULL, 
    [Role] INT NOT NULL DEFAULT 1, 
    [BirthDate] DATETIME2 NOT NULL, 
    [IdProfessionnalCategory] INT NULL, 
    [Status] BIT NOT NULL DEFAULT 1, 
    CONSTRAINT [FK_User_ProfessionnalCategory] FOREIGN KEY ([IdProfessionnalCategory]) REFERENCES [ProfessionnalCategory]([Id]), 
    --CONSTRAINT [CK_User_IdProfessionnalCategory] CHECK (Role = 2 and IdProfessionnalCategory != null), 
    CONSTRAINT [CK_User_BirthDate] CHECK (year(GETDATE()) - (year(BirthDate)) >= 18), 
    CONSTRAINT [CK_User_FullName] UNIQUE (Lastname, Firstname)
)
