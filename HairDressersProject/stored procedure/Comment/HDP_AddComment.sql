CREATE PROCEDURE [dbo].[HDP_AddComment]
	@Id int,
	@Content VARCHAR(384),
	@AvisId int,
	@UserId int
AS
BEGIN
	INSERT INTO [Comment] (Content, AvisId, UserId) VALUES(@Content, @AvisId, @UserId)
	RETURN 0
END
