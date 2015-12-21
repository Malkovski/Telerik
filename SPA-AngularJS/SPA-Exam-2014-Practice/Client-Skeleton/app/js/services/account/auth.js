(function () {
    'use strict';

    app.factory('auth', ['$http', '$q', 'data', 'identity', function($http, $q, data, identity) {

            function register(user) {
                return data.post('/users/register', user);
            }

            function login(user) {
                user['grant_type'] = 'password';

                var data1 = "grant_type=password&username=" + (user.username || '') + '&password=' + (user.password || '');
                var data2 = "username=" + (user.username || '') + '&password=' + (user.password || '') + '&grant_type=password';
                var outerHeader = {'Content-Type': 'application/x-www-form-urlencoded'};

                return data.post('/users/login', data1, outerHeader)
            }

            function logout() {
                return data.post('/users/logout', {})
                    .then(function (response) {
                        identity.setCurrentUser(undefined);
                        $q.resolve(response);
                    }, function (err) {
                        $q.reject(err)
                    })
            }


            return {
                register: register,
                login: login,
                logout: logout,
                isAuthenticated: function() {
                    if (identity.isAuthenticated()) {
                        return true;
                    }
                    else {
                        return $q.reject('not authorized');
                    }
                }
            }
        }]);
})();