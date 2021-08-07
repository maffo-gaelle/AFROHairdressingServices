CREATE PROCEDURE [dbo].[HDP_AddUserLocality]
	@CodePostal Varchar(4),
	@UserId int
AS
BEGIN
	DECLARE @IdUser int
	SELECT @IdUser = Id from [User] WHERE Id = @UserId and [Role] = 2
	if(@IdUser is null)
	BEGIN
		raiserror('Cet utilisateur n''est pas un professionnel', 16, 1)
		RETURN -1
	END
	Insert Into UserLocality(CodePostal, UserId) Values(@CodePostal, @UserId)
	RETURN 0
END
