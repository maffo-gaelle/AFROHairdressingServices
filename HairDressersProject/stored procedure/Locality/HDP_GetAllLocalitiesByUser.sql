CREATE PROCEDURE [dbo].[HDP_GetAllLocalitiesByUser]
	@UserId int
AS
BEGIN
	SELECT l.CodePostal, l.Ville FROM Locality l, UserLocality ul WHERE l.CodePostal = ul.CodePostal AND ul.UserId = @UserId
	RETURN 0
END
