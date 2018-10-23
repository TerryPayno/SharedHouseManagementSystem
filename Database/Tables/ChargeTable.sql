CREATE TABLE [dbo].[ChargeTable] (
    [ChargeID]  INT          IDENTITY (1, 1) NOT NULL,
    [UserID]    INT          NULL,
    [FirstName] VARCHAR (50) NULL,
    [LastName]  VARCHAR (50) NULL,
    [Email]     VARCHAR (50) NULL,
    [HouseID]   INT          NULL,
    [IsPaying]  BIT          NULL,
    [Price]     FLOAT (53)   NULL,
    [ProductID] INT          NULL,
	[PaidShare] BIT			 NULL,
    CONSTRAINT [PK_ChargeTable] PRIMARY KEY CLUSTERED ([ChargeID] ASC)
);

