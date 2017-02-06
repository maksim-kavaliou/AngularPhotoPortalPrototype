'use scrict';

class RoutesConfig {
  constructor ($stateProvider, $urlRouterProvider) {
    var homeState = {
      url: '/',
      templateUrl: 'src/view/routes/home.html'
    };

    var userInfoState = {
      url: '/user/{userId}',
      component: 'userData',
      resolve: {
        userInfo :  ['$stateParams', 'UserDataService', function ($stateParams, UserDataService) {
          return UserDataService.getUserById($stateParams.userId);
        }]
      }
    }

    var loginState = {
      url: '/login',
      component: 'login'
    };

    var registrationState = {
      url: '/register',
      component: 'registration'
    };

    $stateProvider
      .state('home', homeState)
      .state('userInfo', userInfoState)
      .state('login', loginState)
      .state('registration', registrationState);

      $urlRouterProvider.otherwise('/');
  }

};

RoutesConfig.$inject =  ['$stateProvider', '$urlRouterProvider'] ;

angular.module('PhotoAlbum')
.config(RoutesConfig);

export { RoutesConfig };
