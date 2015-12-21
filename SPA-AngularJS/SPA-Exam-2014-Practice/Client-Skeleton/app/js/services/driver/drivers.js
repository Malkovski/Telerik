(function () {
    "use strict";

    app.factory('drivers', ['$http', '$q', 'data', function ($http, $q, data) {

            var getDrivers = function (params) {
                return data.get('/drivers', params);
            };

            return {
                getDrivers: getDrivers
            }
        }]);
})();
