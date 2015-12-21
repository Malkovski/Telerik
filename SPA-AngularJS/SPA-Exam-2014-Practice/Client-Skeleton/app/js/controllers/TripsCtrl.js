(function () {
    'use strict';

    app.controller('TripsCtrl', ['$scope', 'trips', 'identity', function ($scope, trips, identity) {
        $scope.cities = [];
        $scope.isMine = true;
        $scope.authorized = identity.isAuthenticated();
        $scope.ident = identity;
        $scope.initFiltering = initFiltering;

        $scope.request = {
            page: 1
        };

        $scope.getPreviousPage = getPreviousPage;
        $scope.getNextPage = getNextPage;

        $scope.initFiltering = initFiltering;

        trips.getTripsByOpts( $scope.request)
            .then(function (data) {
                $scope.allTrips = data;
            });

        function initFiltering() {
            trips.getTripsByOpts( $scope.request)
                .then(function (data) {
                    $scope.allTrips = data;
                })
        }

        function getPreviousPage() {
            if ($scope.request.page > 1) {
                $scope.request.page--;
            }

            initFiltering();
        }

        function getNextPage() {
            $scope.request.page++;

            initFiltering();
        }

        trips.getCities()
            .then(function (data) {
                $scope.cities = data;
            });

    }]);
})();