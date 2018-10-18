CREATE TABLE [dbo].[ProductsBought] (
    [ProductID]    INT          IDENTITY (1, 1) NOT NULL,
    [Quantity]     INT          NULL,
    [Price]        FLOAT (53)   NULL,
    [Description]  VARCHAR (50) NULL,
    [ProductGroup] VARCHAR (50) NULL,
    [UserPaidFull] INT          NULL,
    [HouseID]      INT          NULL,
    [Name]         VARCHAR (50) NULL,
    CONSTRAINT [PK__Products__B40CC6ED4B3C5675] PRIMARY KEY CLUSTERED ([ProductID] ASC),
    CONSTRAINT [FK_ProductsBought_HouseTable] FOREIGN KEY ([HouseID]) REFERENCES [dbo].[HouseTable] ([HouseID])
);

