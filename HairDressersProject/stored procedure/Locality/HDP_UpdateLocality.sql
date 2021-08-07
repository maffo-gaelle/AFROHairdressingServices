CREATE PROCEDURE [dbo].[HDP_UpdateLocality]
	@CodePostal Varchar(4),
	@Ville varchar(50)
AS
BEGIN
	Update Locality set Ville = @Ville WHERE CodePostal =  @CodePostal
	RETURN 0
END
