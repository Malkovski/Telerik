(function () {
    'use strict';

    app.factory('auth', ['$http', '$q', '$cookies', 'identity', 'baseUrl','baseHeader' , function ($http, $q, $cookies, identity, baseUrl, baseHeader) {
        var TOKEN_KEY = 'authentication';

        var register = function(user) {
            var deferred = $q.defer();

            $http.post(baseUrl + '/api/account/register', user)
                .success(function() {
                    deferred.resolve();
                }, function(response) {
                    deferred.reject(response);
                });

            return deferred.promise;
        };

        var login = function login(user) {
            var deferred = $q.defer();

            var data1 = "grant_type=password&username=" + (user.username || '') + '&password=' + (user.password || '');
            var data2 = "username=" + (user.username || '') + '&password=' + (user.password || '') + '&grant_type=password';

            $http.post(baseUrl + '/Token', data2, {headers: {'Content-Type': 'application/x-www-form-urlencoded'}})
                .success(function (response) {
                    var userName = response.userName;
                    var tokenValue = response.access_token;


                    var theBigDay = new Date();
                    theBigDay.setHours(theBigDay.getHours() + 168);

                    $cookies.put(TOKEN_KEY, userName, {expires: theBigDay});

                    baseHeader = 'Bearer ' + tokenValue;
                    $http.defaults.headers.common.Authorization = 'Bearer ' + tokenValue;

                    identity.setUser(user);
                    deferred.resolve(response);

                    //getIdentity().then(function () {
                    //    deferred.resolve(response);
                    //});
                })
                .error(function (err) {
                    deferred.reject(err);
                });

            return deferred.promise;
        };

        //var getIdentity = function () {
        //    var deferred = $q.defer();
        //
        //    $http.get(baseUrl + 'api/Account/ExternalLogin')
        //        .success(function (identityResponse) {
        //            identity.setUser(identityResponse);
        //            deferred.resolve(identityResponse);
        //        });
        //
        //    return deferred.promise;
        //};

        return {
            register: register,
            login: login,
            //getIdentity: getIdentity,
            isAuthenticated: function () {
                return !!$cookies.get(TOKEN_KEY);
            },
            logout: function () {
                $cookies.remove(TOKEN_KEY);
                $http.defaults.headers.common.Authorization = null;
                identity.removeUser();
            },
            getUserName: function () {
                return $cookies.get(TOKEN_KEY);
            }
        };
    }])

}());