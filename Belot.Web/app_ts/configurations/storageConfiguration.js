/// <reference path="../_all.ts" />
var Belot;
(function (Belot) {
    var Web;
    (function (Web) {
        var Configurations;
        (function (Configurations) {
            'use strict';
            function configureLocalStorage(localStorageServiceProvider) {
                localStorageServiceProvider
                    .setPrefix('belot-web')
                    .setStorageType('localStorage');
            }
            Configurations.configureLocalStorage = configureLocalStorage;
        })(Configurations = Web.Configurations || (Web.Configurations = {}));
    })(Web = Belot.Web || (Belot.Web = {}));
})(Belot || (Belot = {}));
