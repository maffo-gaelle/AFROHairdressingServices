CREATE PROCEDURE [dbo].[HDP_GetAllCommentsByAvis]
	@AvisId int
AS
BEGIN
	SELECT c.Id, c.Content, c.AvisId, c.UserId FROM Comment c WHERE c.AvisId = @AvisId
	RETURN 0
END
