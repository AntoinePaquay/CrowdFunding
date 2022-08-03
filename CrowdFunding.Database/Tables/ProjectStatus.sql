CREATE TABLE [dbo].[ProjectStatus]
(
	[Id] INT NOT NULL IDENTITY,
	[Name] VARCHAR(50)

	CONSTRAINT PK_ProjectStatus PRIMARY KEY ([Id]),
	CONSTRAINT CK_ProjectStatus_Name UNIQUE ([Name])
)
