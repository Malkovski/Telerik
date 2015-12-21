"use strict";

app.factory('stats', ['$http', '$q', 'data', function ($http, $q, data) {

    var getStatistics = function () {
      return  data.get('/stats');
    };

    return {
        getStatistics: getStatistics
    }
}]);