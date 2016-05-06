/// <reference path="../_all.ts" />
module Belot.Web.Directives {
    'use strict';

    export class ModalDirective {
        static $inject = ['belotViewPaths'];

        constructor(belotViewPaths: Constants.BelotViewPaths) {
            var directive: angular.IDirective = <angular.IDirective>{};

            directive.restrict = 'E';
            directive.replace = true;
            directive.transclude = true;
            directive.templateUrl = belotViewPaths.shared.modal;
            directive.link = function postLink(scope: IModalScope, element: HTMLElement, attrs: IModalAttrs) {
                scope.title = attrs.title;
            };

            return directive;
        }
    }

    export interface IModalScope extends angular.IScope {
        title: string;
    }

    export interface IModalAttrs {
        title: string;
    }
}