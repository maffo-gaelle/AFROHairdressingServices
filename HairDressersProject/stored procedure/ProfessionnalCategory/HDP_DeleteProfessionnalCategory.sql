CREATE PROCEDURE [dbo].[HDP_DeleteProfessionnalCategory]
	@Id int
AS
	Delete FROM [ProfessionnalCategory] WHERE [Id] = @Id;
RETURN 0
