CREATE TABLE [dbo].[movie_languages] (
    [movie_id]         INT DEFAULT (NULL) NULL,
    [language_id]      INT DEFAULT (NULL) NULL,
    [language_role_id] INT DEFAULT (NULL) NULL,
    CONSTRAINT [fk_ml_lang] FOREIGN KEY ([language_id]) REFERENCES [dbo].[language] ([language_id]),
    CONSTRAINT [fk_ml_movie] FOREIGN KEY ([movie_id]) REFERENCES [dbo].[movie] ([movie_id]),
    CONSTRAINT [fk_ml_role] FOREIGN KEY ([language_role_id]) REFERENCES [dbo].[language_role] ([role_id])
);

