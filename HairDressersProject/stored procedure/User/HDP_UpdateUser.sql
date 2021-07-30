CREATE PROCEDURE [dbo].[HDP_UpdateUser]
	@Id int,
	@Pseudo VARCHAR(50),
	@Email VARCHAR(75),
	@Passwd VARCHAR(20),
	@BirthDate datetime2(7),
	@IdProfessionnalCategory int,
	@Status bit
AS
BEGIN
	UPDATE [User] Set [Pseudo] = @Pseudo, [Email] = @Email, [Passwd] = HASHBYTES('SHA2_512', dbo.HDP_GetPreSalt() + @Passwd + dbo.HDP_GetPostSalt()), [BirthDate] = @BirthDate, [IdProfessionnalCategory] = @IdProfessionnalCategory, [Status] = @Status WHERE Id = @Id;
	RETURN 0
END
