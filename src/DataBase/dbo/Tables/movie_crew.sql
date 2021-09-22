CREATE TABLE [dbo].[movie_crew] (
    [movie_id]      INT           DEFAULT (NULL) NULL,
    [person_id]     INT           DEFAULT (NULL) NULL,
    [department_id] INT           DEFAULT (NULL) NULL,
    [job]           VARCHAR (200) DEFAULT (NULL) NULL,
    CONSTRAINT [fk_mcr_dept] FOREIGN KEY ([department_id]) REFERENCES [dbo].[department] ([department_id]),
    CONSTRAINT [fk_mcr_movie] FOREIGN KEY ([movie_id]) REFERENCES [dbo].[movie] ([movie_id]),
    CONSTRAINT [fk_mcr_per] FOREIGN KEY ([person_id]) REFERENCES [dbo].[person] ([person_id])
);

