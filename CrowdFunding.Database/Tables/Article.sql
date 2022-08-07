CREATE TABLE [dbo].[Article]
(
	[Id] INT IDENTITY (1, 1) NOT NULL,
	[ProjectId] INT NOT NULL,
	[Name] VARCHAR(50) NOT NULL, 
	[Text] NVARCHAR(4000) NOT NULL,

	[Created] DateTime2 NULL
	CONSTRAINT DF_Article_Created DEFAULT (SYSDATETIME()),
	[LastModified] DateTime2

	CONSTRAINT PK_Article PRIMARY KEY ([Id]),
	CONSTRAINT FK_Article_Project FOREIGN KEY ([ProjectId]) REFERENCES Project([Id])
)
