CREATE TABLE [dbo].[NotOweTable] (
    [NotOweID]  INT        NOT NULL,
    [UserID]    INT        NULL,
    [Amount]    NCHAR (10) NULL,
    [ProductID] INT        NULL,
    PRIMARY KEY CLUSTERED ([NotOweID] ASC)
);

