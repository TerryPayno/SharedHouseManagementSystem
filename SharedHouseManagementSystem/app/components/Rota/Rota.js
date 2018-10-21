(function () {

    'use strict';

    angular
        .module('baseApp')
        .controller('RotaCtrl', RotaCtrl);

    RotaCtrl.inject = ['ProductFactory', 'UserFactory', 'LoginService'];
    function RotaCtrl(ProductFactory, UserFactory, LoginService) {
        var vm = this;
        var userData = LoginService.getUser();


    }

})();