/**=========================================================
 * Module: config.js
 * App routes and resources configuration
 =========================================================*/


(function() {
    'use strict';

    angular
        .module('app.routes')
        .config(routesConfig);

    routesConfig.$inject = ['$stateProvider', '$locationProvider', '$urlRouterProvider', 'RouteHelpersProvider'];
    function routesConfig($stateProvider, $locationProvider, $urlRouterProvider, helper){

        // Set the following to true to enable the HTML5 Mode
        // You may have to set <base> tag in index and a routing configuration in your server
        $locationProvider.html5Mode(false);

        // defaults to dashboard
        $urlRouterProvider.otherwise('/login');

        //
        // Application Routes
        // -----------------------------------
        $stateProvider
          .state('app', {
              //url: '/app',
              abstract: true,
              //templateUrl: helper.basepath('App/Index'),
              resolve: helper.resolveFor('fastclick', 'modernizr', 'icons', 'screenfull', 'animo', 'sparklines', 'slimscroll', 'classyloader', 'toaster', 'whirl'),
              views: {
                  'content': {
                      template: '<div data-ui-view="" autoscroll="false" ng-class="app.viewAnimation" class="content-wrapper"></div>',
                      controller: ['$rootScope', function ($rootScope) {
                          // Uncomment this if you are using horizontal layout
                          // $rootScope.app.layout.horizontal = true;

                          // Due to load times on local server sometimes the offsidebar is displayed before go offscreen
                          // so it's hidden by default and after 1sec we show it offscreen
                          // [If removed, also the hide class must be removed from .offsidebar]
                          setTimeout(function () {
                              angular.element('.offsidebar').removeClass('hide');
                          }, 3000);

                      }]
                  }
              }

          })
         
          .state('app.gestioncitas', {
              url: '/Gestioncitas',
              title: 'Registrar Citas',
              templateUrl: helper.basepath('GestionCitas/GestionCitas'),
              controller: 'RegistroCitasController',
              controllerAs: 'gestion',
              resolve: helper.resolveFor('flot-chart', 'flot-chart-plugins', 'vector-map', 'vector-map-maps')
          })
          .state('app.pages', {
              url: '/login',
              title: 'Login',
              templateUrl: helper.basepath('Pages/Login'),
              controller: 'LoginFormController',
              controllerAs: 'login',
          })         
          .state('page.404', {
              url: '/404',
              title: 'Not Found',
              templateUrl: helper.basepath('Pages/Error404')
          })
          //
          // CUSTOM RESOLVES
          //   Add your own resolves properties
          //   following this object extend
          //   method
          // -----------------------------------
          // .state('app.someroute', {
          //   url: '/some_url',
          //   templateUrl: 'path_to_template.html',
          //   controller: 'someController',
          //   resolve: angular.extend(
          //     helper.resolveFor(), {
          //     // YOUR RESOLVES GO HERE
          //     }
          //   )
          // })
          ;

    } // routesConfig

})();

