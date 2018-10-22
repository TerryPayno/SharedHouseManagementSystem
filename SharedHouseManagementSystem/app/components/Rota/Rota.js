(function () {

    'use strict';

    angular
        .module('baseApp')
        .controller('RotaCtrl', RotaCtrl);

    RotaCtrl.inject = ['ProductFactory', 'UserFactory', 'LoginService'];
    function RotaCtrl(ProductFactory, UserFactory, LoginService) {
        var vm = this;
        var userData = LoginService.getUser();
        vm.RotaRows = [];
        vm.Editable = false;
        vm.AddNewRow = function () {
            
            vm.RotaRows.push(vm.RotaRows.length+1);
        }
        vm.EnableEditing = function () {
            if(vm.Editable != true){
                vm.Editable = true;
            } else {
                vm.Editable = false;
            }
        }
    }

})();