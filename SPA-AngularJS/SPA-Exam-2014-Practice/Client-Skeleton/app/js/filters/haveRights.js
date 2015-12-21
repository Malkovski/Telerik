(function () {
    "use strict";

    app.filter('haveRights', function() {
        return function (input) {
            if (input) {
                return '#trips/';
            }
            else {
                return  '';
            }
        };
    });
})();
