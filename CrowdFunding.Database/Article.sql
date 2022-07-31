CREATE TABLE [dbo].[Article]
(
	[Id] INT IDENTITY (1, 1) NOT NULL,
	[ProjectId] INT NOT NULL,
	[Text] NVARCHAR(4000),
	[Created] DateTime2 NULL,
	[LastModified] DateTime2

	CONSTRAINT PK_Article PRIMARY KEY ([Id]),
	CONSTRAINT FK_Article_Project FOREIGN KEY ([ProjectId]) REFERENCES Project([Id])

)
