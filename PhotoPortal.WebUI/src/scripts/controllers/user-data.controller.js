'use strict';

class UserDataController {
  constructor(userInfo) {
    this.userInfo = userInfo;
  }
};

UserDataController.$inject = ['userInfo'];

angular.module('DataModule')
.controller('UserDataController', UserDataController);

export { UserDataController }
