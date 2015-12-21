(function () {
    "use strict";

    app.factory('createGame', ['$http', '$q', 'baseUrl', 'baseHeader', function ($http, $q, baseUrl, baseHeader) {

        var create = function () {
            var deferred = $q.defer();

            $http.post(baseUrl + '/games/create', {}, baseHeader)
                .success(function(response) {
                    deferred.resolve(response);
                }, function(response) {
                    deferred.reject(response);
                });

            return deferred.promise;
        };


        return {
            create: create
        }

    }])
})();