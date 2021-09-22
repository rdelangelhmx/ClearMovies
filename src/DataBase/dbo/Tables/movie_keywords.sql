CREATE TABLE [dbo].[movie_keywords] (
    [movie_id]   INT DEFAULT (NULL) NULL,
    [keyword_id] INT DEFAULT (NULL) NULL,
    CONSTRAINT [fk_mk_keyword] FOREIGN KEY ([keyword_id]) REFERENCES [dbo].[keyword] ([keyword_id]),
    CONSTRAINT [fk_mk_movie] FOREIGN KEY ([movie_id]) REFERENCES [dbo].[movie] ([movie_id])
);

