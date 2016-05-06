/// <reference path="_all.ts" />

module Belot.Web {
    'use strict';

    import Configurations = Belot.Web.Configurations;
    import Constants = Belot.Web.Constants;
    import Controllers = Belot.Web.Controllers;
    import Directives = Belot.Web.Directives;
    import Filters = Belot.Web.Filters;
    import Services = Belot.Web.Services;

    var app: angular.IModule = angular.module('belot-web',
        ['ui.router', 'LocalStorageModule', 'angular-loading-bar', 'belot-web-service-url', 'ui.bootstrap', 'ng-file-model', 'SignalR'])
        //constants
        .constant('belotWebPaths', new Constants.BelotWebPaths())
        .constant('belotViewPaths', new Constants.BelotViewPaths())
        .constant('belotSettings', new Constants.BelotSettings())
        //directives
        .directive('modal', (belotViewPaths: Constants.BelotViewPaths) => new Directives.ModalDirective(belotViewPaths))
        //filters
        .filter('stringFormat', Filters.stringFormat)
        //services
        .service('authService', Services.AuthService)
        .service('hubService', Services.HubService)
        //controllers
        .controller("errorController", Controllers.ErrorController)
        .controller("homeController", Controllers.HomeController)
        .controller("invitationConfirmController", Controllers.InvitationConfirmController)
        .controller("indexController", Controllers.IndexController)
        .controller("loginController", Controllers.Account.LoginController)
        .controller("account.registerController", Controllers.Account.RegisterController)
        //configuration
        .config(['cfpLoadingBarProvider', Configurations.configureLoadingBar])
        .config(['$httpProvider', Configurations.confugreInterceptoprs])
        .config(['$stateProvider', '$urlRouterProvider', '$locationProvider', 'belotWebPaths', 'belotViewPaths', 'belotServiceUrls', Configurations.configureRouting])
        .config(['localStorageServiceProvider', Configurations.configureLocalStorage])
        //custom initialization
        .run(($rootScope: IRootScope, $state: angular.ui.IStateService, $uibModal: angular.ui.bootstrap.IModalService,
            authService: Services.IAuthService, belotServiceUrls: Constants.BelotServiceUrls, belotWebPaths: Constants.BelotWebPaths,
            belotViewPaths: Constants.BelotViewPaths) =>
            initialize($rootScope, $state, $uibModal, authService, belotServiceUrls, belotWebPaths, belotViewPaths));

    function initialize($rootScope: IRootScope, $state: angular.ui.IStateService, $uibModal: angular.ui.bootstrap.IModalService, authService: Services.IAuthService,
        belotServiceUrls: Constants.BelotServiceUrls, belotWebPaths: Constants.BelotWebPaths, belotViewPaths: Constants.BelotViewPaths) {
        $rootScope.controller = new RootController($rootScope, $state, $uibModal, authService, belotServiceUrls, belotWebPaths, belotViewPaths);
    }
}