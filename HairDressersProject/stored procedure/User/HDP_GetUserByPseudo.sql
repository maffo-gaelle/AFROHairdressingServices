CREATE PROCEDURE [dbo].[HDP_GetUserByPseudo]
	@pseudo VARCHAR(50)
AS
BEGIN
	SELECT [Id], Lastname, Firstname, Pseudo, Email, [Role], BirthDate, [Status], [Description] FROM [User] WHERE Pseudo = @pseudo
	RETURN 0
END
