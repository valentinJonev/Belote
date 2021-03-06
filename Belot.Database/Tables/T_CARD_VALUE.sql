﻿CREATE TABLE [dbo].[T_GAME_MODE_CARD_VALUE]
(
	[CARD_VALUE_ID] INT NOT NULL PRIMARY KEY, 
    [VALUE] INT NOT NULL, 
    [CARD_FK] INT NOT NULL, 
    [GAME_MODE_FK] INT NOT NULL, 
    CONSTRAINT [FK_T_GAME_MODE_CARD_CARD_TD_CARD] FOREIGN KEY ([CARD_FK]) REFERENCES [dbo].[TD_CARD]([CARD_ID]),
	CONSTRAINT [FK_T_GAME_MODE_CARD_GAME_MODE_TD_GAME_MODE] FOREIGN KEY ([GAME_MODE_FK]) REFERENCES [dbo].[TD_GAME_MODE]([GAME_MODE_ID])
)
