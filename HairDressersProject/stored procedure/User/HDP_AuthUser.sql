CREATE PROCEDURE [dbo].[HDP_AuthUser]
	@EmailOrPseudo VARCHAR(50),
	@Passwd VARCHAR(20)
AS
BEGIN
	SELECT [Id], Lastname, Firstname, Pseudo, Email, [Role], BirthDate, IdProfessionnalCategory, [Status]
	FROM [User] 
	WHERE Email = @EmailOrPseudo or Pseudo = @EmailOrPseudo
	AND Passwd = HASHBYTES('SHA2_512', dbo.HDP_GetPreSalt() + @Passwd + dbo.HDP_GetPostSalt())
	AND [Status] = 1
	RETURN 0;
END

