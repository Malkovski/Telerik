(function () {
    'use strict';

    app.directive('tripsDirective', function() {
        return {
            restrict: 'A',
            templateUrl: 'views/directives/trips-list.html',
            replace: true
        }
    });
})();