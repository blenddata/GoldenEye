﻿CREATE VIEW [Portal].[TaskType]
AS 
	SELECT
		c.[Id]        AS [Id],
		c.[Nazwa]     AS [Nazwa],
		c.[IsDeleted] AS [IsDeleted]
	FROM
		dbo._Slownik_Zleceniodawca c;