﻿(function () {
    'use strict';

    angular
        .module('baseApp')
        .factory('ProductFactory', ProductFactory);

    ProductFactory.$inject = ['$http'];
    function ProductFactory($http) {

        ProductFactory.CreateCharge = function (ChargeObj) {
            return $http.post('api/Product/CreateCharge', ChargeObj);
        }
        ProductFactory.GetUserBoughtProducts = function (userData) {
            var userInfo = {
                UserID: userData
            }
            return $http.post('api/Product/GetUserBoughtProducts', userInfo);
        }

        return ProductFactory;
    }
})();