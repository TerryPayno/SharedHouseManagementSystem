(function () {

    'use strict';

    angular
        .module('baseApp')
        .controller('ResetpasswordCtrl', ResetpasswordCtrl);

    ResetpasswordCtrl.inject = ['LoginFactory', 'LoginService'];
    function ResetpasswordCtrl(LoginFactory, LoginService) {
        var vm = this;
        vm.ResetPasswordRequest = function () {
            LoginFactory.ResetPasswordRequest(vm.username).then(function (resp) {
                alert(resp.data);
            })
        }
        
    }
})();