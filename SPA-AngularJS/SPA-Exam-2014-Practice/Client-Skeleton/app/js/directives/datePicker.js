(function () {
    'use strict';

    app.directive('datePicker', function() {
        return {
            require: 'ngModel',
            link: function(scope, el, attr, ngModel) {
                el.datetimepicker({
                    dateFormat: 'yy-mm-dd',
                    timeFormat: 'HH:mm:ss',
                    onSelect: function(dateText) {
                        scope.$apply(function() {
                            ngModel.$setViewValue(dateText);
                        });
                    }
                });
            }
        };
    });
})();