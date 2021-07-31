CREATE PROCEDURE [dbo].[HDP_ALLAvisAndCommentByProfessionnal]
	@Id int
AS
BEGIN
	Select * FROM Avis A, Comment c WHERE A.UserIdProfessionnal = @Id  AND C.AvisId = A.Id
	RETURN 0
END
