CREATE PROCEDURE [dbo].[HDP_AddComment]
	@Content VARCHAR(384),
	@AvisId int
AS
BEGIN
	INSERT INTO [Comment] (Content, AvisId) VALUES(@Content, @AvisId)
	RETURN 0
END
