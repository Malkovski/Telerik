(function () {
    "use strict";

    app.factory('data', ['$http', '$q', '$cookies', '$location', '$routeParams', 'authorization', 'baseServiceUrl',
        function ($http, $q, $cookies, $location, $routeParams, authorization, baseServiceUrl) {

            var headers;
            var baseUrl = baseServiceUrl + '/api';
            var current = $cookies.get('currentApplicationUser');
            var query = $routeParams;

            function setUserProps() {
                var current = $cookies.get('currentApplicationUser');
                if (current !== undefined) {
                    headers = authorization.getAuthorizationHeader();
                }
            }

            if (current !== undefined) {
               headers = authorization.getAuthorizationHeader();
            }

            var grantAccess = function () {
                var isAuth = $cookies.get('currentApplicationUser');

                if (isAuth === undefined) {
                    $location.path('/unauthorized');
                    //TODO find other way to do this!!!!
                    throw '';
                }
            };

            var get = function (url, params) {
                var defer = $q.defer();
                setUserProps();

                if (query !== {}) {
                    params = angular.extend({}, params, query);
                }

                $http.get(baseUrl + url, {params: params, headers: headers})
                    .success(function (data) {
                        defer.resolve(data);
                    })
                    .error(function(response) {
                        defer.reject(response)
                    });

                return defer.promise;
            };

            function post(url, params, outerHeader) {
                var defer = $q.defer();
                setUserProps();

                if (outerHeader) {
                    headers = outerHeader
                }

                $http.post(baseUrl + url, params, {headers: headers})
                    .success(function (data) {
                        defer.resolve(data);
                    })
                    .error(function(response) {
                        defer.reject(response)
                    });

                return defer.promise;
            }

            function put(url, params) {
                var defer = $q.defer();
                setUserProps();

                $http.put(baseUrl + url, {}, {params: params, headers: headers})
                    .success(function (data) {
                        defer.resolve(data);
                    })
                    .error(function(response) {
                        defer.reject(response)
                    });

                return defer.promise;
            }

            return {
                grantAccess: grantAccess,
                get: get,
                post: post,
                put: put
            }
    }]);
})();