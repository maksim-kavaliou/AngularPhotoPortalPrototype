CREATE TABLE [dbo].[User] (
    [Id]   INT             IDENTITY (1, 1) NOT NULL,
    [Name] NVARCHAR (250) NOT NULL,
    [Email] NVARCHAR (250) NOT NULL,
    [Password] NVARCHAR (1000) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

GO

ALTER TABLE [dbo].[User]
ADD CONSTRAINT [UC_User_Email] UNIQUE ([Email])

GO