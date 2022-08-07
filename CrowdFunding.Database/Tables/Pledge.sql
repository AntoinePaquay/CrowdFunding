CREATE TABLE [dbo].[Pledge]
(
	[Id] INT NOT NULL IDENTITY (1, 1),
	[MemberId] INT NOT NULL,
	[ProjectId] INT NOT NULL,
	[Amount] DECIMAL NOT NULL,

	[Created] DateTime2 NULL
	CONSTRAINT DF_Pledge_Created DEFAULT (SYSDATETIME())
	CONSTRAINT PK_Pledge PRIMARY KEY ([Id])
	CONSTRAINT FK_Pledge_Member FOREIGN KEY ([MemberId]) REFERENCES [Member]([Id])
	CONSTRAINT FK_Pledge_Project FOREIGN KEY ([ProjectId]) REFERENCES [Project]([Id])
	CONSTRAINT CK_Pledge_Amount CHECK ([Amount] > 0)
)
