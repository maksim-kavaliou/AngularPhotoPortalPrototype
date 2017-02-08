'use strict';

class UserDataService {

  constructor ($http){

    this.$http = $http;
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
