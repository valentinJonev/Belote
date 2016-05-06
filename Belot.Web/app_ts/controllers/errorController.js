/// <reference path="../_all.ts" />
var Belot;
(function (Belot) {
    var Web;
    (function (Web) {
        var Controllers;
        (function (Controllers) {
            'use strict';
            var ErrorController = (function () {
                function ErrorController($scope, $uibModalInstance, message, time, errorList) {
                    var _this = this;
                    this.$uibModalInstance = $uibModalInstance;
                    this.cancel = function () {
                        _this.$uibModalInstance.dismiss('cancel');
                    };
                    $scope.controller = this;
                    this.scheduleCancel(time);
                    this.model = new Web.Models.Misc.ErrorModel(message, errorList);
                }
                ErrorController.prototype.scheduleCancel = function (time) {
                    setTimeout(this.cancel, time);
                };
                ErrorController.$inject = ['$scope', '$uibModalInstance', 'message', 'time', 'errorList'];
                return ErrorController;
            })();
            Controllers.ErrorController = ErrorController;
        })(Controllers = Web.Controllers || (Web.Controllers = {}));
    })(Web = Belot.Web || (Belot.Web = {}));
})(Belot || (Belot = {}));
