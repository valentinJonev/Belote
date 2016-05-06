/// <reference path="../_all.ts" />

module Belot.Web.Controllers {
    'use strict';

    export interface IInvitationConfirmScope extends angular.IScope {
        controller: IInvitationConfirmController;
    }

    export interface IInvitationConfirmController {
        name: string;

        cancel();
        confirm();
    }

    export class InvitationConfirmController implements IInvitationConfirmController {
        static $inject = ['$scope', '$uibModalInstance', 'name'];

        constructor($scope: IInvitationConfirmScope, private $uibModalInstance: angular.ui.bootstrap.IModalServiceInstance, public name: string) {
            $scope.controller = this;
        }

        public cancel() {
            this.$uibModalInstance.dismiss('cancel');
        }

        public confirm() {
            this.$uibModalInstance.close();
        };
    }
}