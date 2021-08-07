CREATE TRIGGER [OnDeleteUser]
ON [User]
INSTEAD OF DELETE
AS
BEGIN
	Update [User] Set [Status] = 0 WHERE Id in (select Id from deleted) AND [Status] = 1
END
