CREATE PROCEDURE [dbo].[HDR_GetProfessionnalByCategory]
	@ProfessionnalCategoryId int
AS
BEGIN
	SELECT * FROM [User] WHERE [User].IdProfessionnalCategory = @ProfessionnalCategoryId
	RETURN 
END

