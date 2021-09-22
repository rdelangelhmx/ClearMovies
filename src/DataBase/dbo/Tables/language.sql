CREATE TABLE [dbo].[language] (
    [language_id]   INT           NOT NULL,
    [language_code] VARCHAR (10)  DEFAULT (NULL) NULL,
    [language_name] VARCHAR (500) DEFAULT (NULL) NULL,
    PRIMARY KEY CLUSTERED ([language_id] ASC)
);

