(function () {

    'use strict';

    angular
        .module('baseApp')
        .controller('PurchasedProductCtrl', PurchasedProductCtrl);

    PurchasedProductCtrl.inject = ['ProductFactory', 'UserFactory', 'LoginService'];
    function PurchasedProductCtrl(ProductFactory, UserFactory, LoginService) {
        var vm = this;

        
            

       
        var User = {
            UserID: LoginService.getUser(),
            HouseID: LoginService.getHouse()
        }
        
        vm.PrintStorage = function () {
            
            console.info("This is in the product Controller " + userData);
        }
        var ChargeObjList = [];
        vm.CreateNewProduct = function (HouseMateFName) {




        }

        vm.CreateObjList = function (HouseMate, index) {
            var ChargeObj = {
                Product: {
                    Name: vm.Name,
                    quantity: vm.quantity,
                    Description: vm.Description,
                    Price: vm.Price,
                    ProductGroup: vm.ProductGroup,
                },
                UserWhoPaidDetails: User,
                HouseMates: vm.HouseMates

            }
            
            console.log(ChargeObj);
            ProductFactory.CreateCharge(ChargeObj).then(function (resp) {
                console.info(resp);

                });
        }
    
        function init() {
            alert();
            UserFactory.GetHouseMates(User).then(function (resp) {
                vm.HouseMates = [];
                console.log(resp);
                _.each(resp.data, function (HouseMate) {
                    if (HouseMate.UserID !== parseInt(User.UserID)) {
                        vm.HouseMates.push(HouseMate);
                    }
                });

                console.log(vm.HouseMates);
            });
        }
        init();
        
    }


})();