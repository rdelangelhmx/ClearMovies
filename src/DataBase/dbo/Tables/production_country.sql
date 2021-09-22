CREATE TABLE [dbo].[production_country] (
    [movie_id]   INT DEFAULT (NULL) NULL,
    [country_id] INT DEFAULT (NULL) NULL,
    CONSTRAINT [fk_pc_country] FOREIGN KEY ([country_id]) REFERENCES [dbo].[country] ([country_id]),
    CONSTRAINT [fk_pc_movie] FOREIGN KEY ([movie_id]) REFERENCES [dbo].[movie] ([movie_id])
);

