CREATE PROCEDURE [dbo].[HDP_DeleteAvis]
	@Id int
AS
	DELETE FROM Avis WHERE [Id] = @Id
RETURN 0
