/// <reference path="../_all.ts" />

module Belot.Web.Services {
    'use strict';

    export class AuthInterceptorService implements angular.IHttpInterceptor {
        static $inject = ['$q', '$rootScope', '$injector', 'localStorageService', 'belotWebPaths'];

        private static TOKEN_HEADERS: angular.IHttpRequestConfigHeaders = { 'Content-Type': 'application/x-www-form-urlencoded' };

        public authentication: Models.Account.Authentication;
        public authorizationData: IAuthorizationData;

        public static Factory($q: angular.IQService, $rootScope: IRootScope, $injector: angular.auto.IInjectorService, localStorageService: angular.local.storage.ILocalStorageService, belotWebPaths: Constants.BelotWebPaths): AuthInterceptorService {
            return new AuthInterceptorService($q, $rootScope, $injector, localStorageService, belotWebPaths);
        }

        constructor(
            private $q: angular.IQService,
            private $rootScope: IRootScope,
            private $injector: angular.auto.IInjectorService,
            private localStorageService: angular.local.storage.ILocalStorageService,
            private belotWebPaths: Constants.BelotWebPaths) {
        }

        public request = (config: angular.IRequestConfig) => {
            config.headers = config.headers || {};

            var authData = this.getAuthService().authorizationData.getData();
            if (authData) {
                config.headers['Authorization'] = 'Bearer ' + authData.access_token;
            }

            return config;
        }

        public responseError = (rejection: angular.IHttpPromiseCallbackArg<Models.Error.AuthError>): angular.IPromise<Models.Account.AuthorizedData> => {
            if (rejection.status === 401 || this.$rootScope.controller.hasRemoteTokenRequestFailed(rejection)) {
                this.redirectToLogin();
            }

            return this.$q.reject(rejection);
        }

        private retryRequest(config: angular.IRequestConfig, deferred: angular.IDeferred<Models.Account.AuthorizedData>) {
            function successCallback(response) {
                deferred.resolve(response);
            }

            function errorCallback(response) {
                deferred.reject(response);
            }

            this.get$http()(config).then(successCallback, errorCallback);
        }

        private redirectToLogin() {
            this.get$state().go(this.belotWebPaths.accountLogin.state);
        }

        private get$http(): angular.IHttpService {
            return this.$injector.get<angular.IHttpService>('$http');
        }

        private getAuthService(): IAuthService {
            return this.$injector.get<IAuthService>('authService');
        }

        private get$state(): angular.ui.IStateService {
            return this.$injector.get<angular.ui.IStateService>('$state');
        }

    }
}