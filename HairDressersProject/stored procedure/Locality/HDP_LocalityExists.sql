CREATE PROCEDURE [dbo].[HDP_LocalityExists]
	@Ville Varchar(50),
	@CodePostal Varchar(4)
AS
BEGIN
	SELECT COUNT(*) FROM Locality Where Ville = @Ville AND CodePostal = @CodePostal
END
