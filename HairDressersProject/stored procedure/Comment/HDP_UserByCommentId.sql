CREATE PROCEDURE [dbo].[HDP_UserByCommentId]
	@Id int
AS
BEGIN
	SELECT u.[Id], Lastname, Firstname, Pseudo, Email, [Role], BirthDate, [Status] FROM [User] u JOIN Comment c ON u.Id = c.UserId Where c.Id = @Id	
	RETURN 0
END
