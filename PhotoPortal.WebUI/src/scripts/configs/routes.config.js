'use scrict';

class RoutesConfig {
  constructor ($stateProvider, $urlRouterProvider) {
    $stateProvider
      .state('home', {
        url: '/',
        templateUrl: 'src/view/routes/home.html'
      })
      .state('userInfo', {
        url: '/user/{userId}',
        component: 'userData',
        resolve: {
          userInfo :  ['$stateParams', 'UserDataService', function ($stateParams, UserDataService) {
            return UserDataService.getUserById($stateParams.userId);
          }]
        }
      });

      $urlRouterProvider.otherwise('/');
  }

};

RoutesConfig.$inject =  ['$stateProvider', '$urlRouterProvider'] ;

angular.module('PhotoAlbum')
.config(RoutesConfig);

export { RoutesConfig };
