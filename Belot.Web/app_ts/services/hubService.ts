/// <reference path="../_all.ts" />

module Belot.Web.Services {
    'use strict';

    export interface IHubService {
        startHub(hubName: string, options: ngSignalr.HubOptions): ngSignalr.Hub;
    }

    export class HubService implements IHubService {
        static $inject = ['$state', 'belotWebPaths', 'authService', 'Hub'];

        private hasConnectFailed: boolean = false;

        public hub: ngSignalr.Hub;

        constructor(private $state: angular.ui.IStateService,
            public belotWebPaths: Constants.BelotWebPaths,
            private authService: Services.AuthService,
            private Hub: ngSignalr.HubFactory) {
        }

        startHub(hubName: string, options: ngSignalr.HubOptions): ngSignalr.Hub {
            var authData: Models.Account.AuthorizedData = this.authService.authorizationData.getData();
            var accessToken: string = authData != null ? authData.access_token : null;
            if (!options.queryParams) {
                options.queryParams = {};
            }
            options.queryParams['access_token'] = "Bearer " + accessToken;

            this.hub = new this.Hub(hubName, options);
            this.createHub();

            return this.hub;
        }

        private createHub() {
            this.hub.connect();
            this.hub.connection.start()
                .done(this.onHubConnectSuccess)
                .fail(this.onHubConnectFail);
        }

        private onHubConnectSuccess = (response: JQueryPromise<any>) => {
            console.log('Now connected, connection ID=' + this.hub.connection.id);
        }

        private onHubConnectFail = (promise: any) => {
            if (promise.context.status == 401) {
                this.redirectToLogin();
            }

            console.log('Could not connect');
        }

        private redirectToLogin() {
            this.$state.go(this.belotWebPaths.accountLogin.state);
        }
    }
}