(function () {
    'use strict';

    app.factory('createTrip', ['$http', '$q', 'data', function($http, $q, data) {

        function create(params) {
            return data.post('/trips', params);
        }

        return {
            create: create
        }
    }]);
})();