CREATE TABLE [dbo].[PrivateMessage]
(
	[Id] INT NOT NULL IDENTITY,
	[SenderId] INT NOT NULL,
	[RecipientId] INT NOT NULL,
	[Text] NVARCHAR(1000),

	[Created] DateTime2 NULL
	CONSTRAINT DF_PrivateMessage_Created DEFAULT (SYSDATETIME()),

	CONSTRAINT PK_PrivateMessage PRIMARY KEY ([Id])
)
