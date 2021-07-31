CREATE PROCEDURE [dbo].[HDP_AverageStarsByProfessionnal]
	@Id int
AS
BEGIN
	SELECT AVG(a.Star)
	From [User] u JOIN Avis a
	ON u.Id = a.UserIdProfessionnal
	WHERE u.Id = @Id
	Group By a.UserIdProfessionnal
	RETURN 0
END
