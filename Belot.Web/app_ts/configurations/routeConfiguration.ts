/// <reference path="../_all.ts" />

module Belot.Web.Configurations {
    'use strict';


    export function configureRouting($stateProvider: angular.ui.IStateProvider,
        $urlRouterProvider: angular.ui.IUrlRouterProvider,
        $locationProvider: angular.ILocationProvider,
        belotWebPaths: Constants.BelotWebPaths,
        belotViewPaths: Constants.BelotWebPaths,
        belotServiceUrls: Constants.BelotWebPaths) {

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
}