(function () {

    'use strict';

    angular
        .module('baseApp')
        .controller('ShareToPayCtrl', ShareToPayCtrl);

    ShareToPayCtrl.inject = ['ProductFactory', 'UserFactory', 'LoginService'];
    function ShareToPayCtrl(ProductFactory, UserFactory, LoginService) {
        var vm = this;
        var userData = LoginService.getUser();






        function init() {
            ProductFactory.GetUserPaidShares(userData).then(function (resp) {
                _.each(resp.data, function (prod) {

                    vm.userBoughtProductList.push(prod);

                });
            });
        }
        init()
    }

})();