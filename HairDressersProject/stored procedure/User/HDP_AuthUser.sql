CREATE PROCEDURE [dbo].[HDP_AuthUser]
	@Email VARCHAR(75),
	@Passwd VARCHAR(20)
AS
BEGIN
	SELECT [Id], Lastname, Firstname, Pseudo, Email, [Role], BirthDate, [Status]
	FROM [User] 
	WHERE Email = @Email
	AND Passwd = HASHBYTES('SHA2_512', dbo.HDP_GetPreSalt() + @Passwd + dbo.HDP_GetPostSalt())
	AND [Status] = 1
	RETURN 0;
END

