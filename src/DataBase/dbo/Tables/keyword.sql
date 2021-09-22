CREATE TABLE [dbo].[keyword] (
    [keyword_id]   INT           NOT NULL,
    [keyword_name] NVARCHAR (50) CONSTRAINT [DF__keyword__keyword__30F848ED] DEFAULT (NULL) NULL,
    CONSTRAINT [PK__keyword__03E8D7CF2253C540] PRIMARY KEY CLUSTERED ([keyword_id] ASC)
);



