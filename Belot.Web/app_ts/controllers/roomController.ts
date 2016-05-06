/// <reference path="../_all.ts" />

module Belot.Web.Controllers {
    'use strict';

    export interface IRoomScope extends angular.IScope {
        controller: IRoomController;
    }

    export interface IRoomController {
        belotWebPaths: Constants.BelotWebPaths;
        users: Models.Account.UserListModel[];
        playersInRoom: number;

        startGame(): void;
    }

    export class RoomController implements IRoomController {
        static $inject = ['$scope', '$state', 'authService', 'belotWebPaths'];

        belotWebPaths: Constants.BelotWebPaths;
        users: Models.Account.UserListModel[];
        playersInRoom: number;

        public startGame(){

        }
    }
}