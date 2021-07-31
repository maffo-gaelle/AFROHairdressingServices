CREATE VIEW [dbo].[HDR_GetAllUser]
	AS SELECT [Id], Lastname, Firstname, Pseudo, Email, [Role], BirthDate, [Status] FROM [User]
