CREATE TABLE [dbo].[movie] (
    [movie_id]     INT             NOT NULL,
    [title]        VARCHAR (1000)  CONSTRAINT [DF__movie__title__3A81B327] DEFAULT (NULL) NULL,
    [budget]       BIGINT          CONSTRAINT [DF__movie__budget__3B75D760] DEFAULT (NULL) NULL,
    [homepage]     VARCHAR (1000)  CONSTRAINT [DF__movie__homepage__3C69FB99] DEFAULT (NULL) NULL,
    [overview]     VARCHAR (1000)  CONSTRAINT [DF__movie__overview__3D5E1FD2] DEFAULT (NULL) NULL,
    [popularity]   DECIMAL (14, 8) CONSTRAINT [DF__movie__popularit__3E52440B] DEFAULT (NULL) NULL,
    [release_date] SMALLDATETIME   CONSTRAINT [DF__movie__release_d__3F466844] DEFAULT (NULL) NULL,
    [revenue]      BIGINT          CONSTRAINT [DF__movie__revenue__403A8C7D] DEFAULT (NULL) NULL,
    [runtime]      INT             CONSTRAINT [DF__movie__runtime__412EB0B6] DEFAULT (NULL) NULL,
    [movie_status] VARCHAR (50)    CONSTRAINT [DF__movie__movie_sta__4222D4EF] DEFAULT (NULL) NULL,
    [tagline]      VARCHAR (1000)  CONSTRAINT [DF__movie__tagline__4316F928] DEFAULT (NULL) NULL,
    [vote_average] DECIMAL (4, 2)  CONSTRAINT [DF__movie__vote_aver__440B1D61] DEFAULT (NULL) NULL,
    [vote_count]   INT             CONSTRAINT [DF__movie__vote_coun__44FF419A] DEFAULT (NULL) NULL,
    CONSTRAINT [PK__movie__83CDF7498C3E81CB] PRIMARY KEY CLUSTERED ([movie_id] ASC)
);



