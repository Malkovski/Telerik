(function () {
    "use strict";

    app.controller('CreateController', ['$scope', 'createGame','notifier', function ($scope, createGame, notifier) {
        $scope.create = create;


        function create() {
            createGame.create()
                .then(function (response) {
                        notifier.success("Game with id: " + response + " created!");
                    },
                    function (err) {
                        notifier.error("Game creation failed!");
                    })
        }

    }])
})();