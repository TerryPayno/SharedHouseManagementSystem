var baseApp = angular.module("baseApp", ['ui.router', 'ngMaterial']);

baseApp.config(['$stateProvider', '$locationProvider', '$urlRouterProvider',
    function ($stateProvider, $locationProvider, $urlRouterProvider) {

        $stateProvider
            .state("dashboard", {
                url: '/dashboard',
                templateUrl: "/app/components/Dashboard/dashboard.html",
                controller: "DashboardCtrl",
                controllerAs: 'vm'
            }).state("login", {
                url: '/login',
                templateUrl: "/app/components/Login/Login.html",
                controller: "LoginCtrl",
                controllerAs: 'vm'
            }).state("products", {
                url: '/products',
                templateUrl: "/app/components/PurchasedProduct/PurchasedProduct.html",
                controller: "PurchasedProductCtrl",
                controllerAs: 'vm'
            });

        $urlRouterProvider.otherwise('/');

        $locationProvider.hashPrefix('');

        $locationProvider.html5Mode(true);



    }]);
