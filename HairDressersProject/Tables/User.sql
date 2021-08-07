CREATE TABLE [dbo].[User]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[Lastname] VARCHAR(50) NULL, 
    [Firstname] VARCHAR(50) NULL, 
    [Pseudo] VARCHAR(75) NOT NULL UNIQUE, 
    [Email] VARCHAR(75) NOT NULL UNIQUE, 
    [Passwd] BINARY(64) NOT NULL, 
    [Role] INT NOT NULL DEFAULT 1, 
    [BirthDate] DATETIME NULL, 
    [Status] BIT NOT NULL DEFAULT 1, 
    [Description] VARCHAR(350) NULL, 
    CONSTRAINT [CK_User_Role] CHECK ([Role] BETWEEN 0 and 2), 
    CONSTRAINT [CK_User_BirthDate] CHECK (BirthDate is null or (GETDATE() - BirthDate) >= 18 ),
)
