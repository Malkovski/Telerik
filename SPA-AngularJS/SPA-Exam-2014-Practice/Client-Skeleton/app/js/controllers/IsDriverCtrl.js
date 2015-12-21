(function () {
    'use strict';

    app.controller('IsDriverCtrl', ['$scope', function ($scope) {
        $scope.isDriverChecked = false;
        $scope.isItDriver = isItDriver;

        function isItDriver() {
            $scope.isDriverChecked == true ? $scope.isDriverChecked = false : $scope.isDriverChecked = true;
        }

    }]);
})();