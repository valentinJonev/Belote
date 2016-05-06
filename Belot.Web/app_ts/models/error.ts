module Belot.Web.Models.Error {
    'use strict';

    export class BaseApiError {
        message: string;
        errors: string[];
    }

    export class BadRequestApiError extends BaseApiError {
        model_errors: { [propertyName: string]: BadRequest; };
    }

    export class AuthError {
        error: string;
    }

    class BadRequest {
        errors: string[];
        exceptions: string[];
    }
}