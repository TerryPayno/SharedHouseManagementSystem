(function () {

    'use strict';

    angular
        .module('baseApp')
        .controller('UserBoughtProductsCtrl', UserBoughtProductsCtrl);

    UserBoughtProductsCtrl.inject = ['ProductFactory', 'UserFactory', 'LoginService'];
    function UserBoughtProductsCtrl(ProductFactory, UserFactory, LoginService) {
        var vm = this;
        var userData = LoginService.getUser();
        alert(userData.UserID);
        vm.GetProducts = function () {
            var userData = LoginService.getUser();
            ProductFactory.GetUserBoughtProducts(userData).then(function (resp) {
                console.info(resp);

            });

        }



    }
})();