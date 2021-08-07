CREATE PROCEDURE [dbo].[HDP_DeleteComment]
	@Id int
AS
BEGIN
	DELETE FROM [Comment] WHERE [Id]  = @Id 
	RETURN 0
END
