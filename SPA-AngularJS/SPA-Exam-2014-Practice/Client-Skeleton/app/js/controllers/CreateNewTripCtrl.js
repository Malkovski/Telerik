(function () {
    'use strict';

    app.controller('CreateNewTripCtrl', ['$scope', 'data', 'trips', 'createTrip', 'notifier', function ($scope, data, trips, createTrip, notifier) {
        $scope.cities = [];
        $scope.isMine = true;
        $scope.createNewTrip = createNewTrip;

        data.grantAccess();

        trips.getCities()
            .then(function (data) {
                $scope.cities = data;
            });

        function createNewTrip() {
            createTrip.create($scope.request)
                .then(function (success) {
                    if (success) {
                        notifier.success("Creating trip successful!");
                    }
                }, function (err) {
                    notifier.error(err.message)
                })
        }
    }]);
})();