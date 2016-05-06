/// <reference path="../_all.ts" />

module Belot.Web.Configurations {
    'use strict';

    export function confugreInterceptoprs($httpProvider: angular.IHttpProvider) {
        $httpProvider.interceptors.push(Services.AuthInterceptorService.Factory);
        $httpProvider.interceptors.push(Services.ErrorInterceptorService.Factory);
    }
}