CREATE TABLE [dbo].[country] (
    [country_id]       INT           NOT NULL,
    [country_iso_code] VARCHAR (10)  DEFAULT (NULL) NULL,
    [country_name]     VARCHAR (200) DEFAULT (NULL) NULL,
    PRIMARY KEY CLUSTERED ([country_id] ASC)
);

