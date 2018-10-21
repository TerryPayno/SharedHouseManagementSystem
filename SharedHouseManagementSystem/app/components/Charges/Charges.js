(function () {

    'use strict';

    angular
        .module('baseApp')
        .controller('chargesCtrl', chargesCtrl);

    chargesCtrl.inject = ['ChargesFactory', 'UserFactory', 'LoginService'];
    function chargesCtrl(ChargesFactory, UserFactory, LoginService) {
        var vm = this;
        var userData = LoginService.getUser();

        vm.ChargesList = [];




        function init() {
            ChargesFactory.GetCharges(userData).then(function (resp) {
                _.each(resp.data, function (prod) {

                    vm.ChargesList.push(prod);

                });
            });
        }
        init()
    }

})();