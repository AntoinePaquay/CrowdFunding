CREATE TABLE [dbo].[ParameterHistory]
(
	[Id] INT NOT NULL IDENTITY,
	[Closing] DateTime2 NOT NULL,
	[Goal] DECIMAL (12, 2),
	[ProjectId] INT NOT NULL,

	[Created] DateTime2
	CONSTRAINT DF_ParameterHistory_Created DEFAULT (SYSDATETIME()),
	CONSTRAINT PK_ParameterHistory PRIMARY KEY ([Id]),
	CONSTRAINT FK_ParameterHistory_Project FOREIGN KEY ([ProjectId]) REFERENCES Project([Id]),
)