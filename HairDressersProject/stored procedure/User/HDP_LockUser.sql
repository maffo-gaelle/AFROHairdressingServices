CREATE PROCEDURE [dbo].[HDP_LockUser]
	@Id int
AS
BEGIN
	UPDATE [User] Set [Status] = 0 WHERE Id = @Id AND [Status] = 1;
	RETURN 0
END
