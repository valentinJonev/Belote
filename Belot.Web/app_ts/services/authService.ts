/// <reference path="../_all.ts" />

module Belot.Web.Services {
    'use strict';

    export interface IAuthService {
        authentication: Models.Account.Authentication;
        authorizationData: IAuthorizationData;

        login(loginData: Models.Account.LoginData): angular.IPromise<Models.Account.AuthorizedData>;
        register(user: Models.Account.UserCreateModel): angular.IHttpPromise<any>;
        logOut();
        fillAuthData();
    }

    export interface IAuthorizationData {
        getData(): Models.Account.AuthorizedData;
        setData(data: Models.Account.AuthorizedData);
        removeData();
    }

    export class AuthService implements IAuthService {
        static $inject = ['$http', '$q', 'localStorageService', 'belotServiceUrls', 'belotSettings'];

        private static TOKEN_HEADERS: angular.IHttpRequestConfigHeaders = { 'Content-Type': 'application/x-www-form-urlencoded' };

        private loginData: Models.Account.LoginData;

        public authentication: Models.Account.Authentication;
        public authorizationData: IAuthorizationData;

        constructor(private $http: angular.IHttpService,
            private $q: angular.IQService,
            private localStorageService: angular.local.storage.ILocalStorageService,
            private belotServiceUrls: Constants.BelotServiceUrls,
            private belotSettings: Constants.BelotSettings) {
            this.authorizationData = new AuthorizationData(localStorageService);
            this.authentication = new Models.Account.Authentication();
        }

        public login(loginData: Models.Account.LoginData): angular.IPromise<Models.Account.AuthorizedData> {
            this.loginData = loginData;
            var data: string = "grant_type=password&username=" + loginData.userName + "&password=" + loginData.password + "&client_id=" + this.belotSettings.clientId;

            return this.$http.post(this.belotServiceUrls.authenticationServiceUrl, data, { headers: AuthService.TOKEN_HEADERS })
                .success(this.onLoginSuccess)
                .error(this.onLoginFail);
        }

        public register(user: Models.Account.UserCreateModel): angular.IHttpPromise<any> {
            return this.$http.post(this.belotServiceUrls.authenticationServiceUrl + "/api/users", user);
        }

        public logOut() {
            this.authorizationData.removeData();

            this.authentication.isAuth = false;
            this.authentication.userName = "";
            this.authentication.useRefreshTokens = false;
        }

        public fillAuthData() {
            var authData = this.authorizationData.getData();
            if (authData) {
                this.authentication.isAuth = true;
                this.authentication.userName = authData.user_name;
                this.authentication.useRefreshTokens = true;
            }
        }

        private onLoginSuccess = (response: Models.Account.AuthorizedData): Models.Account.AuthorizedData => {
            response.user_name = this.loginData.userName;
            this.authorizationData.setData(response);

            this.authentication.isAuth = true;
            this.authentication.userName = this.loginData.userName;
            this.authentication.useRefreshTokens = false;

            return response;
        }

        private onLoginFail = (response: Models.Account.AuthorizedData): void => {
            this.logOut();

            return null;
        }
    }

    class AuthorizationData implements IAuthorizationData {
        private static AUTH_DATA_KEY = 'authorizationData';

        constructor(private localStorageService: angular.local.storage.ILocalStorageService) {
        }

        public getData(): Models.Account.AuthorizedData {
            return this.localStorageService.get<Models.Account.AuthorizedData>(AuthorizationData.AUTH_DATA_KEY);
        }

        public setData(data: Models.Account.AuthorizedData) {
            this.localStorageService.set(AuthorizationData.AUTH_DATA_KEY, data);
        }
        public removeData() {
            this.localStorageService.remove(AuthorizationData.AUTH_DATA_KEY);
        }
    }
}