(function () {
    'use strict';

    app.directive('driversDirective', function() {
        return {
            restrict: 'A',
            templateUrl: 'views/directives/drivers-list.html',
            replace: true
        }
    });
})();