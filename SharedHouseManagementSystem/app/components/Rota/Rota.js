(function () {

    'use strict';

    angular
        .module('baseApp')
        .controller('RotaCtrl', RotaCtrl);

    RotaCtrl.inject = ['$scope','ProductFactory', 'UserFactory', 'LoginService', 'RotaFactory'];
    function RotaCtrl($scope, ProductFactory, UserFactory, LoginService, RotaFactory) {
        var vm = this;
        var userData = LoginService.getUser();
        vm.RotaRows = [];
        vm.Editable = true;
        var RotaObj = {};


        vm.AddNewRow = function () {
            
            vm.RotaRows.push(RotaObj = {
                Time: "Time",
                Monday: "Test",
                Tuesday: "Test",
                Wednesday: "Test",
                Thursday: "Test",
                Friday: "Test",
                Saturday: "Test",
                Sunday: "Test"

            });
        }
        vm.EnableEditing = function (index) {
            if(vm.Editable !== false){
                vm.Editable = false;

            } else {
                vm.Editable = true;
                console.log(index);
                console.log(vm.RotaRows);

                RotaFactory.SaveRota(vm.RotaRows).then(function (resp) {
                    alert(resp);

                });
            //Save changes to Database.

            }
        }
        function init() {

            RotaFactory.GetRotaData().then(function (resp) {
                console.log(resp);
             
                _.each(resp.data, function (resp) {
                        vm.RotaRows.push(resp);
                });

                console.log(vm.RotaRows);
            });
        }
        init();
    }

})();