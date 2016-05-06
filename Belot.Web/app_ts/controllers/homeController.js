/// <reference path="../_all.ts" />
var Belot;
(function (Belot) {
    var Web;
    (function (Web) {
        var Controllers;
        (function (Controllers) {
            'use strict';
            var HomeController = (function () {
                function HomeController($rootScope, $scope, $http, $state, belotWebPaths, belotServiceUrls, belotViewPaths, Hub, $uibModal, hubService, authService) {
                    var _this = this;
                    this.$rootScope = $rootScope;
                    this.$scope = $scope;
                    this.$http = $http;
                    this.$state = $state;
                    this.belotWebPaths = belotWebPaths;
                    this.belotServiceUrls = belotServiceUrls;
                    this.belotViewPaths = belotViewPaths;
                    this.Hub = Hub;
                    this.$uibModal = $uibModal;
                    this.hubService = hubService;
                    this.authService = authService;
                    this.hasInvitedSomeone = false;
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
                    this.setUsersList = function (users) {
                        var currentUserName = _this.authService.authorizationData.getData().user_name;
                        for (var i in users) {
                            if (users[i].Name == currentUserName) {
                                users[i].Id = null;
                            }
                        }
                        _this.users = users;
                        _this.$scope.$apply();
                    };
                    $scope.controller = this;
                    //this.currentLocaleId = this.authService.authorizationData.getData().locale_id;
                    //this.createUsersHub();
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
                HomeController.prototype.createRoom = function (userId) {
                    var _this = this;
                    var url = this.getUrlFromCsList(this.authService.authorizationData.getData().locale_urls);
                    this.$http.post(url + "/rooms", userId)
                        .then(function (result) {
                        var roomId = result.data;
                        _this.$state.go(_this.belotWebPaths.room.state, roomId);
                    });
                };
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
                HomeController.prototype.getUrlFromCsList = function (csUrls) {
                    var urls = csUrls.split(',');
                    var randomIdx = this.getRandomIntBetween(0, urls.length - 1);
                    return urls[randomIdx];
                };
                HomeController.prototype.getRandomIntBetween = function (min, max) {
                    var randValue = (Math.random() * (max - min + 1)) + "";
                    return parseInt(randValue, 10) + min;
                };
                HomeController.$inject = ['$rootScope', '$scope', '$http', '$state', 'belotWebPaths', 'belotServiceUrls', 'belotViewPaths', 'Hub', '$uibModal', 'hubService', 'authService'];
                return HomeController;
            })();
            Controllers.HomeController = HomeController;
        })(Controllers = Web.Controllers || (Web.Controllers = {}));
    })(Web = Belot.Web || (Belot.Web = {}));
})(Belot || (Belot = {}));
