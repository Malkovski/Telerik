(function () {
    "use strict";

    app.controller('TripByIdCtrl', ['$scope', '$window', 'data', 'tripDataById', '$routeParams', 'joinTrip', 'notifier', '$location',
        function ($scope, $window, data, tripDataById, $routeParams, joinTrip, notifier, $location) {
           // $scope.tripByIdInfo = [];
            var id = $routeParams.id;
            $scope.passengers = "";
            $scope.JoinCurrentTrip = JoinCurrentTrip;

            data.grantAccess();

            tripDataById.getTripData(id)
                .then(function (data) {
                    $scope.tripByIdInfo = data;
                    $scope.passengers = concatPassengerName($scope.tripByIdInfo.passengers);
                }, function (err) {
                    notifier.error(err.message);
                });

            function JoinCurrentTrip(id) {
                joinTrip.join(id)
                    .then(function () {
                        notifier.success("Join trip successful!");
                        $window.location.href = '#/trips/' + id;
                    }, function (err) {
                        notifier.error(err.message);
                        $location.path('/trips/' + id);
                    })

            }

            function concatPassengerName(list){
                var temp = "";
                for (var i = 0, leni = list.length; i < leni; i += 1) {
                    temp += list[i];
                    if (i < leni - 1) {
                        temp += ', ';
                    }
                }

                return temp;
            }
        }]);
})();
