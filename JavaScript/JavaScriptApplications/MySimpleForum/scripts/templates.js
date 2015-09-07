import $ from "bower_components/jquery/dist/jquery.js";
import handlebars from "bower_components/handlebars/handlebars.js";

var templates = (function () {
    var load = function (name) {
        var url = `templates/${name}.handlebars`;
        var promise = new Promise(function (resolve, reject) {
            $.get (url, function (template) {
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