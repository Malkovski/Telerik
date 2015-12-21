(function () {
    'use strict';

    app.controller('RegisterController', ['$scope', '$location', 'auth', 'notifier', function($scope, $location, auth, notifier) {

        $scope.isDriverChecked = false;
        $scope.isItDriver = isItDriver;

        function isItDriver() {
            $scope.isDriverChecked == true ? $scope.isDriverChecked = false : $scope.isDriverChecked = true;
        }

        $scope.register = function(user) {
            debugger;
            auth.register(user)
                .then(function() {
                    notifier.success('Registration successful!');
                    $location.path('/');
                }, function (err) {
                    notifier.error(err.message)
                })
        }
    }]);
})();