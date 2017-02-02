'use strict';

class UserDataService {

  constructor ($http, ApiBasePath){

    this.$http = $http;
    this.ApiBasePath = ApiBasePath;
  }

  getUserById(userId) {
    var config = {};

    if (userId) {
      config.params = { id: userId };
    }

    return this.$http
      .get(this.ApiBasePath + '/user', config)
      .then(function(result) {
          return result.data;
      });
  };
};

UserDataService.$inject = ['$http', 'ApiBasePath']

angular.module('DataModule')
  .service('UserDataService', UserDataService)
  .constant('ApiBasePath', 'http://localhost:8056/api');

export {UserDataService};
