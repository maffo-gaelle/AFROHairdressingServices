CREATE PROCEDURE [dbo].[HDP_AddAvis]
	@Content VARCHAR(380),
	@Star int,
	@PrestationId int,
	@UserId int,
	@Timestamp datetime
AS
	INSERT INTO [Avis] (Content, Star, UserId, PrestationId, [Timestamp]) VALUES (@Content, @Star, @PrestationId, @UserId, @Timestamp)
GO
