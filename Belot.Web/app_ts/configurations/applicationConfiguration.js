/// <reference path="../_all.ts" />
var Belot;
(function (Belot) {
    var Web;
    (function (Web) {
        var Configurations;
        (function (Configurations) {
            'use strict';
            //TODO: find interface
            function configureLoadingBar(cfpLoadingBarProvider) {
                cfpLoadingBarProvider.includeSpinner = false;
            }
            Configurations.configureLoadingBar = configureLoadingBar;
        })(Configurations = Web.Configurations || (Web.Configurations = {}));
    })(Web = Belot.Web || (Belot.Web = {}));
})(Belot || (Belot = {}));
