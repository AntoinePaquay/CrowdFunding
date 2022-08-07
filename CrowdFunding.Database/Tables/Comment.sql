CREATE TABLE [dbo].[Comment]
(
	[Id] INT NOT NULL IDENTITY,
	[Text] NVARCHAR(1000) NOT NULL,
	[MemberId] INT NOT NULL,
	[ProjectId] INT NOT NULL,

	[Created] DateTime2 NULL
	CONSTRAINT DF_Comment_Created DEFAULT (SYSDATETIME()),
	[LastModified] DateTime2

	CONSTRAINT PK_Comment PRIMARY KEY ([Id])
	CONSTRAINT FK_Comment_Member FOREIGN KEY ([MemberId]) REFERENCES Member([Id])
	CONSTRAINT FK_Comment_Project FOREIGN KEY ([ProjectId]) REFERENCES Project([Id])
)
