(function () {
    'use strict';

    app.factory('joinTrip', ['$http', '$q', 'data', function($http, $q, data) {

        function join(id) {
            return data.put('/trips/' + id);
        }

        return {
            join: join
        }
    }]);
})();