/// <reference path="../_all.ts" />
var Belot;
(function (Belot) {
    var Web;
    (function (Web) {
        var Services;
        (function (Services) {
            'use strict';
            var ErrorInterceptorService = (function () {
                function ErrorInterceptorService($q, $rootScope) {
                    var _this = this;
                    this.$q = $q;
                    this.$rootScope = $rootScope;
                    this.responseError = function (errorResponse) {
                        switch (errorResponse.status) {
                            case 401:
                                break;
                            case 400:
                                if (!_this.$rootScope.controller.hasRemoteTokenRequestFailed(errorResponse)
                                    && !_this.$rootScope.controller.isPasswordSending(errorResponse)) {
                                    _this.handleBadRequest(errorResponse.data);
                                }
                                break;
                            case 409:
                                if (errorResponse.data) {
                                    var message = errorResponse.data.message;
                                    var globalErrors = _this.getGlobalErrors(errorResponse.data);
                                    _this.showMessage(message, 12000, globalErrors);
                                    break;
                                }
                            case 403:
                            case 500:
                                if (errorResponse.data) {
                                    var globalErrors = _this.getGlobalErrors(errorResponse.data);
                                    _this.showMessage(errorResponse.data.message, 6000);
                                    break;
                                }
                            default: {
                                if (errorResponse.status > 0 && errorResponse.data) {
                                    var globalErrors = _this.getGlobalErrors(errorResponse.data);
                                    _this.showMessage('Код ' + errorResponse.status + ': ' + errorResponse.data.message, 6000, globalErrors);
                                }
                                else {
                                    _this.showMessage(JSON.stringify(errorResponse), 6000);
                                }
                                ;
                            }
                        }
                        ;
                        return _this.$q.reject(errorResponse);
                    };
                }
                ErrorInterceptorService.Factory = function ($q, $rootScope) {
                    return new ErrorInterceptorService($q, $rootScope);
                };
                ErrorInterceptorService.prototype.handleBadRequest = function (badRequestResponse) {
                    var message = this.getMessage(badRequestResponse);
                    var globalErrors;
                    var badReq = badRequestResponse;
                    if (badReq.model_errors != null) {
                        globalErrors = this.getModelErrors(badReq);
                    }
                    else {
                        globalErrors = this.getGlobalErrors(badReq);
                    }
                    this.showMessage(message, 6000, globalErrors);
                };
                ErrorInterceptorService.prototype.showMessage = function (content, time, errorList) {
                    if (errorList === void 0) { errorList = null; }
                    this.$rootScope.controller.errorMessage(content, time, errorList);
                };
                ErrorInterceptorService.prototype.getMessage = function (badRequestResponse) {
                    if (badRequestResponse.message) {
                        return badRequestResponse.message;
                    }
                    else {
                        return undefined;
                    }
                };
                ErrorInterceptorService.prototype.getGlobalErrors = function (errorResponse) {
                    return errorResponse.errors;
                };
                ErrorInterceptorService.prototype.getModelErrors = function (badRequestResponse) {
                    if (badRequestResponse.model_errors && badRequestResponse.model_errors[""]) {
                        return badRequestResponse.model_errors[""].errors;
                    }
                    else {
                        return [];
                    }
                };
                ErrorInterceptorService.$inject = ['$q', '$rootScope'];
                return ErrorInterceptorService;
            })();
            Services.ErrorInterceptorService = ErrorInterceptorService;
        })(Services = Web.Services || (Web.Services = {}));
    })(Web = Belot.Web || (Belot.Web = {}));
})(Belot || (Belot = {}));
