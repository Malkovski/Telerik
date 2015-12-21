(function () {
    "use strict";

    app.controller('JoinController', ['$scope', 'joinGame','notifier', function ($scope, joinGame, notifier) {
        $scope.join = join;


        function join() {
            joinGame.join()
                .then(function (response) {
                        notifier.success("Game with id: " + response + " joined!");
                    },
                    function (err) {
                        notifier.error("Game join failed!");
                    })
        }

    }])
})();