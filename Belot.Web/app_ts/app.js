/// <reference path="_all.ts" />
var Belot;
(function (Belot) {
    var Web;
    (function (Web) {
        'use strict';
        var Configurations = Belot.Web.Configurations;
        var Constants = Belot.Web.Constants;
        var Controllers = Belot.Web.Controllers;
        var Directives = Belot.Web.Directives;
        var Filters = Belot.Web.Filters;
        var Services = Belot.Web.Services;
        var app = angular.module('belot-web', ['ui.router', 'LocalStorageModule', 'angular-loading-bar', 'belot-web-service-url', 'ui.bootstrap', 'ng-file-model', 'SignalR'])
            .constant('belotWebPaths', new Constants.BelotWebPaths())
            .constant('belotViewPaths', new Constants.BelotViewPaths())
            .constant('belotSettings', new Constants.BelotSettings())
            .directive('modal', function (belotViewPaths) { return new Directives.ModalDirective(belotViewPaths); })
            .filter('stringFormat', Filters.stringFormat)
            .service('authService', Services.AuthService)
            .service('hubService', Services.HubService)
            .controller("errorController", Controllers.ErrorController)
            .controller("homeController", Controllers.HomeController)
            .controller("invitationConfirmController", Controllers.InvitationConfirmController)
            .controller("indexController", Controllers.IndexController)
            .controller("loginController", Controllers.Account.LoginController)
            .controller("account.registerController", Controllers.Account.RegisterController)
            .config(['cfpLoadingBarProvider', Configurations.configureLoadingBar])
            .config(['$httpProvider', Configurations.confugreInterceptoprs])
            .config(['$stateProvider', '$urlRouterProvider', '$locationProvider', 'belotWebPaths', 'belotViewPaths', 'belotServiceUrls', Configurations.configureRouting])
            .config(['localStorageServiceProvider', Configurations.configureLocalStorage])
            .run(function ($rootScope, $state, $uibModal, authService, belotServiceUrls, belotWebPaths, belotViewPaths) {
            return initialize($rootScope, $state, $uibModal, authService, belotServiceUrls, belotWebPaths, belotViewPaths);
        });
        function initialize($rootScope, $state, $uibModal, authService, belotServiceUrls, belotWebPaths, belotViewPaths) {
            $rootScope.controller = new Web.RootController($rootScope, $state, $uibModal, authService, belotServiceUrls, belotWebPaths, belotViewPaths);
        }
    })(Web = Belot.Web || (Belot.Web = {}));
})(Belot || (Belot = {}));
