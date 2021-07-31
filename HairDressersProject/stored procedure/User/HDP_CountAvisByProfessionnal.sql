﻿CREATE PROCEDURE [dbo].[HDP_CountAvisByProfessionnal]
	@Id int
AS
BEGIN
	SELECT COUNT(*)
	From [User] u JOIN Avis a
	ON u.Id = a.UserIdProfessionnal
	WHERE u.Id = @Id
	Group By a.UserIdProfessionnal
	RETURN 0
END
