CREATE PROCEDURE [dbo].[HDP_AddAvis]
	@Content VARCHAR(380),
	@Star int,
	@UserIdProfessionnal int,
	@UserIdMember int,
	@Timestamp datetime2(7)
AS
BEGIN
	INSERT INTO [Avis] (Content, Star, UserIdProfessionnal, UserIdMember, [Timestamp]) VALUES (@Content, @Star, @UserIdProfessionnal, @UserIdMember, @Timestamp)
	RETURN 0
END
