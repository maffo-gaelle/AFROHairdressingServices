CREATE PROCEDURE [dbo].[HDP_GetAllAvisByProfessionnalUser]
	@ProfessionnalId int
AS
BEGIN
	SELECT a.Id, a.Content, a.Star, a.UserIdProfessionnal, a.UserIdMember, a.[Timestamp] FROM AVIS a WHERE a.Id = @ProfessionnalId
	RETURN 0
END
