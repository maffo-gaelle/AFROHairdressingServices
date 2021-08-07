CREATE PROCEDURE [dbo].[HDP_AddLocality]
	@CodePostal Varchar(4),
	@Ville varchar(50)
AS
BEGIN
	Insert Into Locality (CodePostal, Ville) Values(@CodePostal, @Ville)
	RETURN 0
END
