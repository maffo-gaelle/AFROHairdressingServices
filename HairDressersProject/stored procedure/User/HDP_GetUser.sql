CREATE PROCEDURE [dbo].[HDP_GetUser]
	@Id int
AS
	SELECT * FROM [User] WHERE Id = @Id
RETURN 
