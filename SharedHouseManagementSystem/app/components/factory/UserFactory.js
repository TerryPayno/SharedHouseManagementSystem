(function () {
    'use strict';

    angular
        .module('baseApp')
        .factory('UserFactory', UserFactory);

    UserFactory.$inject = ['$http'];
    function UserFactory($http) {

        UserFactory.GetHouseMates = function (User) {
            return $http.post('api/Users/GetHouseMates', User);
        }




        return UserFactory;
    }
})();