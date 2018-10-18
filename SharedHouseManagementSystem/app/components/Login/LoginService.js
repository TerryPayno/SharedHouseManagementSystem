﻿(function () {

    'use strict';

    angular
        .module('baseApp')
        .service('LoginService', LoginService);

    LoginService.$inject = [ ];

    function LoginService( ) {

        var CachedUser;

        function getUser() {
            return CachedUser; // I think that the reason that this is being returned as undifined is due to this being a service not a factory.
                               // Service is creating a new object everytime it is ceated therefor wiping the data from when it was used in the first controller
                               // Need to decide whether to user a factory or go with some sort of local storage solution. The we can move onto the problem of what Dapper is going 
                               // to do with my data :D  
        }
        function setCachedUser(data) {
            CachedUser = data;
        }

        return {
            setCachedUser: setCachedUser,
            getUser: getUser
        }
    }
})();