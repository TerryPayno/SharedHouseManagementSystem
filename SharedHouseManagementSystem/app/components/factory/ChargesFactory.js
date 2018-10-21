(function () {
    'use strict';

    angular
        .module('baseApp')
        .factory('ChargesFactory', ChargesFactory);

    ChargesFactory.$inject = ['$http'];
    function ChargesFactory($http) {

        
        ChargesFactory.GetCharges = function (userData) {
            var userInfo = {
                UserID: userData
            }
            return $http.post('api/Charge/GetCharges', userInfo);
        }


        return ChargesFactory;
    }
})();