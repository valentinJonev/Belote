/// <reference path="../_all.ts" />

module Belot.Web.Controllers {
    'use strict';

    export interface IHomeScope extends angular.IScope {
        controller: IHomeController;
    }

    export interface IHomeController {
        belotWebPaths: Constants.BelotWebPaths;
        users: Models.Account.UserListModel[];
        hasInvitedSomeone: boolean;
    }

    export class HomeController implements IHomeController {
        static $inject = ['$rootScope', '$scope', '$http', '$state', 'belotWebPaths', 'belotServiceUrls', 'belotViewPaths', 'Hub', '$uibModal', 'hubService', 'authService'];

        private usersHub: ngSignalr.Hub;
        private currentLocaleId: number;

        public hasInvitedSomeone: boolean = false;
        public users: Models.Account.UserListModel[];

        constructor(private $rootScope: IRootScope, private $scope: IHomeScope,
            private $http: angular.IHttpService, private $state: angular.ui.IStateService,
            public belotWebPaths: Constants.BelotWebPaths, private belotServiceUrls: Constants.BelotServiceUrls, private belotViewPaths: Constants.BelotViewPaths,
            private Hub: ngSignalr.HubFactory, private $uibModal: angular.ui.bootstrap.IModalService,
            private hubService: Services.HubService, private authService: Services.IAuthService) {
            $scope.controller = this;

            //this.currentLocaleId = this.authService.authorizationData.getData().locale_id;
            //this.createUsersHub();
        }

        /*
        private createUsersHub(): void {
            this.usersHub = this.hubService.startHub("UsersListHub", {
                rootPath: this.belotServiceUrls.authenticationServiceUrl + "/signalr",
                logging: false,
                listeners: {
                    'setUsersList': this.setUsersList,
                    'handleInvitation': this.handleInvitation,
                    'handleRejection': this.handleRejection,
                    'joinRoom': this.joinRoom
                },
                methods: ['InvitePlayer', 'AcceptInvitation', 'RejectInvitation']
            });

            this.$scope.$on('$stateChangeStart', () => {
                this.usersHub.disconnect();
            });
        }
        
        */
        private setUsersList = (users: Models.Account.UserListModel[]) => {
            var currentUserName: string = this.authService.authorizationData.getData().user_name;
            for (var i in users) {
                if (users[i].Name == currentUserName) {
                    users[i].Id = null;
                }
            }

            this.users = users;
            this.$scope.$apply();
        }
        // TODO: Move invitation to room controller
        /*private invite(userId: string) {
            this.hasInvitedSomeone = true;
            this.createRoom(userId)
                .then((result: angular.IHttpPromiseCallbackArg<number>) => {
                    var roomId = result.data;
                    this.usersHub.invoke('InvitePlayer', userId, roomId, this.currentLocaleId);
                });
        }
        */

        public createRoom(userId: string) {
            var url: string = this.getUrlFromCsList(this.authService.authorizationData.getData().locale_urls);
            this.$http.post<number>(url + "/rooms", userId)
                .then((result: angular.IHttpPromiseCallbackArg<number>) => {
                    var roomId = result.data;
                    this.$state.go(this.belotWebPaths.room.state, roomId);
                });
        }

        /*
        private handleInvitation = (firstPlayer: Models.Account.UserListModel, roomId: string, firstLocaleId: number) => {
            var modalInstance = this.$uibModal.open({
                animation: true,
                templateUrl: this.belotViewPaths.invitationConfirm,
                controller: 'invitationConfirmController',
                size: 'md',
                backdrop: 'static',
                keyboard: false,
                resolve: {
                    name: function () {
                        return firstPlayer.Name
                    }
                }
            });

            modalInstance.result.then(() => {
                this.usersHub.invoke('AcceptInvitation', firstPlayer, roomId, firstLocaleId, this.currentLocaleId);
            }, () => {
                this.usersHub.invoke('RejectInvitation', firstPlayer);
            });
        }

        private handleRejection = (secondPlayer: Models.Account.UserListModel) => {
            this.$rootScope.controller.errorMessage("Поканата към " + secondPlayer.Name + " беше отказана.", 10000);
        }

        private joinRoom = (roomId: number) => {
            this.$state.go(this.belotWebPaths.room.state, roomId)
        }

        */

        private getUrlFromCsList(csUrls: string): string {
            var urls: string[] = csUrls.split(',');
            var randomIdx: number = this.getRandomIntBetween(0, urls.length - 1);

            return urls[randomIdx];
        }

        private getRandomIntBetween(min: number, max: number): number {
            var randValue: string = (Math.random() * (max - min + 1)) + "";
            return parseInt(randValue, 10) + min;
        }
    }
}