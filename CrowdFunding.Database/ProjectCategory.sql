CREATE TABLE [dbo].[ProjectCategory]
(
	[Id] INT NOT NULL IDENTITY (1, 1),
	[Name] VARCHAR(50) NOT NULL,
	[Created] DateTime2 NULL,
	[LastModified] DateTime2

	CONSTRAINT PK_ProjectCategory PRIMARY KEY ([Id])
)
