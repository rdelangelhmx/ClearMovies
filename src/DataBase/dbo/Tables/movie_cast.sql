CREATE TABLE [dbo].[movie_cast] (
    [movie_id]       INT           DEFAULT (NULL) NULL,
    [person_id]      INT           DEFAULT (NULL) NULL,
    [character_name] VARCHAR (400) DEFAULT (NULL) NULL,
    [gender_id]      INT           DEFAULT (NULL) NULL,
    [cast_order]     INT           DEFAULT (NULL) NULL,
    CONSTRAINT [fk_mca_gender] FOREIGN KEY ([gender_id]) REFERENCES [dbo].[gender] ([gender_id]),
    CONSTRAINT [fk_mca_movie] FOREIGN KEY ([movie_id]) REFERENCES [dbo].[movie] ([movie_id]),
    CONSTRAINT [fk_mca_per] FOREIGN KEY ([person_id]) REFERENCES [dbo].[person] ([person_id])
);

