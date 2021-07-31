CREATE PROCEDURE [dbo].[HDP_RemoveComment]
	@Id int
AS
BEGIN
	Delete FROM Comment WHERE Id = @Id
	RETURN 0
END
