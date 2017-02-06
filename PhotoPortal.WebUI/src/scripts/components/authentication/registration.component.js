'use strict';

var RegistrationComponent =  {
    templateUrl: 'src/view/components/authentication/registration.html',
    bindings: {
      userName: '=',
      userEmail: '=',
      userPassword: '=',
      userPasswordConfirm: '='
  }
};

angular.module('PhotoAlbum')
.component('registration', RegistrationComponent);

export { RegistrationComponent };
