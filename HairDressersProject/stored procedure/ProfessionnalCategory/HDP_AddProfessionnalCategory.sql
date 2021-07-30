CREATE PROCEDURE [dbo].[HDP_AddProfessionnalCategory]
	@Name VARCHAR(50)
AS
BEGIN
	INSERT INTO [ProfessionnalCategory] ([NameCategory]) VALUES (@Name);
	RETURN 0
END
