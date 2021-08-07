CREATE PROCEDURE [dbo].[HDP_RegisterUser]
	@LastName VARCHAR(50),
	@FirstName VARCHAR(50),
	@Pseudo VARCHAR(50),
	@Email VARCHAR(75),
	@Passwd VARCHAR(20),
	@Role int,
	@BirthDate datetime,
	@Description Varchar(350),
	@Status bit
AS
BEGIN
	if(@Role = 2)
		BEGIN
		 if(@LastName is null)
		 BEGIN
			Raiserror('Le nom ne doit pas être vide', 16, 1)
			return -1;
		 END
		 if(@FirstName is null)
		 BEGIN
			Raiserror('Le prénom ne doit pas être vide', 16, 1)
			return -1;
		 END
		 if(@BirthDate is null)
		 BEGIN
			Raiserror('La date de naissance ne doit pas être vide', 16, 1)
			return -1;
		 END
		 if(@Description is null)
		 BEGIN
			Raiserror('La description ne doit pas être vide', 16, 1)
			return -1;
		 END
	END

	INSERT INTO [User] (Lastname, Firstname, Pseudo, Email, Passwd, [Role], BirthDate, [Status], [Description]) VALUES 
	(@LastName, @FirstName, @Pseudo,  @Email,  HASHBYTES('SHA2_512', dbo.HDP_GetPreSalt() + @Passwd + dbo.HDP_GetPostSalt()), @Role, @BirthDate, @Status, @Description);

	RETURN 0;
END
