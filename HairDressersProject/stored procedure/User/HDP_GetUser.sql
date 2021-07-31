CREATE PROCEDURE [dbo].[HDP_GetUser]
	@Id int
AS
BEGIN
	SELECT [Id], Lastname, Firstname, Pseudo, Email, [Role], BirthDate, [Status] FROM [User] WHERE Id = @Id
	RETURN 0
END
