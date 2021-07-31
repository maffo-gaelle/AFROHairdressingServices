﻿CREATE PROCEDURE [dbo].[HDP_GetAllProfessionnalUsersOrMemberUsers]
	@Role int
AS
BEGIN
	SELECT [Id], Lastname, Firstname, Pseudo, Email, [Role], BirthDate, [Status]
	FROM [User] WHERE Role = @Role
	RETURN 0
END