'use strict';

class RegistrationController {
  constructor(AuthenticationService) {
    this.AuthenticationService = AuthenticationService;
  }

  register() {
    var registerModel = {
      name: this.userName,
      email: this.userEmail,
      password: this.userPassword,
      passwordConfirm: this.userPasswordConfirm
    };

    console.log('register action');
    this.AuthenticationService.register(registerModel);
  }

};

RegistrationController.$inject = ['AuthenticationService'];

angular.module('PhotoAlbum')
  .controller('RegistrationController', RegistrationController);

export { RegistrationController };
