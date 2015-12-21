(function () {
    "use strict";

    app.filter('isMine', function() {
        return function (input) {
            if (input) {
                return '../../img/bullet_accept.png';
            }
            else {
                return  '../../img/bullet_deny.png';
            }
        };
    });
})();
