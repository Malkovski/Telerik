(function () {
    "use strict";

    app.factory('joinGame', ['$http', '$q', 'baseUrl', 'baseHeader', function ($http, $q, baseUrl, baseHeader) {

        var join = function () {
            var deferred = $q.defer();

            $http.post(baseUrl + '/games/join', {}, baseHeader)
                .success(function(response) {
                    deferred.resolve(response);
                }, function(response) {
                    deferred.reject(response);
                });

            return deferred.promise;
        };


        return {
            join: join
        }

    }])
})();