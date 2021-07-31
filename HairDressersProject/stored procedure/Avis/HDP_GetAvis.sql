CREATE PROCEDURE [dbo].[HDP_GetAvis]
	@Id int
AS
BEGIN
	SELECT [Id], [Content], [Star], [UserIdProfessionnal], [UserIdMember], [Timestamp] FROM AVIS WHERE [Id] = @Id
	RETURN 0
END
