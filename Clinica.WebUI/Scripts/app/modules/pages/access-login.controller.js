/**=========================================================
 * Module: access-login.js
 * Demo for login api
 =========================================================*/

(function() {
    'use strict';

    angular
        .module('app.pages')
        .controller('LoginFormController', LoginFormController);

    LoginFormController.$inject = ['$rootScope', '$http', '$state'];
    function LoginFormController($rootScope, $http, $state) {
        var vm = this;

        activate();

        ////////////////

        function activate() {
          // bind here all data from the form
          vm.account = {};
          // place the message if something goes wrong
          vm.authMsg = '';

          vm.login = function() {
            vm.authMsg = '';
            var apiUrl = 'http://localhost:2100/';
            if(vm.loginForm.$valid) {
                var logueo = { correo: vm.account.email, contrasena: vm.account.password };
              $http
                .post(apiUrl + 'api/Login/Login', logueo)
                .then(function(response) {
                  // assumes if ok, response is an object with some data, if not, a string with error
                    // customize according to your api
                    $rootScope.usuario = response.data;
                    localStorage.setItem('currentUser', JSON.stringify(response.data));
                  if (response.data == null) {
                    vm.authMsg = 'Usuario o contraseña invalidos!';
                  } else {                     
                      $state.go('app.gestioncitas');
                  }
                }, function() {
                  vm.authMsg = 'Server Request Error';
                });
            }
            else {
              // set as dirty if the user click directly to login so we show the validation messages
              /*jshint -W106*/
              vm.loginForm.account_email.$dirty = true;
              vm.loginForm.account_password.$dirty = true;
            }
          };
        }
    }
})();
