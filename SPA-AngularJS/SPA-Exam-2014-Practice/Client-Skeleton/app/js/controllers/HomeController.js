(function () {
    'use strict';

    app.controller('HomeCtrl', ['$scope', 'notifier', 'stats', 'drivers', 'trips',
        function($scope, notifier, stats, drivers, trips) {
            $scope.allDrivers = {};
            $scope.allTrips = {};
            $scope.statistics = {};

            stats.getStatistics()
                .then(function (data) {
                    $scope.statistics = data;
                });

            drivers.getDrivers()
                .then(function (data) {
                    $scope.allDrivers = data;
                });

            trips.getTrips()
                .then(function (data) {
                    $scope.allTrips = data;
                })
        }]);
})();

