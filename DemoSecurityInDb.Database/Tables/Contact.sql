﻿CREATE TABLE [dbo].[Contact]
(
	[Id] INT NOT NULL IDENTITY,
	[LastName] NVARCHAR(50) NOT NULL,
	[FirstName] NVARCHAR(50) NOT NULL,
	[Email] NVARCHAR(384) NOT NULL,
	[Created] DATETIME2(7) NOT NULL
		CONSTRAINT DF_Contact_Created DEFAULT (SYSDATETIME()),
	[LastUpdated] DATETIME2(7) NOT NULL
		CONSTRAINT DF_Contact_LastUpdated DEFAULT (SYSDATETIME()),
    CONSTRAINT [PK_Contact] PRIMARY KEY ([Id]) 
)