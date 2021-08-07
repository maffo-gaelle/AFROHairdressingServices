CREATE PROCEDURE [dbo].[HDP_AddComment]
	@Id int,
	@Content VARCHAR(384),
	@AvisId int,
	@UserId int,
	@Timestamp datetime
AS
BEGIN
	INSERT INTO [Comment] (Content, AvisId, UserId, [Timestamp]) VALUES(@Content, @AvisId, @UserId, @Timestamp)
	RETURN 0
END
