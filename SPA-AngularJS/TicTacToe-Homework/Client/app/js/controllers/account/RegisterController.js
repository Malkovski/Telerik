'use strict';

app.controller('RegisterController', ['$scope', '$location', 'auth', 'notifier', function($scope, $location, auth, notifier) {

    $scope.register = function(user) {
        auth.register(user)
            .then(function() {
            notifier.success('Registration successful!');
            $location.path('/');
            },
            function (err) {
                notifier.error(err);
                $location.path('/');
            })
    }

}]);