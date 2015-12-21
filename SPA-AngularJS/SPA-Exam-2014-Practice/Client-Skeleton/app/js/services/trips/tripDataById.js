(function () {
    'use strict';

    app.factory('tripDataById', ['$http', '$q', 'data', function($http, $q, data) {

        function getTripData(id) {
            return data.get('/trips/' + id)
        }

        return {
            getTripData: getTripData
        }
    }]);
})();
