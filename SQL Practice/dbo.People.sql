CREATE TABLE [dbo].[People] (
    [Id]    INT           IDENTITY (1, 1) NOT NULL,
    [Name]  NVARCHAR (50) NULL,
    [Age]   INT           NULL,
    [Phone] NVARCHAR (50) NULL,
    [Email] NVARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

