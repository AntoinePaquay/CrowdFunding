CREATE TABLE [dbo].[ProjectStatusHistory]
(
	[Id] INT NOT NULL IDENTITY,
	[ProjectId] INT NOT NULL,
	[ProjectStatusId] INT NOT NULL,

	[Created] DateTime2 NULL
	CONSTRAINT DF_ProjectStatusHistory_Created DEFAULT (SYSDATETIME()),
	CONSTRAINT FK_ProjectStatusHistory_Project FOREIGN KEY ([ProjectId]) REFERENCES Project([Id]),
	CONSTRAINT FK_ProjectStatusHistory_ProjectStatus FOREIGN KEY ([ProjectStatusId]) REFERENCES Project([Id]),


)
