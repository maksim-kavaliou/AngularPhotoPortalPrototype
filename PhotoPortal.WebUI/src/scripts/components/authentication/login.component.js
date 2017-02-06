'use strict';

var LoginComponent =  {
    templateUrl: 'src/view/components/authentication/login.html',
    bindings: {
      userEmail: '=',
      userPassword: '='
  }
};

angular.module('PhotoAlbum')
.component('login', LoginComponent);

export { LoginComponent };
