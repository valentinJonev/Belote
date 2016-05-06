/// <reference path="../_all.ts" />
var Belot;
(function (Belot) {
    var Web;
    (function (Web) {
        var Configurations;
        (function (Configurations) {
            'use strict';
            function configureRouting($stateProvider, $urlRouterProvider, $locationProvider, belotWebPaths, belotViewPaths, belotServiceUrls) {
                $stateProvider.state(belotWebPaths.home.state, {
                    url: belotWebPaths.home.url,
                    controller: "homeController",
                    templateUrl: belotViewPaths.home
                });
                $stateProvider.state(belotWebPaths.game.state, {
                    url: belotWebPaths.game.url,
                    controller: "gameController",
                    templateUrl: belotViewPaths.game,
                    params: {
                        game_id: 0,
                        service_url: null
                    }
                });
                $stateProvider.state(belotWebPaths.accountLogin.state, {
                    url: belotWebPaths.accountLogin.url,
                    controller: "loginController",
                    templateUrl: belotViewPaths.accountLogin
                });
                $stateProvider.state(belotWebPaths.accountRegister.state, {
                    url: belotWebPaths.accountRegister.url,
                    controller: "account.registerController",
                    templateUrl: belotViewPaths.accountRegister
                });
                $urlRouterProvider.otherwise(belotWebPaths.home.url);
                // use the HTML5 History API
                $locationProvider.html5Mode({
                    enabled: false,
                    requireBase: true
                });
            }
            Configurations.configureRouting = configureRouting;
        })(Configurations = Web.Configurations || (Web.Configurations = {}));
    })(Web = Belot.Web || (Belot.Web = {}));
})(Belot || (Belot = {}));
