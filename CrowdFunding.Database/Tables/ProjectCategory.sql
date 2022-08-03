CREATE TABLE [dbo].[ProjectCategory]
(
	[Id] INT NOT NULL IDENTITY (1, 1),
	[Name] VARCHAR(50) NOT NULL,
	CONSTRAINT PK_ProjectCategory PRIMARY KEY ([Id]),
	CONSTRAINT UK_ProjectCategory_Name UNIQUE ([Name])
)
