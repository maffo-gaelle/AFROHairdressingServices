CREATE PROCEDURE [dbo].[HDP_GetUserByFirstnameAndLastname]
	@Lastname VARCHAR(50),
	@Firstname VARCHAR(50)
AS
BEGIN
	Select [Id], Lastname, Firstname, Pseudo, Email, [Role], BirthDate, [Status] from [User] Where Firstname = @Firstname  and Lastname = @Lastname
	RETURN 0
END
