CREATE TABLE [dbo].[Users] (
    [UserID]    INT          IDENTITY (1, 1) NOT NULL,
    [FirstName] VARCHAR (50) NOT NULL,
    [LastName]  VARCHAR (50) NOT NULL,
    [Email]     VARCHAR (50) NOT NULL,
    [HouseID]   INT          NULL,
    [Password]  VARCHAR (50) NULL,
    CONSTRAINT [PK__tmp_ms_x__1788CCAC5009F4F0] PRIMARY KEY CLUSTERED ([UserID] ASC),
    CONSTRAINT [FK_Users_HouseTable] FOREIGN KEY ([HouseID]) REFERENCES [dbo].[HouseTable] ([HouseID])
);

