/// <reference path="../_all.ts" />
var Belot;
(function (Belot) {
    var Web;
    (function (Web) {
        var Controllers;
        (function (Controllers) {
            'use strict';
            var RoomController = (function () {
                function RoomController() {
                }
                RoomController.prototype.startGame = function () {
                };
                RoomController.$inject = ['$scope', '$state', 'authService', 'belotWebPaths'];
                return RoomController;
            })();
            Controllers.RoomController = RoomController;
        })(Controllers = Web.Controllers || (Web.Controllers = {}));
    })(Web = Belot.Web || (Belot.Web = {}));
})(Belot || (Belot = {}));
