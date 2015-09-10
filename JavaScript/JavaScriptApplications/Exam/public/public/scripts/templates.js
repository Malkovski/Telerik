import 'jquery';
import handlebars from 'handlebars';

var templates = (function () {
    var load = function (name) {
        var url = `templates/${name}.handlebars`;
        var promise = new Promise(function (resolve, reject) {
            $.get(url, function (template) {
                var templateHTML = handlebars.compile(template);
                resolve(templateHTML);
            })
        });

        return promise;
    };

    return {
        load
    }
})();

export default templates;