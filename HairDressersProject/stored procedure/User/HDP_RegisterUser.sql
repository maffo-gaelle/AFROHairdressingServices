CREATE PROCEDURE [dbo].[HDP_RegisterUser]
	@LastName VARCHAR(50),
	@FirstName VARCHAR(50),
	@Pseudo VARCHAR(50),
	@Email VARCHAR(75),
	@Passwd VARCHAR(20),
	@Role int,
	@BirthDate datetime2(7),
	@IdProfessionnalCategory int,
	@Status bit
AS
BEGIN
	INSERT INTO [User] (Lastname, Firstname, Pseudo, Email, Passwd, [Role], BirthDate, IdProfessionnalCategory, [Status]) VALUES 
	(@LastName, @FirstName, @Pseudo,  @Email,  HASHBYTES('SHA2_512', dbo.HDP_GetPreSalt() + @Passwd + dbo.HDP_GetPostSalt()), @Role, @BirthDate, @IdProfessionnalCategory, @Status);

	RETURN 0;
END