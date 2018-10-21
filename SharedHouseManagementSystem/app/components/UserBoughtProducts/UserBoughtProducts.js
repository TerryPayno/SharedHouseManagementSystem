(function () {

    'use strict';

    angular
        .module('baseApp')
        .controller('UserBoughtProductsCtrl', UserBoughtProductsCtrl);

    UserBoughtProductsCtrl.inject = ['ProductFactory', 'UserFactory', 'LoginService'];
    function UserBoughtProductsCtrl(ProductFactory, UserFactory, LoginService) {
        var vm = this;
        var userData = LoginService.getUser();

        vm.userBoughtProductList = [];




        function init() {
            ProductFactory.GetUserBoughtProducts(userData).then(function (resp) {
                _.each(resp.data, function (prod) {

                    vm.userBoughtProductList.push(prod);

                });
            });
        }
        init()
    }

})();