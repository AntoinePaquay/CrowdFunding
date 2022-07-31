CREATE TABLE [dbo].[Transaction]
(
	[Id] INT NOT NULL IDENTITY (1, 1),
	[MemberId] INT NOT NULL,
	[ProjectId] INT NOT NULL,
	[Amount] SMALLMONEY NOT NULL,
	[Created] DateTime2 NULL,
	[LastModified] DateTime2

	CONSTRAINT PK_Transaction PRIMARY KEY ([Id])
	CONSTRAINT FK_Transaction_Member FOREIGN KEY ([MemberId]) REFERENCES [Member]([Id])
	CONSTRAINT FK_Transaction_Project FOREIGN KEY ([ProjectId]) REFERENCES [Project]([Id])
	CONSTRAINT CK_Transaction_Amount CHECK ([Amount] > 0)
)
