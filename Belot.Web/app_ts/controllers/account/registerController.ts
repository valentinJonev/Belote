/// <reference path="../../_all.ts" />

module Belot.Web.Controllers.Account {
    'use strict';
    import constants = Belot.Web.Constants;
    import models = Belot.Web.Models.Account;

    export interface IRegisterScope extends angular.IScope {
        controller: IRegisterController;
        registerForm: angular.IFormController;
    }

    export interface IRegisterController {
        errorMessage: string;
        model: models.UserCreateModel;
        repeatPassword: string;

        register(): void;
    }

    export class RegisterController implements IRegisterController {
        static $inject = ['$scope', '$state', 'authService', 'belotWebPaths'];

        errorMessage: string;
        model: models.UserCreateModel;
        repeatPassword: string;

        constructor(private $scope: IRegisterScope, private $state: angular.ui.IStateService, private authService: Services.IAuthService, public belotWebPaths: constants.BelotWebPaths) {
            $scope.controller = this;

            this.errorMessage = "";

            this.model = {
                username: "",
                password: ""
            };
        }

        public register() {
            this.errorMessage = "";

            if (this.$scope.registerForm.$valid) {
                this.authService.register(this.model).then(this.onRegisterSucccess, this.onRegisterFail);
            }
            else {
                this.$scope.registerForm.$submitted = true;
            }
        }

        private onRegisterSucccess = (response: Models.Account.AuthorizedData) => {
            this.$state.go(this.belotWebPaths.accountLogin.state);
        }

        private onRegisterFail = (response: angular.IHttpPromiseCallbackArg<Models.Error.BaseApiError>) => {
            if (response.data) {
                this.errorMessage = response.data.message;
            }

            this.model.password = '';
            this.repeatPassword = '';
        }
    }
}