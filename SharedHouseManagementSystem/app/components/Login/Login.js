﻿(function () {

    'use strict';

    angular
        .module('baseApp')
        .controller('LoginCtrl', LoginCtrl);

    LoginCtrl.inject = ['LoginFactory', 'LoginService'];
    function LoginCtrl(LoginFactory, LoginService) {
        var vm = this;
        vm.Login = function () {
            alert(vm.username + " " + vm.password);
            var Credentails = {
                Username: vm.username,
                Password: vm.password
                
            };
            LoginFactory.Login(Credentails).then(function (resp) {
                alert(resp.data);
                LoginService.setCachedUser(resp.data, vm.username);
                localStorage.setItem("HouseID", resp.data.HouseID);
            });
        }
        vm.AddHouse = function () {
            LoginFactory.AddNewHouse(vm.PostCode, vm.Street, vm.HouseNum).then(function (resp) {
                alert(resp.data);
            });
        }
        vm.CreateAccount = function () {
            var User = {
                Email: vm.username,
                Password: vm.password,
                FirstName: vm.firstName,
                LastName:vm.lastName,
                HouseID: vm.HouseID
            }
            LoginFactory.CreateNewAccount(User).then(function (resp) {
                alert(resp.data);
            });
        }
    }
})();