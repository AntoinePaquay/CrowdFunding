CREATE TABLE [dbo].[Reward]
(
	[Id] INT NOT NULL IDENTITY (1, 1),
	[Name] NVARCHAR(50) NOT NULL,
	[Description] NVARCHAR(200) NULL,
	[Price] SMALLMONEY NOT NULL,
	[Stock] INT NULL,
	[ProjectId] INT NOT NULL,
	[Delivery] Date,
	[Created] DateTime2 NULL
	CONSTRAINT DF_Reward_Created DEFAULT (SYSDATETIME()),
	[LastModified] DateTime2

	CONSTRAINT PK_Reward PRIMARY KEY([Id])
	CONSTRAINT FK_Reward_Project FOREIGN KEY ([ProjectId]) REFERENCES Project([Id])
	CONSTRAINT CK_Reward_Price CHECK ([Price] > 0 AND [Price] <= 10000)
	CONSTRAINT CK_Reward_Stock CHECK ([Stock] > 0 AND [Stock] <= 1000)

	
)
