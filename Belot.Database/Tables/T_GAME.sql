﻿CREATE TABLE [dbo].[T_GAME]
(
	[GAME_ID] INT NOT NULL PRIMARY KEY, 
    [CREATED_AT] DATETIME NOT NULL, 
	[FINISHED_AT] DATETIME NULL,
    [TEAM_A_RESULT] INT NOT NULL, 
    [TEAM_B_RESULT] INT NOT NULL,
	[CURRENT_USER_FK] INT NOT NULL,
	[LAST_CARD_PLAYED_FK] INT NULL,
	CONSTRAINT [FK_T_GAME_LAST_CARD_PLAYED_TD_CARD] FOREIGN KEY ([LAST_CARD_PLAYED_FK]) REFERENCES [dbo].[TD_CARD]([CARD_ID]),
	CONSTRAINT [FK_T_GAME_CURRENT_USER_T_USER] FOREIGN KEY ([CURRENT_USER_FK]) REFERENCES [dbo].[T_USER]([USER_ID])
)
