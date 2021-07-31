CREATE PROCEDURE [dbo].[HDP_GetProfessionnalCategoryByName]
	@Name VARCHAR(50)
AS
BEGIN
	SELECT [Id], NameCategory
	FROM ProfessionnalCategory WHERE NameCategory = @Name
	RETURN 0
END