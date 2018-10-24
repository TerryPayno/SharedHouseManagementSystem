var baseApp = angular.module("baseApp", ['ui.router', 'ngMaterial']);

baseApp.config(['$stateProvider', '$locationProvider', '$urlRouterProvider',
    function ($stateProvider, $locationProvider, $urlRouterProvider) {

        $stateProvider
            .state("dashboard", {
                url: '/dashboard',
                templateUrl: "app/components/Dashboard/dashboard.html",
                controller: "DashboardCtrl",
                controllerAs: 'vm'
            }).state("login", {
                url: '/login',
                templateUrl: "app/components/Login/Login.html",
                controller: "LoginCtrl",
                controllerAs: 'vm'
            }).state("products", {
                url: '/products',
                templateUrl: "app/components/PurchasedProduct/PurchasedProduct.html",
                controller: "PurchasedProductCtrl",
                controllerAs: 'vm'
            }).state("userbuy", {
                url: '/userbuy',
                templateUrl: "app/components/UserBoughtProducts/UserBoughtProducts.html",
                controller: "UserBoughtProductsCtrl",
                controllerAs: 'vm'
            }).state("charges", {
                url: '/charges',
                templateUrl: "app/components/Charges/Charges.html",
                controller: "chargesCtrl",
                controllerAs: 'vm'
            }).state("ResetPassword", {
                url: '/ResetPassword',
                templateUrl: "app/components/ResetPassword/ResetPassword.html",
                controller: "ResetpasswordCtrl",
                controllerAs: 'vm'
            }).state("ResetPasswordAction", {
                url: '/ResetPasswordAction/{id}',
                templateUrl: "app/components/ResetPassword/ResetPasswordAction.html",
                controller: "ResetpasswordActionCtrl",
                controllerAs: 'vm'
            }).state("Rota", {
                url: '/Rota',
                templateUrl: "app/components/Rota/Rota.html",
                controller: "RotaCtrl",
                controllerAs: 'vm'
            }).state("PaidShare", {
                url: '/PaidShare',
                templateUrl: "app/components/PaidShare/PaidShare.html",
                controller: "PaidShareCtrl",
                controllerAs: 'vm'
            });

        $urlRouterProvider.otherwise('/');

        $locationProvider.hashPrefix('');

        $locationProvider.html5Mode(true);


    }
    ]);
