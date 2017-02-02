'use strict';

var UserDataComponent =  {
    templateUrl: 'src/view/components/user-data.html',
    bindings: {
      userInfo: '<'
  }
};

angular.module('DataModule')
.component('userData', UserDataComponent);

export { UserDataComponent };
