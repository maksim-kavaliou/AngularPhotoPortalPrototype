'use strict';

import {LoginController} from '../../controllers/authentication/login.controller';

var LoginComponent =  {
  controller: LoginController,
  templateUrl: 'src/view/components/authentication/login.html',
  bindings: {
    userEmail: '=',
    userPassword: '='
  }
};

angular.module('PhotoAlbum')
.component('login', LoginComponent);

export { LoginComponent };
