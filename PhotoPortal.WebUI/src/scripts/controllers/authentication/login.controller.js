'use strict';

class LoginController {
  constructor(AuthenticationService) {
    this.AuthenticationService = AuthenticationService;
  }

  login() {
    var loginModel = {
      login: this.userEmail,
      password: this.userPassword
    };

    console.log('login action');
    this.AuthenticationService.login(loginModel);
  }

};

LoginController.$inject = ['AuthenticationService'];

angular.module('PhotoAlbum')
  .controller('LoginController', LoginController);

export { LoginController };
