CREATE TABLE [dbo].[movie_company] (
    [movie_id]   INT DEFAULT (NULL) NULL,
    [company_id] INT DEFAULT (NULL) NULL,
    CONSTRAINT [fk_mc_comp] FOREIGN KEY ([company_id]) REFERENCES [dbo].[production_company] ([company_id]),
    CONSTRAINT [fk_mc_movie] FOREIGN KEY ([movie_id]) REFERENCES [dbo].[movie] ([movie_id])
);

