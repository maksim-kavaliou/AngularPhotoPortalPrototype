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
      .get('/api/user', config)
      .then(function(result) {
          return result.data;
      });
  };
};

UserDataService.$inject = ['$http']

angular.module('DataModule')
  .service('UserDataService', UserDataService);

export {UserDataService};
