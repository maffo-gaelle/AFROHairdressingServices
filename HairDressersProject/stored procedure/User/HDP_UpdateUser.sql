CREATE PROCEDURE [dbo].[HDP_UpdateUser]
	@Id int,
	@Lastname VARCHAR(50),
	@Firstname VARCHAR(50),
	@Pseudo VARCHAR(75),
	@Email VARCHAR(75),
	@Passwd VARCHAR(20),
	@BirthDate datetime2(7),
	@IdProfessionnalCategory int,
	@Status bit
AS
BEGIN
	UPDATE [User] Set [Lastname] = @Lastname, [Firstname] = @Firstname, [Pseudo] = @Pseudo, [Email] = @Email, [Passwd] = HASHBYTES('SHA2_512', dbo.HDP_GetPreSalt() + @Passwd + dbo.HDP_GetPostSalt()), [BirthDate] = @BirthDate, [IdProfessionnalCategory] = @IdProfessionnalCategory, [Status] = @Status WHERE Id = @Id;
	RETURN 0
END
