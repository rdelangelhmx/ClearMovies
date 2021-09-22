CREATE TABLE [dbo].[movie_genres] (
    [movie_id] INT DEFAULT (NULL) NULL,
    [genre_id] INT DEFAULT (NULL) NULL,
    CONSTRAINT [fk_mg_genre] FOREIGN KEY ([genre_id]) REFERENCES [dbo].[genre] ([genre_id]),
    CONSTRAINT [fk_mg_movie] FOREIGN KEY ([movie_id]) REFERENCES [dbo].[movie] ([movie_id])
);

