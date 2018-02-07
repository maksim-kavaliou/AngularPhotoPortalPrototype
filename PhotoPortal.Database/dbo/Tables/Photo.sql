CREATE TABLE [dbo].[Photo] (
    [Id]   INT             IDENTITY (1, 1) NOT NULL,
    [BlobName] NVARCHAR (1000) NOT NULL
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

GO