/// <reference path="../_all.ts" />

module Belot.Web.Configurations {
    'use strict';

    export function configureLocalStorage(localStorageServiceProvider: angular.local.storage.ILocalStorageServiceProvider) {
        localStorageServiceProvider
            .setPrefix('belot-web')
            .setStorageType('localStorage');
    }
}