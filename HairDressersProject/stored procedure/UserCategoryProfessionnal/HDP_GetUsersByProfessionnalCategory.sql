CREATE PROCEDURE [dbo].[HDP_GetUsersByProfessionnalCategory]
	@IdProfessionnalCategory int
AS
BEGIN
	SELECT u.[Id] Lastname, Firstname, Pseudo, Email, [Role], BirthDate, [Status]
	FROM ([User] u JOIN UserCategoryProfessionnal  ucp
					ON u.Id = ucp.IdUser)
	WHERE ucp.IdProfessionnalCategory = @IdProfessionnalCategory
	RETURN 0
END
