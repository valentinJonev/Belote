/// <reference path="../_all.ts" />
var Belot;
(function (Belot) {
    var Web;
    (function (Web) {
        var Constants;
        (function (Constants) {
            'use strict';
            var UrlState = (function () {
                function UrlState() {
                }
                return UrlState;
            })();
            Constants.UrlState = UrlState;
            var BelotWebPaths = (function () {
                function BelotWebPaths() {
                    this.accountLogin = { url: '/login', state: 'login' };
                    this.accountRegister = { url: '/register', state: 'register' };
                    this.home = { url: '/home', state: 'home' };
                    this.game = { url: '/game/{game_id:int}/{service_url}', state: 'game' };
                    this.room = { url: '/room/{room_id:int}/{service_url}', state: 'room' };
                }
                return BelotWebPaths;
            })();
            Constants.BelotWebPaths = BelotWebPaths;
            var BelotViewPaths = (function () {
                function BelotViewPaths() {
                    this.shared = { modal: './views/shared/modalTemplate.html' };
                    this.accountLogin = './views/account/login.html';
                    this.accountRegister = './views/account/register.html';
                    this.home = './views/home.html';
                    this.error = './views/error.html';
                    this.invitationConfirm = './views/invitationConfirm.html';
                    this.gameCreate = './views/gameCreate.html';
                    this.game = './views/game.html';
                    this.room = './views/room.html';
                }
                return BelotViewPaths;
            })();
            Constants.BelotViewPaths = BelotViewPaths;
            var SharedViewPaths = (function () {
                function SharedViewPaths() {
                }
                return SharedViewPaths;
            })();
            Constants.SharedViewPaths = SharedViewPaths;
        })(Constants = Web.Constants || (Web.Constants = {}));
    })(Web = Belot.Web || (Belot.Web = {}));
})(Belot || (Belot = {}));
