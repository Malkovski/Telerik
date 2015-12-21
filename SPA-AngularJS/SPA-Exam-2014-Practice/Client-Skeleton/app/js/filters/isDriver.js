(function () {
    "use strict";

    app.filter('isDriver', function() {
        return function (input) {
            if (input) {
                return 'YES';
            }
            else {
                return  'NO';
            }
        };
    });
})();