(function () {

    'use strict';

    angular
        .module('baseApp')
        .service('LoginService', LoginService);

    LoginService.$inject = [ ];

    function LoginService( ) {

        var CachedUser;
        alert();
        function getUser() {
            return CachedUser;
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