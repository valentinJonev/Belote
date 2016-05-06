/// <reference path="../_all.ts" />
var Belot;
(function (Belot) {
    var Web;
    (function (Web) {
        var Services;
        (function (Services) {
            'use strict';
            var AuthService = (function () {
                function AuthService($http, $q, localStorageService, belotServiceUrls, belotSettings) {
                    var _this = this;
                    this.$http = $http;
                    this.$q = $q;
                    this.localStorageService = localStorageService;
                    this.belotServiceUrls = belotServiceUrls;
                    this.belotSettings = belotSettings;
                    this.onLoginSuccess = function (response) {
                        response.user_name = _this.loginData.userName;
                        _this.authorizationData.setData(response);
                        _this.authentication.isAuth = true;
                        _this.authentication.userName = _this.loginData.userName;
                        _this.authentication.useRefreshTokens = false;
                        return response;
                    };
                    this.onLoginFail = function (response) {
                        _this.logOut();
                        return null;
                    };
                    this.authorizationData = new AuthorizationData(localStorageService);
                    this.authentication = new Web.Models.Account.Authentication();
                }
                AuthService.prototype.login = function (loginData) {
                    this.loginData = loginData;
                    var data = "grant_type=password&username=" + loginData.userName + "&password=" + loginData.password + "&client_id=" + this.belotSettings.clientId;
                    return this.$http.post(this.belotServiceUrls.authenticationServiceUrl, data, { headers: AuthService.TOKEN_HEADERS })
                        .success(this.onLoginSuccess)
                        .error(this.onLoginFail);
                };
                AuthService.prototype.register = function (user) {
                    return this.$http.post(this.belotServiceUrls.authenticationServiceUrl + "/api/users", user);
                };
                AuthService.prototype.logOut = function () {
                    this.authorizationData.removeData();
                    this.authentication.isAuth = false;
                    this.authentication.userName = "";
                    this.authentication.useRefreshTokens = false;
                };
                AuthService.prototype.fillAuthData = function () {
                    var authData = this.authorizationData.getData();
                    if (authData) {
                        this.authentication.isAuth = true;
                        this.authentication.userName = authData.user_name;
                        this.authentication.useRefreshTokens = true;
                    }
                };
                AuthService.$inject = ['$http', '$q', 'localStorageService', 'belotServiceUrls', 'belotSettings'];
                AuthService.TOKEN_HEADERS = { 'Content-Type': 'application/x-www-form-urlencoded' };
                return AuthService;
            })();
            Services.AuthService = AuthService;
            var AuthorizationData = (function () {
                function AuthorizationData(localStorageService) {
                    this.localStorageService = localStorageService;
                }
                AuthorizationData.prototype.getData = function () {
                    return this.localStorageService.get(AuthorizationData.AUTH_DATA_KEY);
                };
                AuthorizationData.prototype.setData = function (data) {
                    this.localStorageService.set(AuthorizationData.AUTH_DATA_KEY, data);
                };
                AuthorizationData.prototype.removeData = function () {
                    this.localStorageService.remove(AuthorizationData.AUTH_DATA_KEY);
                };
                AuthorizationData.AUTH_DATA_KEY = 'authorizationData';
                return AuthorizationData;
            })();
        })(Services = Web.Services || (Web.Services = {}));
    })(Web = Belot.Web || (Belot.Web = {}));
})(Belot || (Belot = {}));
