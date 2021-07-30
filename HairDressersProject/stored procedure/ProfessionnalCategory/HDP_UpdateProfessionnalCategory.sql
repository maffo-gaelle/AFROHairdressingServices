CREATE PROCEDURE [dbo].[HDP_UpdateProfessionnalCategory]
	@Id int,
	@Name VARCHAR(50)
AS
BEGIN
	UPDATE [ProfessionnalCategory]  set [NameCategory] = @Name WHERE [Id] = @Id;
	RETURN 0
END
