'use strict';

import {RegistrationController} from '../../controllers/authentication/registration.controller';

var RegistrationComponent =  {
  controller: RegistrationController,
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
