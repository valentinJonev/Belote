/// <reference path="../_all.ts" />

module Belot.Web.Controllers {
    'use strict';

    export interface IIndexScope extends angular.IScope {
        viewModel: IIndexController;
    }

    export interface IIndexController {
        authentication: Models.Account.Authentication;
        showLogout: boolean;

        logOut(): void;
    }

    export class IndexController implements IIndexController {
        static $inject = ['$scope', '$state', 'authService', 'belotWebPaths'];

        public authentication: Models.Account.Authentication;
        public showLogout: boolean;

        constructor(private $scope: IIndexScope, private $state: angular.ui.IStateService, private authService: Services.IAuthService, private belotWebPaths: Constants.BelotWebPaths) {
            $scope.viewModel = this;
            this.showLogout = this.authService.authentication.isAuth;

            this.authentication = authService.authentication;
        }

        private redirectToLogin() {
            this.authService.logOut();
            this.$state.go(this.belotWebPaths.accountLogin.state);
        }

        logOut() {
            this.authService.logOut();
        }
    }
}