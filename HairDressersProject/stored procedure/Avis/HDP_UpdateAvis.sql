CREATE PROCEDURE [dbo].[HDP_UpdateAvis]
	@Id int,
	@Content VARCHAR(380),
	@Star int
AS
BEGIN
	INSERT INTO [Avis] (Content, Star) VALUES (@Content, @Star)
	RETURN 0
END