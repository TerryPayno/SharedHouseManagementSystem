(function () {

    'use strict';

    angular
        .module('baseApp')
        .controller('DashboardCtrl', DashboardCtrl);

    DashboardCtrl.inject = [];
    function DashboardCtrl() {
        var vm = this;
        vm.name = 'James';

    }


})();