CREATE TRIGGER [CTR_AfterInsertUserProfessionnalCategory]
ON dbo.UserCategoryProfessionnal
After Insert
AS
BEGIN
	IF NOT EXISTS(SELECT Lastname 
					 FROM [User]
					 WHERE Id IN (select IdUser FROM inserted))
	BEGIN
		raiserror('Cet utilisateur n''existe pas', 16, 1);
		ROLLBACK;
	END

	IF EXISTS(SELECT Lastname, Firstname 
					 FROM [User] 
					 WHERE Id IN (select IdUser FROM inserted )
					 AND [Role] <> 2)
	BEGIN
		raiserror('Cet utilisateur n''est pas un professionnel', 16, 1);
		ROLLBACK;
	END

	IF NOT EXISTS(SELECT NameCategory 
					 FROM ProfessionnalCategory 
					 WHERE Id IN (select IdProfessionnalCategory FROM inserted))
	BEGIN
		raiserror('Cet catégorie n''existe pas', 16, 1);
		ROLLBACK;
	END	
END
