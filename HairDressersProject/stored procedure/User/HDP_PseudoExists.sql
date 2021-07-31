CREATE PROCEDURE [dbo].[HDP_PseudoExists]
	@Pseudo VARCHAR(75)
AS
BEGIN
	Select Count(*) From [User] where Pseudo = @Pseudo
END
