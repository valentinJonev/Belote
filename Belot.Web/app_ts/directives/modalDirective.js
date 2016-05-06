/// <reference path="../_all.ts" />
var Belot;
(function (Belot) {
    var Web;
    (function (Web) {
        var Directives;
        (function (Directives) {
            'use strict';
            var ModalDirective = (function () {
                function ModalDirective(belotViewPaths) {
                    var directive = {};
                    directive.restrict = 'E';
                    directive.replace = true;
                    directive.transclude = true;
                    directive.templateUrl = belotViewPaths.shared.modal;
                    directive.link = function postLink(scope, element, attrs) {
                        scope.title = attrs.title;
                    };
                    return directive;
                }
                ModalDirective.$inject = ['belotViewPaths'];
                return ModalDirective;
            })();
            Directives.ModalDirective = ModalDirective;
        })(Directives = Web.Directives || (Web.Directives = {}));
    })(Web = Belot.Web || (Belot.Web = {}));
})(Belot || (Belot = {}));
