(function () {
    'use strict';

    angular
        .module('baseApp')
        .factory('RotaFactory', RotaFactory);

    RotaFactory.$inject = ['$http'];
    function RotaFactory($http) {


        RotaFactory.SaveRota = function (RotaListData) {
            var RotaRows = { RotaRows: RotaListData };
            return $http.post('api/Rota/SaveRotaData', RotaRows);
        }

        RotaFactory.GetRotaData = function () {
            return $http.get('api/Rota/GetRotaData');
        }

        return RotaFactory;
    }
})();