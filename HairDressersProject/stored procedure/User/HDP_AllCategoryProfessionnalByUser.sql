CREATE PROCEDURE [dbo].[HDP_AllCategoryProfessionnalByUser]
	@Id int
AS
BEGIN
	SELECT pc.Id, pc.NameCategory
	FROM ([User] u JOIN UserCategoryProfessionnal  ucp
					ON u.Id = ucp.IdUser)
					JOIN ProfessionnalCategory pc 
					ON ucp.IdProfessionnalCategory = pc.Id
	WHERE u.Id = @Id
	RETURN 0
END