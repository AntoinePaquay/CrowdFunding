﻿/*
Deployment script for CrowdFundingAdriAntoine2

This code was generated by a tool.
Changes to this file may cause incorrect behavior and will be lost if
the code is regenerated.
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "CrowdFundingAdriAntoine2"
:setvar DefaultFilePrefix "CrowdFundingAdriAntoine2"
:setvar DefaultDataPath "C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\"
:setvar DefaultLogPath "C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\"

GO
:on error exit
GO
/*
Detect SQLCMD mode and disable script execution if SQLCMD mode is not supported.
To re-enable the script after enabling SQLCMD mode, execute the following:
SET NOEXEC OFF; 
*/
:setvar __IsSqlCmdEnabled "True"
GO
IF N'$(__IsSqlCmdEnabled)' NOT LIKE N'True'
    BEGIN
        PRINT N'SQLCMD mode must be enabled to successfully execute this script.';
        SET NOEXEC ON;
    END


GO
USE [master];


GO

IF (DB_ID(N'$(DatabaseName)') IS NOT NULL) 
BEGIN
    ALTER DATABASE [$(DatabaseName)]
    SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE [$(DatabaseName)];
END

GO
PRINT N'Creating database $(DatabaseName)...'
GO
CREATE DATABASE [$(DatabaseName)]
    ON 
    PRIMARY(NAME = [$(DatabaseName)], FILENAME = N'$(DefaultDataPath)$(DefaultFilePrefix)_Primary.mdf')
    LOG ON (NAME = [$(DatabaseName)_log], FILENAME = N'$(DefaultLogPath)$(DefaultFilePrefix)_Primary.ldf') COLLATE SQL_Latin1_General_CP1_CI_AS
GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET AUTO_CLOSE OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
USE [$(DatabaseName)];


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET ANSI_NULLS ON,
                ANSI_PADDING ON,
                ANSI_WARNINGS ON,
                ARITHABORT ON,
                CONCAT_NULL_YIELDS_NULL ON,
                NUMERIC_ROUNDABORT OFF,
                QUOTED_IDENTIFIER ON,
                ANSI_NULL_DEFAULT ON,
                CURSOR_DEFAULT LOCAL,
                RECOVERY FULL,
                CURSOR_CLOSE_ON_COMMIT OFF,
                AUTO_CREATE_STATISTICS ON,
                AUTO_SHRINK OFF,
                AUTO_UPDATE_STATISTICS ON,
                RECURSIVE_TRIGGERS OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET ALLOW_SNAPSHOT_ISOLATION OFF;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET READ_COMMITTED_SNAPSHOT OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET AUTO_UPDATE_STATISTICS_ASYNC OFF,
                PAGE_VERIFY NONE,
                DATE_CORRELATION_OPTIMIZATION OFF,
                DISABLE_BROKER,
                PARAMETERIZATION SIMPLE,
                SUPPLEMENTAL_LOGGING OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF IS_SRVROLEMEMBER(N'sysadmin') = 1
    BEGIN
        IF EXISTS (SELECT 1
                   FROM   [master].[dbo].[sysdatabases]
                   WHERE  [name] = N'$(DatabaseName)')
            BEGIN
                EXECUTE sp_executesql N'ALTER DATABASE [$(DatabaseName)]
    SET TRUSTWORTHY OFF,
        DB_CHAINING OFF 
    WITH ROLLBACK IMMEDIATE';
            END
    END
ELSE
    BEGIN
        PRINT N'The database settings cannot be modified. You must be a SysAdmin to apply these settings.';
    END


GO
IF IS_SRVROLEMEMBER(N'sysadmin') = 1
    BEGIN
        IF EXISTS (SELECT 1
                   FROM   [master].[dbo].[sysdatabases]
                   WHERE  [name] = N'$(DatabaseName)')
            BEGIN
                EXECUTE sp_executesql N'ALTER DATABASE [$(DatabaseName)]
    SET HONOR_BROKER_PRIORITY OFF 
    WITH ROLLBACK IMMEDIATE';
            END
    END
ELSE
    BEGIN
        PRINT N'The database settings cannot be modified. You must be a SysAdmin to apply these settings.';
    END


GO
ALTER DATABASE [$(DatabaseName)]
    SET TARGET_RECOVERY_TIME = 0 SECONDS 
    WITH ROLLBACK IMMEDIATE;


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET FILESTREAM(NON_TRANSACTED_ACCESS = OFF),
                CONTAINMENT = NONE 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET AUTO_CREATE_STATISTICS ON(INCREMENTAL = OFF),
                MEMORY_OPTIMIZED_ELEVATE_TO_SNAPSHOT = OFF,
                DELAYED_DURABILITY = DISABLED 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET QUERY_STORE (QUERY_CAPTURE_MODE = ALL, DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_PLANS_PER_QUERY = 200, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 367), MAX_STORAGE_SIZE_MB = 100) 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET QUERY_STORE = OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
        ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
        ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
        ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
        ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
        ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
        ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
        ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET TEMPORAL_HISTORY_RETENTION ON 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF fulltextserviceproperty(N'IsFulltextInstalled') = 1
    EXECUTE sp_fulltext_database 'enable';


GO
PRINT N'Creating Table [dbo].[Article]...';


GO
CREATE TABLE [dbo].[Article] (
    [Id]           INT             IDENTITY (1, 1) NOT NULL,
    [ProjectId]    INT             NOT NULL,
    [Text]         NVARCHAR (5000) NULL,
    [Created]      DATETIME2 (7)   NOT NULL,
    [LastModified] DATETIME2 (7)   NULL,
    CONSTRAINT [PK_Article] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creating Table [dbo].[Comment]...';


GO
CREATE TABLE [dbo].[Comment] (
    [Id]           INT             IDENTITY (1, 1) NOT NULL,
    [Text]         NVARCHAR (1000) NULL,
    [MemberId]     INT             NOT NULL,
    [ProjectId]    INT             NOT NULL,
    [Created]      DATETIME2 (7)   NOT NULL,
    [LastModified] DATETIME2 (7)   NULL,
    CONSTRAINT [PK_Comment] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creating Table [dbo].[Member]...';


GO
CREATE TABLE [dbo].[Member] (
    [Id]           INT            IDENTITY (1, 1) NOT NULL,
    [LastName]     NVARCHAR (100) NOT NULL,
    [FirstName]    NVARCHAR (100) NOT NULL,
    [Username]     NVARCHAR (35)  NOT NULL,
    [Email]        NVARCHAR (320) NOT NULL,
    [PasswordHash] CHAR (97)      NOT NULL,
    [BirthDate]    DATE           NOT NULL,
    [Image]        VARCHAR (200)  NULL,
    [RegisterDate] DATETIME       NOT NULL,
    [Created]      DATETIME2 (7)  NOT NULL,
    [LastModified] DATETIME2 (7)  NULL,
    CONSTRAINT [PK_Member] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [UK_Member_Email] UNIQUE NONCLUSTERED ([Email] ASC),
    CONSTRAINT [UK_Member_Username] UNIQUE NONCLUSTERED ([Username] ASC)
);


GO
PRINT N'Creating Table [dbo].[PrivateMessage]...';


GO
CREATE TABLE [dbo].[PrivateMessage] (
    [Id]           INT             IDENTITY (1, 1) NOT NULL,
    [SenderId]     INT             NOT NULL,
    [RecipientId]  INT             NOT NULL,
    [Text]         NVARCHAR (1000) NULL,
    [Created]      DATETIME2 (7)   NOT NULL,
    [LastModified] DATETIME2 (7)   NULL
);


GO
PRINT N'Creating Table [dbo].[Project]...';


GO
CREATE TABLE [dbo].[Project] (
    [Id]           INT            IDENTITY (1, 1) NOT NULL,
    [Name]         NVARCHAR (150) NOT NULL,
    [Description]  NVARCHAR (500) NULL,
    [Opening]      DATETIME       NOT NULL,
    [Closing]      DATETIME       NOT NULL,
    [Created]      DATETIME       NULL,
    [LastModified] DATETIME       NULL,
    [MemberId]     INT            NOT NULL,
    [CategoryId]   INT            NOT NULL,
    CONSTRAINT [PK_Project] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creating Table [dbo].[ProjectCategory]...';


GO
CREATE TABLE [dbo].[ProjectCategory] (
    [Id]           INT           IDENTITY (1, 1) NOT NULL,
    [Name]         VARCHAR (50)  NOT NULL,
    [Created]      DATETIME2 (7) NOT NULL,
    [LastModified] DATETIME2 (7) NULL,
    CONSTRAINT [PK_ProjectCategory] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creating Table [dbo].[Reward]...';


GO
CREATE TABLE [dbo].[Reward] (
    [Id]           INT            IDENTITY (1, 1) NOT NULL,
    [Name]         NVARCHAR (50)  NOT NULL,
    [Description]  NVARCHAR (200) NULL,
    [Price]        SMALLMONEY     NOT NULL,
    [Stock]        INT            NULL,
    [ProjectId]    INT            NOT NULL,
    [Delivery]     DATE           NULL,
    [Created]      DATETIME2 (7)  NOT NULL,
    [LastModified] DATETIME2 (7)  NULL,
    CONSTRAINT [PK_Reward] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creating Table [dbo].[Transactions]...';


GO
CREATE TABLE [dbo].[Transactions] (
    [Id]           INT           IDENTITY (1, 1) NOT NULL,
    [MemberId]     INT           NOT NULL,
    [ProjectId]    INT           NOT NULL,
    [Amount]       SMALLMONEY    NOT NULL,
    [Created]      DATETIME2 (7) NOT NULL,
    [LastModified] DATETIME2 (7) NULL,
    CONSTRAINT [PK_Transaction] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creating Default Constraint [dbo].[DF_Member_Created]...';


GO
ALTER TABLE [dbo].[Member]
    ADD CONSTRAINT [DF_Member_Created] DEFAULT (SYSDATETIME()) FOR [LastModified];


GO
PRINT N'Creating Default Constraint [dbo].[DF_Reward_Created]...';


GO
ALTER TABLE [dbo].[Reward]
    ADD CONSTRAINT [DF_Reward_Created] DEFAULT (SYSDATETIME()) FOR [LastModified];


GO
PRINT N'Creating Foreign Key [dbo].[FK_Article_Project]...';


GO
ALTER TABLE [dbo].[Article]
    ADD CONSTRAINT [FK_Article_Project] FOREIGN KEY ([ProjectId]) REFERENCES [dbo].[Project] ([Id]);


GO
PRINT N'Creating Foreign Key [dbo].[FK_Comment_Member]...';


GO
ALTER TABLE [dbo].[Comment]
    ADD CONSTRAINT [FK_Comment_Member] FOREIGN KEY ([MemberId]) REFERENCES [dbo].[Member] ([Id]);


GO
PRINT N'Creating Foreign Key [dbo].[FK_Comment_Project]...';


GO
ALTER TABLE [dbo].[Comment]
    ADD CONSTRAINT [FK_Comment_Project] FOREIGN KEY ([ProjectId]) REFERENCES [dbo].[Project] ([Id]);


GO
PRINT N'Creating Foreign Key [dbo].[FK_Project_Member]...';


GO
ALTER TABLE [dbo].[Project]
    ADD CONSTRAINT [FK_Project_Member] FOREIGN KEY ([MemberId]) REFERENCES [dbo].[Member] ([Id]);


GO
PRINT N'Creating Foreign Key [dbo].[FK_Project_ProjectCategory]...';


GO
ALTER TABLE [dbo].[Project]
    ADD CONSTRAINT [FK_Project_ProjectCategory] FOREIGN KEY ([CategoryId]) REFERENCES [dbo].[ProjectCategory] ([Id]);


GO
PRINT N'Creating Foreign Key [dbo].[FK_Reward_Project]...';


GO
ALTER TABLE [dbo].[Reward]
    ADD CONSTRAINT [FK_Reward_Project] FOREIGN KEY ([ProjectId]) REFERENCES [dbo].[Project] ([Id]);


GO
PRINT N'Creating Foreign Key [dbo].[FK_Transaction_Member]...';


GO
ALTER TABLE [dbo].[Transactions]
    ADD CONSTRAINT [FK_Transaction_Member] FOREIGN KEY ([MemberId]) REFERENCES [dbo].[Member] ([Id]);


GO
PRINT N'Creating Foreign Key [dbo].[FK_Transaction_Project]...';


GO
ALTER TABLE [dbo].[Transactions]
    ADD CONSTRAINT [FK_Transaction_Project] FOREIGN KEY ([ProjectId]) REFERENCES [dbo].[Project] ([Id]);


GO
PRINT N'Creating Check Constraint [dbo].[CK_Project_Closing]...';


GO
ALTER TABLE [dbo].[Project]
    ADD CONSTRAINT [CK_Project_Closing] CHECK (DATEDIFF(day, [Opening], [Closing]) >= 1 AND DATEDIFF(day, [Opening], [Closing]) < 90);


GO
PRINT N'Creating Check Constraint [dbo].[CK_Project_Opening]...';


GO
ALTER TABLE [dbo].[Project]
    ADD CONSTRAINT [CK_Project_Opening] CHECK ([Opening] > SYSDATETIME());


GO
PRINT N'Creating Check Constraint [dbo].[CK_Reward_Price]...';


GO
ALTER TABLE [dbo].[Reward]
    ADD CONSTRAINT [CK_Reward_Price] CHECK ([Price] > 0 AND [Price] <= 10000);


GO
PRINT N'Creating Check Constraint [dbo].[CK_Reward_Stock]...';


GO
ALTER TABLE [dbo].[Reward]
    ADD CONSTRAINT [CK_Reward_Stock] CHECK ([Stock] > 0 AND [Stock] <= 1000);


GO
PRINT N'Creating Check Constraint [dbo].[CK_Transaction_Amount]...';


GO
ALTER TABLE [dbo].[Transactions]
    ADD CONSTRAINT [CK_Transaction_Amount] CHECK ([Amount] > 0);


GO
DECLARE @VarDecimalSupported AS BIT;

SELECT @VarDecimalSupported = 0;

IF ((ServerProperty(N'EngineEdition') = 3)
    AND (((@@microsoftversion / power(2, 24) = 9)
          AND (@@microsoftversion & 0xffff >= 3024))
         OR ((@@microsoftversion / power(2, 24) = 10)
             AND (@@microsoftversion & 0xffff >= 1600))))
    SELECT @VarDecimalSupported = 1;

IF (@VarDecimalSupported > 0)
    BEGIN
        EXECUTE sp_db_vardecimal_storage_format N'$(DatabaseName)', 'ON';
    END


GO
PRINT N'Update complete.';


GO
