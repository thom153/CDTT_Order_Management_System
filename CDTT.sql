

CREATE TABLE [dbo].[category] (
    [catID]   INT            IDENTITY (1, 1) NOT NULL,
    [catName] NVARCHAR (128) NULL,
    CONSTRAINT [PK__category__17B6DD26CF2276AC] PRIMARY KEY CLUSTERED ([catID] ASC)
);
CREATE TABLE [dbo].[Items] (
    [itemID]     INT            IDENTITY (1, 1) NOT NULL,
    [iName]      NVARCHAR (128) NULL,
    [iPrice]     FLOAT (53)     NULL,
    [iUnitCost]  NVARCHAR (10)  NULL,
    [categoryID] INT            NULL,
    [iImage]     IMAGE          NULL,
    [IsActive]   BIT            DEFAULT ((1)) NOT NULL,
    PRIMARY KEY CLUSTERED ([itemID] ASC)
);

CREATE TABLE [dbo].[staff] (
    [staffID]  INT           IDENTITY (1, 1) NOT NULL,
    [sName]    NVARCHAR (50) NULL,
    [sGender]  NVARCHAR (3)  NULL,
    [sPhone]   NCHAR (10)    NULL,
    [sAddress] NVARCHAR (50) NULL,
    [sRole]    NVARCHAR (20) NULL,
    PRIMARY KEY CLUSTERED ([staffID] ASC)
);

CREATE TABLE [dbo].[tables] (
    [tid]     INT           IDENTITY (1, 1) NOT NULL,
    [tname]   NVARCHAR (10) NULL,
    [tchair]  INT           NULL,
    [tstatus] NVARCHAR (20) NULL,
    PRIMARY KEY CLUSTERED ([tid] ASC)
);
CREATE TABLE [dbo].[tblDetails] (
    [DetailID] INT        IDENTITY (1, 1) NOT NULL,
    [MainID]   INT        NULL,
    [itemmID]  INT        NULL,
    [qty]      INT        NULL,
    [price]    FLOAT (53) NULL,
    [amount]   FLOAT (53) NULL,
    PRIMARY KEY CLUSTERED ([DetailID] ASC)
);

CREATE TABLE [dbo].[tblMain] (
    [MainID]     INT           IDENTITY (1, 1) NOT NULL,
    [aDate]      DATE          NULL,
    [aTime]      VARCHAR (15)  NULL,
    [TableName]  NVARCHAR (20) NULL,
    [WaiterName] NVARCHAR (50) NULL,
    [status]     NVARCHAR (20) NULL,
    [total]      FLOAT (53)    NULL,
    [received]   FLOAT (53)    NULL,
    [change]     FLOAT (53)    NULL,
    PRIMARY KEY CLUSTERED ([MainID] ASC)
);
CREATE TABLE [dbo].[Users] (
    [userID]   INT          IDENTITY (1, 1) NOT NULL,
    [username] VARCHAR (50) NOT NULL,
    [upass]    VARCHAR (10) NOT NULL,
    [uName]    VARCHAR (50) NOT NULL,
    [uphone]   VARCHAR (20) NULL,
    PRIMARY KEY CLUSTERED ([userID] ASC)
);


