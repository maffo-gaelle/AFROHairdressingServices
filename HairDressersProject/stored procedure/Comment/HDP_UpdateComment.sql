CREATE PROCEDURE [dbo].[HDP_UpdateComment]
	@Id int,
	@Content VARCHAR(384)
AS
BEGIN
	UPDATE [Comment] set [Content] = @Content WHERE [Id] = @Id
	RETURN 0
END