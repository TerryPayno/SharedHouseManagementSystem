(function () {

    'use strict';

    angular
        .module('baseApp')
        .controller('ResetpasswordActionCtrl', ResetpasswordActionCtrl);

    ResetpasswordActionCtrl.inject = ['$stateParams', 'LoginFactory', 'LoginService'];
    function ResetpasswordActionCtrl($stateParams, LoginFactory, LoginService) {
        var vm = this;
        var id = $stateParams.id;
        alert(id);
        vm.ResetPasswordAction = function () {
            //alert(vm.newpass + " " + id);
            LoginFactory.ResetPasswordAction(vm.newpass, id).then(function (resp) {
                alert(resp.data);
            })
        }

    }
})();