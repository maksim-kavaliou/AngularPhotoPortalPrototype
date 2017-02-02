'use scrict';

export {};

class RoutesConfig {
  constructor ($stateProvider, $urlRouterProvider) {
    $stateProvider
      .state('home', {
        url: '/',
        templateUrl: 'src/view/routes/home.html'
      })

      $urlRouterProvider.otherwise('/');
  }

};
RoutesConfig.$inject =  ['$stateProvider', '$urlRouterProvider'] ;

angular.module('PhotoAlbum')
.config(RoutesConfig);
