(function () {
    'use strict';

    app.controller('LoginController', ['$scope', '$location', 'notifier', 'identity', 'auth', function($scope, $location, notifier, identity, auth) {
        $scope.identity = identity;

        $scope.login = function(user, loginForm) {
            if (loginForm.$valid) {
                auth.login(user)
                    .then(function(success) {
                        if (success) {
                            if (success["access_token"]) {
                                identity.setCurrentUser(success);
                            }
                            notifier.success('Successful login!');
                        }
                        else {
                            notifier.error('Username/Password combination is not valid!');
                        }
                    }, function (err) {
                        notifier.error(err.error_description);
                    });
            }
            else {
                notifier.error('Username and password are required fields!')
            }
        };

        $scope.logout = function() {
            //identity.setCurrentUser(undefined);
            auth.logout().then(function() {
                notifier.success('Successful logout!');
                if ($scope.user) {
                    $scope.user.email = '';
                    $scope.user.username = '';
                    $scope.user.password = '';
                }

                $scope.loginForm.$setPristine();
                $location.path('/');
            })
        }
    }]);
})();