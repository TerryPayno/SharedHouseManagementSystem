(function () {
    'use strict';

    angular
        .module('baseApp')
        .factory('LoginFactory', LoginFactory);

    LoginFactory.$inject = ['$http'];
    function LoginFactory($http) {

        LoginFactory.Login = function (Credentials) {
            return $http.post('api/Login/Login', Credentials);
        }

        LoginFactory.CreateNewAccount = function (User) {
            return $http.post('api/Login/CreateNewAccount', User);
        }
        return LoginFactory;
    }
})();