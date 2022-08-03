CREATE TABLE [dbo].[Project]
(
	[Id] INT NOT NULL IDENTITY (1, 1),
	[Name] NVARCHAR(150) NOT NULL,
	[Description] NVARCHAR(500),
	[Opening] DateTime2 NOT NULL,
	[Closing] DateTime2 NOT NULL,
	[Goal] DECIMAL (12, 2),
	[MemberId] INT NOT NULL,
	[ProjectCategoryId] INT NOT NULL,
	[ProjectStatusId] INT NOT NULL,

	[Created] DateTime2
	CONSTRAINT DF_Project_Created DEFAULT (SYSDATETIME()),

	CONSTRAINT PK_Project PRIMARY KEY ([Id]),
	CONSTRAINT FK_Project_Member FOREIGN KEY ([MemberId]) REFERENCES Member([Id]),
	CONSTRAINT FK_Project_ProjectCategory FOREIGN KEY ([ProjectCategoryId]) REFERENCES ProjectCategory([Id]),
	CONSTRAINT FK_Project_ProjectStatus FOREIGN KEY ([ProjectStatusId]) REFERENCES ProjectStatus([Id]),
	CONSTRAINT CK_Project_Closing CHECK (DATEDIFF(day, [Opening], [Closing]) >= 1 AND DATEDIFF(day, [Opening], [Closing]) < 90),
	CONSTRAINT CK_Project_Opening CHECK ([Opening] > SYSDATETIME())
)
