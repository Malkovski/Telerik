(function () {
    'use strict';

    app.factory('getCurrentUserData', ['data', function(data) {

        function getCurrentUser() {
            return data.get('/users/UserInfo');
        }

        return {
            getCurrentUser: getCurrentUser
        }
    }]);
})();