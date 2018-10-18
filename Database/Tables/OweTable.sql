CREATE TABLE [dbo].[OweTable] (
    [OweID]     INT        NOT NULL,
    [ProductID] INT        NOT NULL,
    [UserID]    INT        NULL,
    [Amount]    FLOAT (53) NULL,
    PRIMARY KEY CLUSTERED ([OweID] ASC)
);

