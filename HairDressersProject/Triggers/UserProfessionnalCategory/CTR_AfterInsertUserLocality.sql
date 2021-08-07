CREATE TRIGGER [CTR_AfterInsertUserLocality]
ON dbo.UserLocality
After Insert, Update
AS
BEGIN
	IF EXISTS(SELECT Lastname, Firstname 
					 FROM [User] 
					 WHERE Id IN (select UserId FROM inserted)
					 AND [Role] <> 2)
	BEGIN
		raiserror('Cet utilisateur n''est pas un professionnel', 16, 1);
		ROLLBACK;
	END
END
