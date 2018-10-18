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

    toolbarCtrl.$inject = ['$scope', '$mdSidenav'];

    function toolbarCtrl($scope, $mdSidenav) {
        var vm = this;
        vm.toggleLeft = buildToggler('left');

        function buildToggler(componentId) {
            return function () {
                $mdSidenav(componentId).toggle();
            };
        }
        

    }

})();