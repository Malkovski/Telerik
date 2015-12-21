(function () {
    "use strict";

    app.factory('trips', ['$http', '$q', 'data', function ($http, $q, data) {

        function getCities() {
            return data.get('/cities');
        }

        function getTrips() {
            return data.get('/trips');
        }

        function getTripsByOpts(params) {
            return data.get('/trips', params)
        }

        return {
            getTrips: getTrips,
            getCities: getCities,
            getTripsByOpts: getTripsByOpts
        };

        //function createCurrentUrl(page, orderBy, orderType, from, to, finished, onlyMine) {
        //    var wantedUrl = usersApi + '/trips?page=' + page;
        //
        //    if (orderBy !== undefined) {
        //        wantedUrl += '&orderBy=' + orderBy;
        //    }
        //    if (orderType !== undefined) {
        //        wantedUrl += '&orderType=' + orderType;
        //    }
        //    if (from !== undefined) {
        //        wantedUrl += '&from=' + from;
        //    }
        //    if (to !== undefined) {
        //        wantedUrl += '&to=' + to;
        //    }
        //
        //    return wantedUrl + '&finished=' + finished + '&onlyMine=' + onlyMine;
        //}
    }]);
})();
