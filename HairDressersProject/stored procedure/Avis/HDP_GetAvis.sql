CREATE PROCEDURE [dbo].[HDP_GetAvis]
	@Id int
AS
BEGIN
	SELECT a.Id, a.Content, a.Star, a.UserIdProfessionnal, a.UserIdMember, a.Timestamp FROM Avis a WHERE [Id] = @Id
	RETURN 0
END
