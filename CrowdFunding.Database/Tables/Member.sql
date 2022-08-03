﻿CREATE TABLE [dbo].[Member]
(
	[Id] INT NOT NULL IDENTITY (1, 1),
	[LastName] NVARCHAR(100) NOT NULL,
	[FirstName] NVARCHAR(100) NOT NULL,
	[Username] VARCHAR(35) NOT NULL,
	[Email] NVARCHAR(320) NOT NULL,
	[PasswordHash] CHAR(97) NOT NULL,
	[BirthDate] DATE NOT NULL,
	[Image] VARCHAR(200) NULL,
	[CountryId] int NOT NULL,

	[Created] DateTime2 NULL
	CONSTRAINT DF_Account_Created DEFAULT (SYSDATETIME()),
	[LastLogin] DateTime2 NULL,
	

	CONSTRAINT PK_Member PRIMARY KEY ([Id]),
	CONSTRAINT UK_Member_Email UNIQUE ([Email]),
	CONSTRAINT FK_Member_Country FOREIGN KEY ([CountryId]) REFERENCES Country([Id]),
	CONSTRAINT UK_Member_Username UNIQUE ([Username]),
)