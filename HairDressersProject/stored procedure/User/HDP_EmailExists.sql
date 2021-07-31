CREATE PROCEDURE [dbo].[HDP_EmailExists]
	@Email VARCHAR(75)
AS
BEGIN
	Select Count(*) From [User] where Email = @Email
	RETURN 0
END