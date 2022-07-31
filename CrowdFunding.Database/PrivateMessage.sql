CREATE TABLE [dbo].[PrivateMessage]
(
	[Id] INT NOT NULL IDENTITY,
	[SenderId] INT NOT NULL,
	--Receiver
	[RecipientId] INT NOT NULL,
	[Text] NVARCHAR(1000),
	[Created] DateTime2 NULL,
	[LastModified] DateTime2

	CONSTRAINT PK_PrivateMessage PRIMARY KEY ([Id])
)
