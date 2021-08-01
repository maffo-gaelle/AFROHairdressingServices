CREATE PROCEDURE [dbo].[HDP_AddUserCategoryProfessionnal]
	@UserId int,
	@IdProfessionnalCategory int
AS
BEGIN
	Insert Into UserCategoryProfessionnal (IdUser, IdProfessionnalCategory) Values(@UserId , @IdProfessionnalCategory)
END
