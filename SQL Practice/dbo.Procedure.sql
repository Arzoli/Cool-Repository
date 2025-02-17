CREATE TABLE [dbo].[People] (
    [Id]            INT           IDENTITY (1, 1) NOT NULL,
    [Name]          NVARCHAR (50) NOT NULL,
    [Age]           INT           NOT NULL,
    [Phone]     NVARCHAR (50) NOT NULL,
    [Email] NVARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

