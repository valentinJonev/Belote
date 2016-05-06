﻿CREATE TABLE [dbo].[TM_USER_GAME]
(
	[USER_ID] INT NOT NULL, 
    [GAME_ID] INT NOT NULL,
	CONSTRAINT [PK_TM_USER_GAME] PRIMARY KEY CLUSTERED ([USER_ID] ASC, [GAME_ID] ASC),
	CONSTRAINT [FK_TM_USER_GAME_T_GAME_GAME_ID] FOREIGN KEY ([GAME_ID]) REFERENCES [dbo].[T_GAME] ([GAME_ID]),
    CONSTRAINT [FK_TM_USER_GAME_T_USER_USER_ID] FOREIGN KEY ([USER_ID]) REFERENCES [dbo].[T_USER] ([USER_ID])
)
