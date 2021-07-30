CREATE PROCEDURE [dbo].[HDP_AuthUser]
	@Pseudo VARCHAR(50),
	@Email VARCHAR(75),
	@Passwd VARCHAR(20)
AS
BEGIN
	SELECT [Id], Lastname, Firstname, Pseudo, Email, [Role], BirthDate, IdProfessionnalCategory, [Status]
	FROM [User] 
	WHERE Email = @Email or Pseudo = @Pseudo
	AND Passwd = HASHBYTES('SHA2_512', dbo.HDP_GetPreSalt() + @Passwd + dbo.HDP_GetPostSalt())
	AND [Status] = 1
	RETURN 0;
END

