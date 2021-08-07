CREATE PROCEDURE [dbo].[HDP_GetAllLocalities]
AS
BEGIN
	SELECT CodePostal, Ville FROM Locality
	RETURN 0
END
