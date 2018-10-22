(function () {

    'use strict';

    angular
        .module('baseApp')
        .directive('toolbar', toolbar);



    function toolbar() {
        return {
            templateUrl: 'app/components/toolbar/toolbar.html',
            controller: toolbarCtrl,
            controllerAs: 'vm'
        }
    }

    toolbarCtrl.$inject = ['$scope', '$mdSidenav', 'LoginService'];

    function toolbarCtrl($scope, $mdSidenav, LoginService) {
        var vm = this;
        vm.toggleLeft = buildToggler('left');
        vm.LoginView = true;
        vm.LogOutView = false;
        if (LoginService.getUser() != null) {
            vm.LoginView = false;
            vm.LogOutView = true;
        }
        function buildToggler(componentId) {
            return function () {
                $mdSidenav(componentId).toggle();
            };
        }
        
        vm.Logout = function () {
            if (localStorage.getItem('UserID') != null) {
                vm.LoginView = true;
                vm.LogOutView = false;
                localStorage.clear();
            }

        }
        

    }

})();