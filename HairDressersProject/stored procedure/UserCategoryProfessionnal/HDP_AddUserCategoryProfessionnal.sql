CREATE PROCEDURE [dbo].[HDP_AddUserCategoryProfessionnal]
	@UserId int,
	@IdProfessionnalCategory int
AS
BEGIN
	DECLARE @Id int
	DECLARE @CategoryId int
	DECLARE @role int

	SET @ID = (SELECT Id from [User] WHERE Id = @UserId)
	SET @role = (SELECT [Role] from [User] WHERE Id = @UserId)
	SET @CategoryId = (SELECT Id from [ProfessionnalCategory] WHERE Id = @IdProfessionnalCategory)
	
	IF (@Id is null)
	BEGIN
		Raiserror('Cet utilisateur n''existe pas', 16, 1)
		return -1;
	END
	IF (@role <> 2)
	BEGIN
		Raiserror('Cet utilisateur n''est pas un professionnel', 16, 1)
		return -1;
	END
	IF (@CategoryId is null)
	BEGIN
		Raiserror('Cette categorie n''existe pas', 16, 1)
		return -1
	END
	Insert Into UserCategoryProfessionnal (IdUser, IdProfessionnalCategory) Values(@UserId , @IdProfessionnalCategory)
END
