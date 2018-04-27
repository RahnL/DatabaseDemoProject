CREATE TABLE [dbo].[Table] (
    [Id]  INT           IDENTITY (1, 1) NOT NULL,
    [S1]  VARCHAR (25)  NULL,
    [S2]  VARCHAR (50)  NULL,
    [Dt1] SMALLDATETIME NULL,
    [Dt2] SMALLDATETIME NULL,
    [N1]  INT           NULL,
    [N2]  INT           NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

