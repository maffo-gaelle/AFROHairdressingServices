CREATE PROCEDURE [dbo].[HDP_GetLocality]
	@CodePostal Varchar(4)
AS
BEGIN
	SELECT CodePostal, Ville FROM Locality WHERE CodePostal = @CodePostal
	RETURN 0
END
