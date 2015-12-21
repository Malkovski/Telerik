(function () {
    'use strict';

    app.directive('searchDrivers', function() {
        return {
            restrict: 'A',
            template: '../views/directives/driverSearch.html',
            replace: true,
            scope: {
                search: "="
            }
        }
    });
})();