module Belot.Web.Models.Game {
    'use strict';

    export class CreateRoomModel {
        first_player_id: string;
    }

    export class CreateGameModel {
        first_player_id: string;
        second_player_id: string;
        third_player_id: string;
        fourth_player_id: string;
    }
}