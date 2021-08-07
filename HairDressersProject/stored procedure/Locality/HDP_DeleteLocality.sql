CREATE PROCEDURE [dbo].[HDP_DeleteLocality]
	@CodePostal Varchar(4)
AS
BEGIN
	Delete from Locality Where CodePostal = @CodePostal
	RETURN 0
END
