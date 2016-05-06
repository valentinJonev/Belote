/// <reference path="../_all.ts" />

module Belot.Web.Services {
    'use strict';

    export interface IErrorInterceptorService {
        responseError(errorResponse: angular.IHttpPromiseCallbackArg<Models.Error.BaseApiError>);
    }

    export class ErrorInterceptorService implements IErrorInterceptorService {
        static $inject = ['$q', '$rootScope'];

        public static Factory($q: angular.IQService, $rootScope: IRootScope): ErrorInterceptorService {
            return new ErrorInterceptorService($q, $rootScope);
        }

        constructor(private $q: angular.IQService, private $rootScope: IRootScope) {
        }

        public responseError = (errorResponse: angular.IHttpPromiseCallbackArg<Models.Error.BaseApiError>) => {
            switch (errorResponse.status) {
                case 401:
                    break;
                case 400:
                    if (!this.$rootScope.controller.hasRemoteTokenRequestFailed(errorResponse)
                        && !this.$rootScope.controller.isPasswordSending(errorResponse)) {

                        this.handleBadRequest(errorResponse.data);
                    }
                    break;
                case 409:
                    if (errorResponse.data) {
                        var message: string = errorResponse.data.message;
                        var globalErrors: string[] = this.getGlobalErrors(errorResponse.data);

                        this.showMessage(message, 12000, globalErrors);
                        break;
                    }
                case 403:
                case 500:
                    if (errorResponse.data) {
                        var globalErrors: string[] = this.getGlobalErrors(errorResponse.data);

                        this.showMessage(errorResponse.data.message, 6000);
                        break;
                    }
                default: {
                    if (errorResponse.status > 0 && errorResponse.data) {
                        var globalErrors: string[] = this.getGlobalErrors(errorResponse.data);

                        this.showMessage('Код ' + errorResponse.status + ': ' + errorResponse.data.message, 6000, globalErrors);
                    }
                    else {
                        this.showMessage(JSON.stringify(errorResponse), 6000);
                    };
                }
            };

            return this.$q.reject(errorResponse);
        }

        private handleBadRequest(badRequestResponse: Models.Error.BaseApiError) {
            var message = this.getMessage(badRequestResponse);
            var globalErrors: string[];

            var badReq: Models.Error.BadRequestApiError = badRequestResponse as Models.Error.BadRequestApiError;
            if (badReq.model_errors != null) {
                globalErrors = this.getModelErrors(badReq);
            }
            else {
                globalErrors = this.getGlobalErrors(badReq);
            }

            this.showMessage(message, 6000, globalErrors);
        }

        private showMessage(content: string, time: number, errorList: string[] = null) {
            this.$rootScope.controller.errorMessage(content, time, errorList);
        }

        private getMessage(badRequestResponse: Models.Error.BaseApiError) {
            if (badRequestResponse.message) {
                return badRequestResponse.message;
            }
            else {
                return undefined;
            }
        }

        private getGlobalErrors(errorResponse: Models.Error.BaseApiError) {
            return errorResponse.errors;
        }

        private getModelErrors(badRequestResponse: Models.Error.BadRequestApiError) {
            if (badRequestResponse.model_errors && badRequestResponse.model_errors[""]) {
                return badRequestResponse.model_errors[""].errors;
            }
            else {
                return [];
            }
        }
    }
}