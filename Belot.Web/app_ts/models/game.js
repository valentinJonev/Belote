var Belot;
(function (Belot) {
    var Web;
    (function (Web) {
        var Models;
        (function (Models) {
            var Game;
            (function (Game) {
                'use strict';
                var CreateRoomModel = (function () {
                    function CreateRoomModel() {
                    }
                    return CreateRoomModel;
                })();
                Game.CreateRoomModel = CreateRoomModel;
                var CreateGameModel = (function () {
                    function CreateGameModel() {
                    }
                    return CreateGameModel;
                })();
                Game.CreateGameModel = CreateGameModel;
            })(Game = Models.Game || (Models.Game = {}));
        })(Models = Web.Models || (Web.Models = {}));
    })(Web = Belot.Web || (Belot.Web = {}));
})(Belot || (Belot = {}));
