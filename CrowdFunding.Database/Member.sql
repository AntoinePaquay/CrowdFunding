CREATE TABLE [dbo].[Member]
(
	[Id] INT NOT NULL IDENTITY (1, 1),
	[LastName] NVARCHAR(100) NOT NULL,
	[FirstName] NVARCHAR(100) NOT NULL,
	[Username] NVARCHAR(35) NOT NULL,
	[Email] NVARCHAR(320) NOT NULL,
	[PasswordHash] CHAR(97) NOT NULL,
	[BirthDate] DATE NOT NULL,
	[Image] VARCHAR(200) NULL,
	[Created] DateTime2 NULL,
	[LastModified] DateTime2 NULL

	CONSTRAINT PK_Member PRIMARY KEY ([Id])
	CONSTRAINT UK_Member_Email UNIQUE ([Email])
	CONSTRAINT UK_Member_Username UNIQUE ([Username])
	CONSTRAINT DF_Member_Created DEFAULT (SYSDATETIME())
)
