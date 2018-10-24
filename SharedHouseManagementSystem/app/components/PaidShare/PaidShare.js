(function () {

    'use strict';

    angular
        .module('baseApp')
        .controller('PaidShareCtrl', PaidShareCtrl);

    PaidShareCtrl.inject = ['ProductFactory', 'UserFactory', 'LoginService'];
    function PaidShareCtrl(ProductFactory, UserFactory, LoginService) {
        var vm = this;
        var userData = {
            UserID: LoginService.getUser(),
            HouseID: LoginService.getHouse(),
            UserName: LoginService.getUserName()
        }






        function init() {
            ProductFactory.GetPaidShares(userData).then(function (resp) {
                _.each(resp.data, function (prod) {

                    vm.PaidShareList.push(prod);

                });
            });
        }
        init()
    }

})();