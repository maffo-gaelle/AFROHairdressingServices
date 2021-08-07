CREATE PROCEDURE [dbo].[HDP_UnlockUser]
	@Id int
AS
BEGIN
	UPDATE [User] Set [Status] = 1 WHERE Id = @Id AND [Status] = 0;
	RETURN 0
END
