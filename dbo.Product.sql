CREATE TABLE [dbo].[Product] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [Name]        NVARCHAR (MAX) NOT NULL,
    [Price]       INT            NOT NULL,
    [Orderdate]   DATETIME2 (7)  NULL,
    [Category]    NVARCHAR (MAX) NOT NULL,
    [Shelf]       NVARCHAR (MAX) NULL,
    [Count]       INT            NOT NULL,
    [Description] NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED ([Id] ASC)
);

