'use strict';

class AuthenticationService {

  constructor ($http){
    this.$http = $http;
  }

  login(loginModel) {
    var data = {};

    if (loginModel) {
      data.Login = loginModel.login;
      data.Password = loginModel.password;
    }

    return this.$http
      .post('/api/account/login', data)
      .then(function(result) {
          console.log(result.data);
          return result.data;
      });
  };

  signout() {
    return this.$http
      .post('/api/account/signout')
      .then(function(result) {
          console.log(result.data);
          return result.data;
      });
  };

  register(registerModel) {
    var data = {};

    if (registerModel) {
      data.Name = registerModel.name;
      data.Email = registerModel.email;
      data.Password = registerModel.password;
      data.PasswordConfirm = registerModel.passwordConfirm;
    }

    return this.$http
      .post('/api/account/register', data)
      .then(function(result) {
          console.log(result.data);
          return result.data;
      });
  };
};

AuthenticationService.$inject = ['$http'];

angular.module('DataModule')
  .service('AuthenticationService', AuthenticationService);

export {AuthenticationService};
