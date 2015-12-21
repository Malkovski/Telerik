(function () {
    'use strict';

    app.controller('LoginController', ['$scope', '$location', 'auth', 'identity', 'notifier', function ($scope, $location, auth, identity, notifier) {
       // var vm = this;
        $scope.auth = auth;

        $scope.login = function (user, loginForm) {
            if (loginForm.$valid) {
                auth.login(user)
                    .then(function(success) {
                    //for (var member in user) delete user[member];
                        if (success) {
                            notifier.success('Successful login!');
                            notifier.warning('Welcome ' + user.username  + '!');
                        }
                    },
                    function (err) {
                            notifier.error('Username/Password combination is not valid!');
                    });
            }
            else {
                notifier.error('Username and password are required fields!')
            }
               // $scope.closeModal();
        };

        $scope.logout = function () {
            auth.logout();
            notifier.success('Successful logout!');

            if ($scope.user) {
                $scope.user.email = '';
                $scope.user.username = '';
                $scope.user.password = '';
            }

            $scope.loginForm.$setPristine();
            $location.path('/');
        };
    }]);
}());