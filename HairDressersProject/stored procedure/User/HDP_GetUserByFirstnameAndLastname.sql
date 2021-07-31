CREATE PROCEDURE [dbo].[HDP_GetUserByFirstnameAndLastname]
	@Lastname VARCHAR(50),
	@Firstname VARCHAR(50)
AS
BEGIN
	Select * from [User] Where Firstname =  @Lastname and Lastname = @Firstname
END
