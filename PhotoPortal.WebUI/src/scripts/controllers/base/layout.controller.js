'use strict';

class LayoutController {
  constructor(AuthenticationService) {
    this.AuthenticationService = AuthenticationService;
  }

  signout() {
    console.log('signout action');
    this.AuthenticationService.signout();
  }

};

LayoutController.$inject = ['AuthenticationService'];

angular.module('PhotoAlbum')
  .controller('LayoutController', LayoutController);

export { LayoutController };
