CREATE PROCEDURE [dbo].[HDP_DeleteUserLocality]
	@CodePostal Varchar(4),
	@UserId int

AS
BEGIN
	Delete from UserLocality Where CodePostal = @CodePostal and UserId = @UserId
	RETURN 0
END
