/// <reference path="../_all.ts" />
var Belot;
(function (Belot) {
    var Web;
    (function (Web) {
        var Controllers;
        (function (Controllers) {
            'use strict';
            var IndexController = (function () {
                function IndexController($scope, $state, authService, belotWebPaths) {
                    this.$scope = $scope;
                    this.$state = $state;
                    this.authService = authService;
                    this.belotWebPaths = belotWebPaths;
                    $scope.viewModel = this;
                    this.showLogout = this.authService.authentication.isAuth;
                    this.authentication = authService.authentication;
                }
                IndexController.prototype.redirectToLogin = function () {
                    this.authService.logOut();
                    this.$state.go(this.belotWebPaths.accountLogin.state);
                };
                IndexController.prototype.logOut = function () {
                    this.authService.logOut();
                };
                IndexController.$inject = ['$scope', '$state', 'authService', 'belotWebPaths'];
                return IndexController;
            })();
            Controllers.IndexController = IndexController;
        })(Controllers = Web.Controllers || (Web.Controllers = {}));
    })(Web = Belot.Web || (Belot.Web = {}));
})(Belot || (Belot = {}));
