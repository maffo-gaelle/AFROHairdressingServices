﻿CREATE PROCEDURE [dbo].[HDP_DeleteImage]
	@Id int
AS
BEGIN
	DELETE FROM [Image] WHERE [Id] = @Id
	RETURN 0
END
