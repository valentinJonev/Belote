/// <reference path="../_all.ts" />
var Belot;
(function (Belot) {
    var Web;
    (function (Web) {
        var Configurations;
        (function (Configurations) {
            'use strict';
            function confugreInterceptoprs($httpProvider) {
                $httpProvider.interceptors.push(Web.Services.AuthInterceptorService.Factory);
                $httpProvider.interceptors.push(Web.Services.ErrorInterceptorService.Factory);
            }
            Configurations.confugreInterceptoprs = confugreInterceptoprs;
        })(Configurations = Web.Configurations || (Web.Configurations = {}));
    })(Web = Belot.Web || (Belot.Web = {}));
})(Belot || (Belot = {}));
