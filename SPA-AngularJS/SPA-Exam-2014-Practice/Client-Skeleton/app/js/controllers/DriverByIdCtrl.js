(function () {
    'use strict';

    app.controller('DriverByIdCtrl', ['$scope', '$routeParams', '$location', 'data', 'driverDataById', 'identity',
        function($scope, $routeParams, $location, data, driverDataById, identity) {

            $scope.filterAsCurrent = false;
            $scope.filterAsSearched = false;
            $scope.tripFilterName = "";
            $scope.sortOpt = "None";
            $scope.sort = "";
            $scope.SortByOpt = SortByOpt;

            data.grantAccess();

            $scope.filterByCurrent = filterByCurrent;
            $scope.filterBySearched = filterBySearched;

            var id = $routeParams.id;
            var currentUser = identity.getCurrentUser();


            driverDataById.getDriverData(id)
                .then(function (data) {
                    $scope.userByIdInfo = data;
                });

            function filterByCurrent() {
                if ($scope.filterAsCurrent) {
                    $scope.tripFilterName = currentUser.userName;
                }
                else {
                    if ($scope.filterAsSearched) {
                        $scope.tripFilterName = $scope.userByIdInfo.name;
                    }
                    else {
                        $scope.tripFilterName = "";
                    }
                }
            }

            function filterBySearched() {
                if ($scope.filterAsSearched) {
                    $scope.tripFilterName = $scope.userByIdInfo.name;
                }
                else {
                    if ($scope.filterAsCurrent) {
                        $scope.tripFilterName = currentUser.userName;
                    }
                    else {
                        $scope.tripFilterName = "";
                    }
                }
            }

            function SortByOpt() {
                switch ($scope.sortOpt) {

                    case 'From':
                        $scope.sort = 'from';
                        break;
                    case 'To':
                        $scope.sort = 'to';
                        break;
                    case 'Departure time':
                        $scope.sort = 'departureDate';
                        break;
                    default: break;
                }
            }
        }]);
})();
