CREATE PROCEDURE [dbo].[HDP_GetProfessionnalCategoryNameById]
	@IdProfessionnalCategory int
AS
BEGIN
	SELECT DISTINCT [Id], [NameCategory]
	FROM ProfessionnalCategory p JOIN UserCategoryProfessionnal ucp
	ON p.Id = ucp.IdProfessionnalCategory
	WHERE ucp.IdProfessionnalCategory = @IdProfessionnalCategory
	RETURN 0
END
