﻿--CREATE PROCEDURE [dbo].[HDP_ALLAvisAndCommentByProfessionnal]
--	@Id int
--AS
--BEGIN
--	Select A.Id, A.Content, A.Star, A.UserIdProfessionnal, A.UserIdMember, A.Timestamp, c.Id, c.Content, c.AvisId FROM [Avis] A JOIN [Comment] c ON  A.UserIdProfessionnal = 4 AND C.AvisId = A.Id
--	RETURN 0
--END
