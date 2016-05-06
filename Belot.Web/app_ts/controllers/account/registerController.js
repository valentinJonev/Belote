/// <reference path="../../_all.ts" />
var Belot;
(function (Belot) {
    var Web;
    (function (Web) {
        var Controllers;
        (function (Controllers) {
            var Account;
            (function (Account) {
                'use strict';
                var RegisterController = (function () {
                    function RegisterController($scope, $state, authService, belotWebPaths) {
                        var _this = this;
                        this.$scope = $scope;
                        this.$state = $state;
                        this.authService = authService;
                        this.belotWebPaths = belotWebPaths;
                        this.onRegisterSucccess = function (response) {
                            _this.$state.go(_this.belotWebPaths.accountLogin.state);
                        };
                        this.onRegisterFail = function (response) {
                            if (response.data) {
                                _this.errorMessage = response.data.message;
                            }
                            _this.model.password = '';
                            _this.repeatPassword = '';
                        };
                        $scope.controller = this;
                        this.errorMessage = "";
                        this.model = {
                            username: "",
                            password: ""
                        };
                    }
                    RegisterController.prototype.register = function () {
                        this.errorMessage = "";
                        if (this.$scope.registerForm.$valid) {
                            this.authService.register(this.model).then(this.onRegisterSucccess, this.onRegisterFail);
                        }
                        else {
                            this.$scope.registerForm.$submitted = true;
                        }
                    };
                    RegisterController.$inject = ['$scope', '$state', 'authService', 'belotWebPaths'];
                    return RegisterController;
                })();
                Account.RegisterController = RegisterController;
            })(Account = Controllers.Account || (Controllers.Account = {}));
        })(Controllers = Web.Controllers || (Web.Controllers = {}));
    })(Web = Belot.Web || (Belot.Web = {}));
})(Belot || (Belot = {}));
