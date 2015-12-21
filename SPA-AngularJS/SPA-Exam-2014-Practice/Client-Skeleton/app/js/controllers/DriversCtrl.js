(function () {
    'use strict';

    app.controller('DriversCtrl', ['$scope', 'drivers', 'identity', function ($scope, drivers, identity) {
        $scope.ident = identity;
        $scope.initFiltering = initFiltering;

        $scope.request = {
          page: 1
        };

        $scope.getPreviousPage = getPreviousPage;
        $scope.getNextPage = getNextPage;

        drivers.getDrivers($scope.request)
            .then(function (data) {
                $scope.allDrivers = data;
            });

        function initFiltering() {
            drivers.getDrivers($scope.request)
                .then(function (data) {
                    $scope.allDrivers = data;
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

    }]);
})();

