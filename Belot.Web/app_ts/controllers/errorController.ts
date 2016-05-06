/// <reference path="../_all.ts" />

module Belot.Web.Controllers {
    'use strict';

    export interface IErrorScope extends angular.IScope {
        controller: IErrorController;
    }

    export interface IErrorController {
        model: Belot.Web.Models.Misc.ErrorModel;
        cancel: () => void;
    }

    export class ErrorController implements IErrorController {
        static $inject = ['$scope', '$uibModalInstance', 'message', 'time', 'errorList'];

        public model: Belot.Web.Models.Misc.ErrorModel;

        constructor($scope: IErrorScope, private $uibModalInstance: angular.ui.bootstrap.IModalServiceInstance, message: string, time: number, errorList: string[]) {
            $scope.controller = this;

            this.scheduleCancel(time);
            this.model = new Models.Misc.ErrorModel(message, errorList);
        }

        public cancel = () => {
            this.$uibModalInstance.dismiss('cancel');
        }

        private scheduleCancel(time: number) {
            setTimeout(this.cancel, time);
        }
    }
}