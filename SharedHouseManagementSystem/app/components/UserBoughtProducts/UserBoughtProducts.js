(function () {

    'use strict';

    angular
        .module('baseApp')
        .controller('UserBoughtProductsCtrl', UserBoughtProductsCtrl);

    UserBoughtProductsCtrl.inject = ['ProductFactory', 'UserFactory', 'LoginService'];
    function UserBoughtProductsCtrl(ProductFactory, UserFactory, LoginService) {
        var vm = this;
        var userData = LoginService.getUser();
        alert(userData);
        vm.GetProducts = function () {

            ProductFactory.GetUserBoughtProducts(userData).then(function (resp) {
                    console.info(resp);
            });
        }



    }
})();