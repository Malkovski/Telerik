(function () {
    'use strict';

    app.controller('UserInfoCtrl', ['$scope', 'getCurrentUserData', function($scope, getCurrentUserData) {

        getCurrentUserData.getCurrentUser()
            .then(function (data) {
                $scope.info = data;
            });
    }]);
})();