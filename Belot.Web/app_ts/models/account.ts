/// <reference path="../_all.ts" />

module Belot.Web.Models.Account {
    'use strict';

    export class LoginData {
        userName: string;
        password: string;
        rememberMe: string;
    }

    export class UserCreateModel {
        username: string;
        password: string;
    }

    export class LoginValidation {
        usernameMinLength: number;
        usernameMaxLength: number;
        passwordMinLength: number;
        passwordMaxLength: number;
    }

    export class Authentication {
        isAuth: boolean;
        userName: string;
        useRefreshTokens: boolean;
    }

    export class AuthorizedData {
        access_token: string;
        user_id: string;
        user_name: string;
        locale_id: number;
        locale_urls: string;
    }

    export class UserListModel {
        Id: string;
        Name: string;
    }

    export class UserGameModel {
        id: string;
        name: string;
    }
}