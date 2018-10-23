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
        LoginFactory.ResetPasswordRequest = function (username) {
            var userInfo = {
                Username: username,
                Password: null
            }
            return $http.post('api/Login/ResetPasswordRequest', userInfo);
        }
        LoginFactory.AddNewHouse = function (PostCode, Street, HouseNum) {
            var NewHouseData = {
                PostCode: PostCode,
                Street: Street,
                HouseNum: HouseNum
            }
            return $http.post('api/Login/AddNewHouse', NewHouseData);
        }
        LoginFactory.ResetPasswordAction = function (newPass, GUID) {
            var Restobj = {
                newPassword: newPass,
                GUID: GUID
            }
            return $http.post('api/Login/ResetPasswordAction', Restobj);
        }
        return LoginFactory;
    }
})();