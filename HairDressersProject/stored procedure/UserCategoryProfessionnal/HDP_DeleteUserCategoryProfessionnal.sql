CREATE PROCEDURE [dbo].[HDP_DeleteUserCategoryProfessionnal]
	@UserId int,
	@IdProfessionnalCategory int
AS
BEGIN
	Delete From UserCategoryProfessionnal WHERE IdUser = @UserId and IdProfessionnalCategory = @IdProfessionnalCategory
	RETURN 0
END
