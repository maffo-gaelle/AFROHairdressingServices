CREATE PROCEDURE [dbo].[HDP_AddImage]
	@PicturePath VARCHAR(384),
	@UserId int
AS
BEGIN
	INSERT INTO [Image] (PicturePath, UserId) VALUES (@PicturePath, @UserId)
	RETURN 0
END
